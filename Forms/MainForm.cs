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
using Task = System.Threading.Tasks.Task;

namespace Aist
{
    public partial class MainForm : Form
    {
        int consultationNum = 0;
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
            firstFileData.Clear();
            MainDelegateRefresh del = addConsultationButton_Click;
            MainDelegateDelete mainDelegateDelete = deleteButton_Click;
            MainDelegateClean mainDelegateClean = FLPClear;
            List<List<string[]>> data = new List<List<string[]>>();
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
                        data = DataReader.DataByDays(DataReader.ReadAllData(ws));
                        if (settings.Format == 0)
                        {
                            firstFileData.AddRange(data);
                        }
                        else
                        {
                            data = DataReader.ConvertToWeeklyFormat(data);
                            firstFileData.AddRange(data);
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
                        if (settings.Format == 0)
                        {
                            data = items.Item1;
                        }
                        else
                        {
                            data = DataReader.ConvertToWeeklyFormat(items.Item1);
                        }

                        firstFileData.AddRange(data);
                        teacher = items.Item2;
                        department = items.Item3;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка чтения:\n{ex.Message}");
                    }
                }
                
                FillOutsTheCards(firstFileData, teacher, del);
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
                List<List<string[]>> newData = new List<List<string[]>>();
                if (path.IndexOf(".xls") != -1)
                {
                    Application excel = new Application();
                    Workbook wb;
                    Worksheet ws;

                    wb = excel.Workbooks.Open(path);
                    ws = wb.Worksheets[1];


                    newData = DataReader.DataByDays(DataReader.ReadAllData(ws));



                    wb.Close();
                    excel.Quit();
                }
                else
                {
                    var items = DataReader.GetDataFromTxt(path);
                    if (settings.Format == 0)
                    {
                        newData = items.Item1;
                    }
                    else
                    {
                        newData = DataReader.ConvertToWeeklyFormat(items.Item1);
                    }
                    
                    if (items.Item2 != teacher)
                    {
                        MessageBox.Show("Преподаватель в исходном файле не совпадает с преподавателем в добавленном");
                    }                    
                }
                cards.Clear();
                hashes.Hashes.Clear();
                MainDelegateRefresh del = addConsultationButton_Click;
                List<List<string[]>> firstData = new List<List<string[]>>();
                firstData.AddRange(firstFileData);
                List<List<string[]>> oldData = new List<List<string[]>>();
                oldData.AddRange(firstFileData);
                try
                {
                    firstFileData.Clear();
                    firstFileData.AddRange(DataReader.MergeData(firstData, newData));
                }
                catch
                {
                    firstFileData.AddRange(oldData);
                }
                FillOutsTheCards(firstFileData, teacher, del);
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

        private async void saveButton_Click(object sender, EventArgs e)
        {
            if (firstFileData.Count != 0)
            {
                SaveForm saveForm = new SaveForm();
                saveForm.consultationsNum = consultations.Count;
                saveForm.ShowDialog();
                string pathToNewFile = "0";
                if (saveForm.flag)
                {
                    if (((saveForm.scheduleCheckBox.Checked || saveForm.consultationsDocCheckBox.Checked) || (saveForm.consultationsJsonCheckBox.Checked && Settings.ImportSettings().JsonSaveLocationRadioButton == 0)))
                    {
                        folderBrowserDialog.ShowDialog();
                        pathToNewFile = folderBrowserDialog.SelectedPath;
                    }
                    List<System.Windows.Forms.CheckBox> saveFormats = new List<System.Windows.Forms.CheckBox>() { saveForm.scheduleCheckBox, saveForm.consultationsDocCheckBox, saveForm.consultationsJsonCheckBox };
                    if (pathToNewFile != "" && pathToNewFile != null)
                    {
                        DataSaver.progressBar = saveProgressBar;
                        DataSaver.SaveDataToFiles
                            (
                            firstFileData,
                            consultations,
                            saveForm,
                            days,
                            pathToNewFile,
                            //FLPClear,
                            teacher,
                            saveFormats.Count(box => box.Checked)
                            );
                    }
                    else
                    {
                        MessageBox.Show("Введите путь");
                    }
                    saveForm.Close();
                    saveForm.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Нет открытого расписания");
            }
        }

        private void OnProgressBarChange(int progress)
        {
            saveProgressBar.Value += progress;
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
                    firstData.AddRange(firstFileData);
                    firstFileData.Clear();
                    firstFileData.AddRange(DataReader.ConvertToWeeklyFormat(firstData));
                    FillOutsTheCards(firstFileData, teacher, del);
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
                    firstData.AddRange(firstFileData);
                    firstFileData.Clear();
                    firstFileData.AddRange(DataReader.ConvertToNormalFormat(firstData, consultations));
                    FillOutsTheCards(firstFileData, teacher, del);
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
                firstData.AddRange(firstFileData);
                firstFileData.Clear();
                firstFileData.AddRange(DataReader.ConvertToWeeklyFormat(firstData));
                FillOutsTheCards(firstFileData, teacher, del);
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
            var items = ConsultationCardPanel.AddConsultationCardPanelInRefresher(cards, consultation, del, mainDelegateDelete, consultations, firstFileData);
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
