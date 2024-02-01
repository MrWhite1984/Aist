using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aist.Panels;
using Aist.TypesOfData;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace Aist
{
    public partial class MainForm : Form
    {
        int consultationNum = 0;
        //List<List<string[]>> data = new List<List<string[]>>();
        List<string[]> dataFromFile = new List<string[]>();
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists("Settings.json"))
            {
                Settings settings = new Settings();
                settings.JsonSaveLocationRadioButton = 0;
                settings.JsonPathString = "";
                settings.Format = 0;
                Settings.SetSettings(settings);
            }
        }


        private void openFileButton_Click(object sender, EventArgs e)
        {
            consultations.Clear();
            scheduleFlowLayoutPanel.Controls.Clear();
            hashes.Hashes.Clear();
            openFileDialog.Filter = "Microsoft Excel (*.xls*)|*.xls*|Текстовые файлы (*.txt*)|*.txt*";
            openFileDialog.ShowDialog();
            cards.Clear();
            dataForPrintingToScreen.Clear();
            MainDelegateRefresh del = addConsultationButton_Click;
            MainDelegateDelete mainDelegateDelete = deleteButton_Click;
            MainDelegateClean mainDelegateClean = FLPClear;
            
            Settings settings = Settings.ImportSettings();
            if (openFileDialog.FileName != "")
            {
                path = openFileDialog.FileName;
                if (path.IndexOf(".xls") != -1)
                {
                    Application excel = new Application();
                    Workbook wb;
                    Worksheet ws;

                    wb = excel.Workbooks.Open(path);
                    ws = wb.Worksheets[1];
                    teacher = ws.Cells[2, 4].Value;
                    department = ws.Cells[4, 4].Value;

                    try
                    {
                        dataFromFile = DataReader.ReadAllData(ws);
                        if (settings.Format == 0)
                        {
                            dataForPrintingToScreen.AddRange(DataReader.DataByDays(dataFromFile));
                        }
                        else
                        {
                            List<string[]> dataCopy = dataFromFile;
                            dataForPrintingToScreen.AddRange(DataReader.ConvertToWeeklyFormat(DataReader.DataByDays(dataCopy)));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка чтения:\n{ex.Message}");
                    }
                    finally
                    {
                        wb.Close();
                        excel.Quit();
                    }                  
                    
                }
                else
                {
                    try
                    {
                        var items = DataReader.GetDataFromTxt(openFileDialog.FileName);
                        dataFromFile = items.Item1;
                        if (settings.Format == 0)
                        {                            
                            dataForPrintingToScreen.AddRange(DataReader.DataByDays(dataFromFile));
                        }
                        else
                        {
                            dataForPrintingToScreen.AddRange(DataReader.ConvertToWeeklyFormat(DataReader.DataByDays(dataFromFile)));
                        }                        
                        teacher = items.Item2;
                        department = items.Item3;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка чтения:\n{ex.Message}");
                    }
                }
                
                FillOutsTheCards(dataForPrintingToScreen, teacher, del);
                scheduleFlowLayoutPanel.Controls.AddRange(cards.ToArray());
                
            }
            
        }
        private void AddFileButton_Click(object sender, EventArgs e)
        {
            Settings settings = Settings.ImportSettings();
            MainDelegateDelete mainDelegateDelete = deleteButton_Click;
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                path = openFileDialog.FileName;
                List<string[]> newDataFromFile = new();
                List<List<string[]>> newData = new List<List<string[]>>();
                if (path.IndexOf(".xls") != -1)
                {
                    Application excel = new Application();
                    Workbook wb;
                    Worksheet ws;

                    wb = excel.Workbooks.Open(path);
                    ws = wb.Worksheets[1];

                    newDataFromFile = DataReader.ReadAllData(ws);
                    newData = DataReader.DataByDays(newDataFromFile);



                    wb.Close();
                    excel.Quit();
                }
                else
                {
                    var items = DataReader.GetDataFromTxt(path);
                    newDataFromFile = items.Item1;
                    
                    if (items.Item2 != teacher)
                    {
                        MessageBox.Show("Преподаватель в исходном файле не совпадает с преподавателем в добавленном");
                    }                    
                }
                cards.Clear();
                hashes.Hashes.Clear();
                MainDelegateRefresh del = addConsultationButton_Click;
                List<List<string[]>> firstData = new List<List<string[]>>();
                firstData.AddRange(dataForPrintingToScreen);
                List<List<string[]>> oldData = new List<List<string[]>>();
                oldData.AddRange(dataForPrintingToScreen);
                try
                {
                    dataForPrintingToScreen.Clear();
                    if(!DataReader.DataComparison(dataFromFile, newDataFromFile))
                    {
                        dataFromFile.AddRange(newDataFromFile);
                        if (settings.Format == 0)
                        {
                            dataForPrintingToScreen.AddRange(DataReader.DataByDays(dataFromFile));
                        }
                        else
                        {
                            List<string[]> dataCopy = dataFromFile;
                            dataForPrintingToScreen.AddRange(DataReader.ConvertToWeeklyFormat(DataReader.DataByDays(dataCopy)));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выбраный файл уже добавлен");
                        if (settings.Format == 0)
                        {
                            dataForPrintingToScreen.AddRange(DataReader.DataByDays(dataFromFile));
                        }
                        else
                        {
                            dataForPrintingToScreen.AddRange(DataReader.ConvertToWeeklyFormat(DataReader.DataByDays(dataFromFile)));
                        }
                    }
                    
                    //dataForPrintingToScreen.AddRange(DataReader.MergeData(data, newData));
                }
                catch
                {
                    if (settings.Format == 0)
                    {
                        dataForPrintingToScreen.AddRange(DataReader.DataByDays(dataFromFile));
                    }
                    else
                    {
                        dataForPrintingToScreen.AddRange(DataReader.ConvertToWeeklyFormat(DataReader.DataByDays(dataFromFile)));
                    }
                    MessageBox.Show("Ошибеп добавления файла");
                }
                FillOutsTheCards(dataForPrintingToScreen, teacher, del);
                scheduleFlowLayoutPanel.Controls.Clear();
                scheduleFlowLayoutPanel.Controls.AddRange(cards.ToArray());
                foreach (var consultation in consultations)
                {
                    RefreshConsultations(consultation, del, mainDelegateDelete, scheduleFlowLayoutPanel);
                }
            }
        }
        private static void FillOutsTheCards(List<List<string[]>> data, string teacher, MainDelegateRefresh del)
        {
            cards.Clear();
            days = DataReader.GetDateByCode(data);
            for (int i = 0; i < data.Count; i++)
            {
                var card = DayCardPanel.AddDayCardPanel(data[i], teacher, i, del);
                cards.Add(card.Item1);
                foreach (var d in card.Item2.Hashes)
                {
                    hashes.Hashes.Add(d.Key, d.Value);
                }
            }
        }

        private void addConsultationButton_Click(object sender, EventArgs e)
        {
            MainDelegateRefresh del = addConsultationButton_Click;
            MainDelegateDelete mainDelegateDelete = deleteButton_Click;
            AddConsultationForm addConsultationForm = new AddConsultationForm();
            addConsultationForm.ShowDialog();
            Consultation consultation = new Consultation()
            {
                Day = hashes.Hashes[Convert.ToInt32(sender.GetHashCode().ToString())].Item1,
                SubjPos = hashes.Hashes[Convert.ToInt32(sender.GetHashCode().ToString())].Item2,
                ScienceRoom = addConsultationForm.textBox1.Text,
                Group = addConsultationForm.textBox2.Text,
                Teacher = teacher,
                Date = days[hashes.Hashes[Convert.ToInt32(sender.GetHashCode().ToString())].Item1]
            };
            addConsultationForm.Close();
            var items = ConsultationCardPanel.AddConsultationCardPanel(cards, consultation, del, mainDelegateDelete, consultations);
            cards = items.Item1;
            foreach (var h in items.Item2.Hashes)
            {
                hashes.Hashes.Add(h.Key, h.Value);
            }
            scheduleFlowLayoutPanel.Controls.Clear();
            scheduleFlowLayoutPanel.Controls.AddRange(cards.ToArray());
            consultationIntNumLabel.Text = consultations.Count.ToString();
        }
               

        private void deleteButton_Click(object sender, EventArgs e)
        {
            MainDelegateRefresh del = addConsultationButton_Click;
            MainDelegateDelete mainDelegateDelete = deleteButton_Click;
            var items = ConsultationCardPanel.DropConsultationCardPanel(cards, hashes.Hashes[Convert.ToInt32(sender.GetHashCode().ToString())].Item1, hashes.Hashes[Convert.ToInt32(sender.GetHashCode().ToString())].Item2, del, mainDelegateDelete, consultations);
            cards = items.Item1;
            foreach (var h in items.Item2.Hashes)
            {
                hashes.Hashes.Add(h.Key, h.Value);
            }
            scheduleFlowLayoutPanel.Controls.Clear();
            scheduleFlowLayoutPanel.Controls.AddRange(cards.ToArray());
            consultationIntNumLabel.Text = consultations.Count.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (dataForPrintingToScreen.Count != 0)
            {
                SaveForm saveForm = new SaveForm();
                saveForm.consultationsNum = consultations.Count;
                saveForm.ShowDialog();
                string pathToNewFile = "0";
                if (((saveForm.scheduleCheckBox.Checked || saveForm.consultationsDocCheckBox.Checked) || (saveForm.consultationsJsonBheckBox.Checked && Settings.ImportSettings().JsonSaveLocationRadioButton == 0)))
                {
                    folderBrowserDialog.ShowDialog();
                    pathToNewFile = folderBrowserDialog.SelectedPath;
                }
                if (pathToNewFile != "" && pathToNewFile != null)
                {
                    if (dataForPrintingToScreen.Count != 0 && consultations.Count != 0 && saveForm.scheduleCheckBox.Checked)
                    {
                        List<Consultation> temporaryListOfConsultations = new List<Consultation>();
                        temporaryListOfConsultations.AddRange(consultations);
                        Dictionary<int, string> temporaryDictionaryOfDays = new Dictionary<int, string>();
                        for (int i = 0; i < days.Count; i++)
                        {
                            temporaryDictionaryOfDays.Add(days.Keys.ToList()[i], days.Values.ToList()[i]);
                        }
                        List<List<string[]>> temporaryListOfFirstFileData = new List<List<string[]>>();
                        temporaryListOfFirstFileData.AddRange(dataForPrintingToScreen);
                        DataWriter.SavingDataInScheduleFormat(pathToNewFile, temporaryListOfConsultations, temporaryDictionaryOfDays, FLPClear, temporaryListOfFirstFileData);
                    }
                    if (consultations.Count > 0)
                    {
                        if (saveForm.consultationsDocCheckBox.Checked)
                        {
                            List<Consultation> temporaryListOfConsultations = new List<Consultation>();
                            temporaryListOfConsultations.AddRange(consultations);
                            Dictionary<int, string> temporaryDictionaryOfDays = new Dictionary<int, string>();
                            for (int i = 0; i < days.Count; i++)
                            {
                                temporaryDictionaryOfDays.Add(days.Keys.ToList()[i], days.Values.ToList()[i]);
                            }
                            DataWriter.WriteConsultationsToFile(pathToNewFile, temporaryListOfConsultations, temporaryDictionaryOfDays, FLPClear);
                        }
                        Settings settings = Settings.ImportSettings();
                        if (settings.JsonSaveLocationRadioButton == 1 && settings.JsonPathString != "" && saveForm.consultationsJsonBheckBox.Checked)
                        {
                            ConsultationForJSON.WriteToJSON(settings.JsonPathString, $@"{teacher}.json", new ConsultationForJSON(teacher, consultations));
                        }
                        else if (saveForm.consultationsJsonBheckBox.Checked)
                        {
                            ConsultationForJSON.WriteToJSON(pathToNewFile, $@"{teacher}.json", new ConsultationForJSON(teacher, consultations));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введите путь");
                }
                saveForm.Close();
            }
            else
            {
                MessageBox.Show("Нет открытого расписания");
            }
        }

        private void FLPClear()
        {
            scheduleFlowLayoutPanel.Controls.Clear();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            Settings settings = Settings.ImportSettings();
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.consultations = consultations;
            settingsForm.ShowDialog();
            Settings newSettings = Settings.ImportSettings();
            if (settings.Format != newSettings.Format)
            {
                if(newSettings.Format == 1)
                {
                    cards.Clear();
                    hashes.Hashes.Clear();
                    MainDelegateRefresh del = addConsultationButton_Click;
                    MainDelegateDelete mainDelegateDelete = deleteButton_Click;
                    List<List<string[]>> firstData = new List<List<string[]>>();
                    firstData.AddRange(dataForPrintingToScreen);
                    dataForPrintingToScreen.Clear();
                    dataForPrintingToScreen.AddRange(DataReader.ConvertToWeeklyFormat(firstData));
                    FillOutsTheCards(dataForPrintingToScreen, teacher, del);
                    scheduleFlowLayoutPanel.Controls.Clear();
                    scheduleFlowLayoutPanel.Controls.AddRange(cards.ToArray());
                    foreach (var consultation in consultations)
                    {
                        RefreshConsultations(consultation, del, mainDelegateDelete, scheduleFlowLayoutPanel);
                    }
                }
                else
                {
                    cards.Clear();
                    hashes.Hashes.Clear();
                    MainDelegateRefresh del = addConsultationButton_Click;
                    MainDelegateDelete mainDelegateDelete = deleteButton_Click;
                    List<List<string[]>> firstData = new List<List<string[]>>();
                    firstData.AddRange(dataForPrintingToScreen);
                    dataForPrintingToScreen.Clear();
                    dataForPrintingToScreen.AddRange(DataReader.ConvertToNormalFormat(firstData, consultations));
                    FillOutsTheCards(dataForPrintingToScreen, teacher, del);
                    scheduleFlowLayoutPanel.Controls.Clear();
                    scheduleFlowLayoutPanel.Controls.AddRange(cards.ToArray());
                    foreach (var consultation in consultations)
                    {
                        RefreshConsultations(consultation, del, mainDelegateDelete, scheduleFlowLayoutPanel);
                    }
                }
            }
            if(settings.ScheduleConsultationsOnWeekends != newSettings.ScheduleConsultationsOnWeekends)
            {
                cards.Clear();
                hashes.Hashes.Clear();
                MainDelegateRefresh del = addConsultationButton_Click;
                MainDelegateDelete mainDelegateDelete = deleteButton_Click;
                List<List<string[]>> firstData = new List<List<string[]>>();
                firstData.AddRange(dataForPrintingToScreen);
                dataForPrintingToScreen.Clear();
                dataForPrintingToScreen.AddRange(DataReader.ConvertToWeeklyFormat(firstData));
                FillOutsTheCards(dataForPrintingToScreen, teacher, del);
                scheduleFlowLayoutPanel.Controls.Clear();
                scheduleFlowLayoutPanel.Controls.AddRange(cards.ToArray());
                foreach (var consultation in consultations)
                {
                    RefreshConsultations(consultation, del, mainDelegateDelete, scheduleFlowLayoutPanel);
                }
            }
        }

        public static void RefreshConsultations(Consultation consultation, MainDelegateRefresh del, MainDelegateDelete mainDelegateDelete, FlowLayoutPanel scheduleFlowLayoutPanel)
        {
            List<Consultation> consult = new List<Consultation>();
            var items = ConsultationCardPanel.AddConsultationCardPanelInRefresher(cards, consultation, del, mainDelegateDelete, consultations, dataForPrintingToScreen);
            cards = items.Item1;
            foreach (var h in items.Item2.Hashes)
            {
                hashes.Hashes.Add(h.Key, h.Value);
            }
            scheduleFlowLayoutPanel.Controls.Clear();
            scheduleFlowLayoutPanel.Controls.AddRange(cards.ToArray());
        }

    }
    public delegate void MainDelegateRefresh(object sender, EventArgs e);
    public delegate void MainDelegateDelete(object sender, EventArgs e);
    public delegate void MainDelegateClean();
}
