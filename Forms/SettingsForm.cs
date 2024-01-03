using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aist.TypesOfData;

namespace Aist
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Settings settings = Settings.ImportSettings();
            if (settings.JsonSaveLocationRadioButton == 0)
            {
                jsonSaveLocationRadioButton1.Checked = true;
                jsonSaveLocationRadioButton2.Checked = false;
            }
            else
            {
                jsonSaveLocationRadioButton1.Checked = false;
                jsonSaveLocationRadioButton2.Checked = true;
            }
            if (settings.JsonSaveLocationRadioButton == 1)
            {
                pathToJsonTextBox.Enabled = true;
                pathToJsonViewButton.Enabled = true;
                pathToJsonTextBox.Text = settings.JsonPathString;
            }
            else
            {
                pathToJsonTextBox.Enabled = false;
                pathToJsonViewButton.Enabled = false;
                pathToJsonTextBox.Text = "";
            }
            if (settings.Format == 0)
            {
                scheduleFormatRadioButton1.Checked = true;
                scheduleFormatRadioButton2.Checked = false;
                scheduleConsultationsOnWeekendsCheckBox.Enabled = false;
            }
            else
            {
                scheduleFormatRadioButton1.Checked = false;
                scheduleFormatRadioButton2.Checked = true;
                scheduleConsultationsOnWeekendsCheckBox.Enabled = true;
                scheduleConsultationsOnWeekendsCheckBox.Checked = settings.ScheduleConsultationsOnWeekends;
            }
        }

        private void jsonSaveLocationRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.ImportSettings();
            if (jsonSaveLocationRadioButton1.Checked)
            {                
                settings.JsonSaveLocationRadioButton = 0;
                Settings.SetSettings(settings);
                pathToJsonTextBox.Text = "";
                pathToJsonTextBox.Enabled = false;
                pathToJsonViewButton.Enabled = false;
            }
            else
            {
                settings.JsonSaveLocationRadioButton = 1;
                Settings.SetSettings(settings);
                pathToJsonTextBox.Enabled = true;
                pathToJsonViewButton.Enabled = true;
                pathToJsonTextBox.Text = settings.JsonPathString;
            }
        }

        private void pathToJsonTextBox_Leave(object sender, EventArgs e)
        {
            Settings settings = Settings.ImportSettings();
            if (File.Exists(pathToJsonTextBox.Text))
            {
                settings.JsonPathString = pathToJsonTextBox.Text;
                Settings.SetSettings(settings);
            }
            else
            {
                MessageBox.Show("Ошибка пути");
            }
        }

        private void pathToJsonViewButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            pathToJsonTextBox.Text = folderBrowserDialog.SelectedPath;
            Settings settings = Settings.ImportSettings();
            settings.JsonPathString = pathToJsonTextBox.Text;
            Settings.SetSettings(settings);
        }

        private void scheduleFormatRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.ImportSettings();
            if (scheduleFormatRadioButton1.Checked)
            {
                settings.Format = 0;
                scheduleConsultationsOnWeekendsCheckBox.Enabled = false;
                scheduleConsultationsOnWeekendsCheckBox.Checked = false;
                Settings.SetSettings(settings);
            }
            else
            {
                settings.Format = 1;
                scheduleConsultationsOnWeekendsCheckBox.Enabled = true;
                scheduleConsultationsOnWeekendsCheckBox.Checked = settings.ScheduleConsultationsOnWeekends;
                Settings.SetSettings(settings);
            }
        }

        private void scheduleConsultationsOnWeekendsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.ImportSettings();
            settings.ScheduleConsultationsOnWeekends = scheduleConsultationsOnWeekendsCheckBox.Checked;
            Settings.SetSettings(settings);
        }
    }
}
