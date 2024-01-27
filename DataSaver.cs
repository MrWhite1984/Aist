using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aist.TypesOfData;
using System.Windows.Forms;
using System.ComponentModel;

namespace Aist
{
    class DataSaver
    {
        private static BackgroundWorker backgroundWorker1;
        private static BackgroundWorker backgroundWorker2;
        private static BackgroundWorker backgroundWorker3_1;
        private static BackgroundWorker backgroundWorker3_2;

        public static ProgressBar progressBar;

        public delegate void ProgressHandler(int progress);

        static List<List<string[]>> FirstFileData;
        static List<Consultation> Consultations;
        static Dictionary<int, string> Days;
        static string PathToNewFile;
        static string Teacher;
        static int CheckedNum;
        static Settings settings;
        static int RemainingWorkCounter;


        public static void SaveDataToFiles
            (
            List<List<string[]>> firstFileData, 
            List<Consultation> consultations, 
            SaveForm saveForm,
            Dictionary<int, string> days,
            string pathToNewFile,
            string teacher,
            int checkedNum
            )
        {
            FirstFileData = firstFileData;
            Consultations = consultations;
            Days = days;
            PathToNewFile = pathToNewFile;
            Teacher = teacher;
            CheckedNum = checkedNum;
            settings = Settings.ImportSettings();
            RemainingWorkCounter = checkedNum;


            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker2 = new BackgroundWorker();
            backgroundWorker3_1 = new BackgroundWorker();
            backgroundWorker3_2 = new BackgroundWorker();

            backgroundWorker1.DoWork += new DoWorkEventHandler(BackgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker1_RunWorkerCompleted);

            backgroundWorker2.DoWork += new DoWorkEventHandler(BackgroundWorker2_DoWork);
            backgroundWorker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker2_RunWorkerCompleted);

            backgroundWorker3_1.DoWork += new DoWorkEventHandler(BackgroundWorker3_1_DoWork);
            backgroundWorker3_1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker3_1_RunWorkerCompleted);

            backgroundWorker3_2.DoWork += new DoWorkEventHandler(BackgroundWorker3_2_DoWork);
            backgroundWorker3_2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker3_2_RunWorkerCompleted);


            if (firstFileData != null && firstFileData.Count != 0 && consultations.Count != 0 && saveForm.scheduleCheckBox.Checked)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            if (consultations.Count > 0)
            {
                if (saveForm.consultationsDocCheckBox.Checked)
                {
                    backgroundWorker2.RunWorkerAsync();
                }
                
                if (settings.JsonSaveLocationRadioButton == 1 && settings.JsonPathString != "" && saveForm.consultationsJsonCheckBox.Checked)
                {
                    backgroundWorker3_1.RunWorkerAsync();
                }
                else if (saveForm.consultationsJsonCheckBox.Checked)
                {
                    backgroundWorker3_2.RunWorkerAsync();
                }
            }
            
        }

        readonly static int[] completionPercenrage = { 100, 50, 33, 34, 0};

        private static void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Consultation> temporaryListOfConsultations = new ();
            temporaryListOfConsultations.AddRange(Consultations);
            Dictionary<int, string> temporaryDictionaryOfDays = new ();
            for (int i = 0; i < Days.Count; i++)
            {
                temporaryDictionaryOfDays.Add(Days.Keys.ToList()[i], Days.Values.ToList()[i]);
            }
            List<List<string[]>> temporaryListOfFirstFileData = new ();
            if(FirstFileData != null)
            {
                temporaryListOfFirstFileData.AddRange(FirstFileData);
            }
            DataWriter.SavingDataInScheduleFormat(PathToNewFile, temporaryListOfConsultations, temporaryDictionaryOfDays, temporaryListOfFirstFileData);
            RemainingWorkCounter--;
            if (CheckedNum == 1)
            {
                e.Result = completionPercenrage[0];
            }
            else if (CheckedNum == 2)
                e.Result = completionPercenrage[1];
            else
                e.Result = completionPercenrage[2];
        }
        private static void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value += Convert.ToInt32(e.Result.ToString());
            if (progressBar.Value == completionPercenrage[0])
            {
                DialogResult dialogResult = MessageBox.Show("Файлы сохранены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(dialogResult == DialogResult.OK)
                    progressBar.Value = completionPercenrage[4];
            }
        }


        private static void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Consultation> temporaryListOfConsultations = new();
            temporaryListOfConsultations.AddRange(Consultations);
            Dictionary<int, string> temporaryDictionaryOfDays = new();
            for (int i = 0; i < Days.Count; i++)
            {
                temporaryDictionaryOfDays.Add(Days.Keys.ToList()[i], Days.Values.ToList()[i]);
            }
            DataWriter.WriteConsultationsToFile(PathToNewFile, temporaryListOfConsultations, temporaryDictionaryOfDays);
            RemainingWorkCounter--;
            if (CheckedNum == 1)
            {
                e.Result = completionPercenrage[0];
            }                
            else if (CheckedNum == 2)
                e.Result = completionPercenrage[1];
            else
                e.Result = completionPercenrage[2];
        }
        private static void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value += Convert.ToInt32(e.Result.ToString());
            if (progressBar.Value == completionPercenrage[0])
            {
                DialogResult dialogResult = MessageBox.Show("Файлы сохранены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                    progressBar.Value = completionPercenrage[4];
            }
        }


        private static void BackgroundWorker3_1_DoWork(object sender, DoWorkEventArgs e)
        {
            ConsultationForJSON.WriteToJSON(settings.JsonPathString, $@"{Teacher}.json", new ConsultationForJSON(Teacher, Consultations));
            RemainingWorkCounter--;
            if (CheckedNum == 1)
                e.Result = completionPercenrage[0];
            else if (CheckedNum == 2)
                e.Result = completionPercenrage[1];
            else
                e.Result = completionPercenrage[3];
        }
        private static void BackgroundWorker3_1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value += Convert.ToInt32(e.Result.ToString());
            if (progressBar.Value == completionPercenrage[0])
            {
                DialogResult dialogResult = MessageBox.Show("Файлы сохранены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                    progressBar.Value = completionPercenrage[4];
            }
        }

        private static void BackgroundWorker3_2_DoWork(object sender, DoWorkEventArgs e)
        {
            ConsultationForJSON.WriteToJSON(PathToNewFile, $@"{Teacher}.json", new ConsultationForJSON(Teacher, Consultations));
            RemainingWorkCounter--;
            if (CheckedNum == 1)
                e.Result = completionPercenrage[0];
            else if (CheckedNum == 2)
                e.Result = completionPercenrage[1];
            else
                e.Result = completionPercenrage[3];
        }
        private static void BackgroundWorker3_2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value += Convert.ToInt32(e.Result.ToString());
            if (progressBar.Value == completionPercenrage[0])
            {
                DialogResult dialogResult = MessageBox.Show("Файлы сохранены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                    progressBar.Value = completionPercenrage[4];
            }
        }
    }
}
