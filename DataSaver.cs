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
        public static event ProgressHandler? Notify;

        public event Action<int> ProgressChanged;

        static List<List<string[]>> FirstFileData;
        static List<Consultation> Consultations;
        static SaveForm SaveForm;
        static Dictionary<int, string> Days;
        static string PathToNewFile;
        //MainDelegateClean FLPClear,
        static string Teacher;
        static int CheckedNum;
        static Settings settings;
        static int RemainingWorkCounter;

        private static void OnProgressChanged(int progress)
        {
            progressBar.Value += progress;
        }

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
            SaveForm = saveForm;
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


            if (firstFileData.Count != 0 && consultations.Count != 0 && saveForm.scheduleCheckBox.Checked)
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

        private static void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Consultation> temporaryListOfConsultations = new List<Consultation>();
            temporaryListOfConsultations.AddRange(Consultations);
            Dictionary<int, string> temporaryDictionaryOfDays = new Dictionary<int, string>();
            for (int i = 0; i < Days.Count; i++)
            {
                temporaryDictionaryOfDays.Add(Days.Keys.ToList()[i], Days.Values.ToList()[i]);
            }
            List<List<string[]>> temporaryListOfFirstFileData = new List<List<string[]>>();
            temporaryListOfFirstFileData.AddRange(FirstFileData);
            DataWriter.SavingDataInScheduleFormat(PathToNewFile, temporaryListOfConsultations, temporaryDictionaryOfDays/*, FLPClear*/, temporaryListOfFirstFileData);
            RemainingWorkCounter--;
            if (CheckedNum == 1)
            {
                e.Result = 100;
            }
            else if (CheckedNum == 2)
                e.Result = 50;
            else
                e.Result = 33;
        }
        private static void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value += Convert.ToInt32(e.Result.ToString());
            if (progressBar.Value == 100)
            {
                DialogResult dialogResult = MessageBox.Show("Файлы сохранены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(dialogResult == DialogResult.OK)
                    progressBar.Value = 0;
            }
        }


        private static void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Consultation> temporaryListOfConsultations = new List<Consultation>();
            temporaryListOfConsultations.AddRange(Consultations);
            Dictionary<int, string> temporaryDictionaryOfDays = new Dictionary<int, string>();
            for (int i = 0; i < Days.Count; i++)
            {
                temporaryDictionaryOfDays.Add(Days.Keys.ToList()[i], Days.Values.ToList()[i]);
            }
            DataWriter.WriteConsultationsToFile(PathToNewFile, temporaryListOfConsultations, temporaryDictionaryOfDays/*, FLPClear*/);
            RemainingWorkCounter--;
            if (CheckedNum == 1)
            {
                e.Result = 100;
            }                
            else if (CheckedNum == 2)
                e.Result = 50;
            else
                e.Result = 33;
        }
        private static void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value += Convert.ToInt32(e.Result.ToString());
            if (progressBar.Value == 100)
            {
                DialogResult dialogResult = MessageBox.Show("Файлы сохранены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                    progressBar.Value = 0;
            }
        }


        private static void BackgroundWorker3_1_DoWork(object sender, DoWorkEventArgs e)
        {
            ConsultationForJSON.WriteToJSON(settings.JsonPathString, $@"{Teacher}.json", new ConsultationForJSON(Teacher, Consultations));
            RemainingWorkCounter--;
            if (CheckedNum == 1)
                e.Result = 100;
            else if (CheckedNum == 2)
                e.Result = 50;
            else
                e.Result = 34;
        }
        private static void BackgroundWorker3_1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value += Convert.ToInt32(e.Result.ToString());
            if (progressBar.Value == 100)
            {
                DialogResult dialogResult = MessageBox.Show("Файлы сохранены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                    progressBar.Value = 0;
            }
        }

        private static void BackgroundWorker3_2_DoWork(object sender, DoWorkEventArgs e)
        {
            ConsultationForJSON.WriteToJSON(PathToNewFile, $@"{Teacher}.json", new ConsultationForJSON(Teacher, Consultations));
            RemainingWorkCounter--;
            if (CheckedNum == 1)
                e.Result = 100;
            else if (CheckedNum == 2)
                e.Result = 50;
            else
                e.Result = 34;
        }
        private static void BackgroundWorker3_2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value += Convert.ToInt32(e.Result.ToString());
            if (progressBar.Value == 100)
            {
                DialogResult dialogResult = MessageBox.Show("Файлы сохранены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                    progressBar.Value = 0;
            }
        }
    }
}
