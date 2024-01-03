using Aist.TypesOfData;

namespace Aist
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public List<Consultation> consultations = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.settingsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.jsonSettingsPanel = new System.Windows.Forms.Panel();
            this.pathToJsonViewButton = new System.Windows.Forms.Button();
            this.pathToJsonLabel = new System.Windows.Forms.Label();
            this.pathToJsonTextBox = new System.Windows.Forms.TextBox();
            this.jsonSaveLocationRadioButton2 = new System.Windows.Forms.RadioButton();
            this.jsonSaveLocationRadioButton1 = new System.Windows.Forms.RadioButton();
            this.jsonSaveLocationLabel = new System.Windows.Forms.Label();
            this.scheduleFormatPanel = new System.Windows.Forms.Panel();
            this.scheduleConsultationsOnWeekendsCheckBox = new System.Windows.Forms.CheckBox();
            this.scheduleFormatRadioButton2 = new System.Windows.Forms.RadioButton();
            this.scheduleFormatRadioButton1 = new System.Windows.Forms.RadioButton();
            this.scheduleFormatLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.settingsFlowLayoutPanel.SuspendLayout();
            this.jsonSettingsPanel.SuspendLayout();
            this.scheduleFormatPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsFlowLayoutPanel
            // 
            this.settingsFlowLayoutPanel.AutoScroll = true;
            this.settingsFlowLayoutPanel.Controls.Add(this.jsonSettingsPanel);
            this.settingsFlowLayoutPanel.Controls.Add(this.scheduleFormatPanel);
            this.settingsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.settingsFlowLayoutPanel.Name = "settingsFlowLayoutPanel";
            this.settingsFlowLayoutPanel.Size = new System.Drawing.Size(890, 498);
            this.settingsFlowLayoutPanel.TabIndex = 0;
            // 
            // jsonSettingsPanel
            // 
            this.jsonSettingsPanel.Controls.Add(this.pathToJsonViewButton);
            this.jsonSettingsPanel.Controls.Add(this.pathToJsonLabel);
            this.jsonSettingsPanel.Controls.Add(this.pathToJsonTextBox);
            this.jsonSettingsPanel.Controls.Add(this.jsonSaveLocationRadioButton2);
            this.jsonSettingsPanel.Controls.Add(this.jsonSaveLocationRadioButton1);
            this.jsonSettingsPanel.Controls.Add(this.jsonSaveLocationLabel);
            this.jsonSettingsPanel.Location = new System.Drawing.Point(3, 3);
            this.jsonSettingsPanel.Name = "jsonSettingsPanel";
            this.jsonSettingsPanel.Size = new System.Drawing.Size(880, 93);
            this.jsonSettingsPanel.TabIndex = 0;
            // 
            // pathToJsonViewButton
            // 
            this.pathToJsonViewButton.Location = new System.Drawing.Point(557, 62);
            this.pathToJsonViewButton.Name = "pathToJsonViewButton";
            this.pathToJsonViewButton.Size = new System.Drawing.Size(75, 23);
            this.pathToJsonViewButton.TabIndex = 5;
            this.pathToJsonViewButton.Text = "Обзор...";
            this.pathToJsonViewButton.UseVisualStyleBackColor = true;
            this.pathToJsonViewButton.Click += new System.EventHandler(this.pathToJsonViewButton_Click);
            // 
            // pathToJsonLabel
            // 
            this.pathToJsonLabel.AutoSize = true;
            this.pathToJsonLabel.Location = new System.Drawing.Point(3, 66);
            this.pathToJsonLabel.Name = "pathToJsonLabel";
            this.pathToJsonLabel.Size = new System.Drawing.Size(178, 15);
            this.pathToJsonLabel.TabIndex = 4;
            this.pathToJsonLabel.Text = "Путь к сохранению Json файла";
            // 
            // pathToJsonTextBox
            // 
            this.pathToJsonTextBox.Location = new System.Drawing.Point(187, 63);
            this.pathToJsonTextBox.Name = "pathToJsonTextBox";
            this.pathToJsonTextBox.Size = new System.Drawing.Size(364, 23);
            this.pathToJsonTextBox.TabIndex = 3;
            this.pathToJsonTextBox.Leave += new System.EventHandler(this.pathToJsonTextBox_Leave);
            // 
            // jsonSaveLocationRadioButton2
            // 
            this.jsonSaveLocationRadioButton2.AutoSize = true;
            this.jsonSaveLocationRadioButton2.Location = new System.Drawing.Point(12, 44);
            this.jsonSaveLocationRadioButton2.Name = "jsonSaveLocationRadioButton2";
            this.jsonSaveLocationRadioButton2.Size = new System.Drawing.Size(196, 19);
            this.jsonSaveLocationRadioButton2.TabIndex = 2;
            this.jsonSaveLocationRadioButton2.Text = "Сохранять по указанному пути";
            this.jsonSaveLocationRadioButton2.UseVisualStyleBackColor = true;
            // 
            // jsonSaveLocationRadioButton1
            // 
            this.jsonSaveLocationRadioButton1.AutoSize = true;
            this.jsonSaveLocationRadioButton1.Checked = true;
            this.jsonSaveLocationRadioButton1.Location = new System.Drawing.Point(12, 19);
            this.jsonSaveLocationRadioButton1.Name = "jsonSaveLocationRadioButton1";
            this.jsonSaveLocationRadioButton1.Size = new System.Drawing.Size(180, 19);
            this.jsonSaveLocationRadioButton1.TabIndex = 1;
            this.jsonSaveLocationRadioButton1.TabStop = true;
            this.jsonSaveLocationRadioButton1.Text = "Сохранять совместно с .doc";
            this.jsonSaveLocationRadioButton1.UseVisualStyleBackColor = true;
            this.jsonSaveLocationRadioButton1.CheckedChanged += new System.EventHandler(this.jsonSaveLocationRadioButton1_CheckedChanged);
            // 
            // jsonSaveLocationLabel
            // 
            this.jsonSaveLocationLabel.AutoSize = true;
            this.jsonSaveLocationLabel.Location = new System.Drawing.Point(3, 1);
            this.jsonSaveLocationLabel.Name = "jsonSaveLocationLabel";
            this.jsonSaveLocationLabel.Size = new System.Drawing.Size(174, 15);
            this.jsonSaveLocationLabel.TabIndex = 0;
            this.jsonSaveLocationLabel.Text = "Место сохранения Json файла";
            // 
            // scheduleFormatPanel
            // 
            this.scheduleFormatPanel.Controls.Add(this.scheduleConsultationsOnWeekendsCheckBox);
            this.scheduleFormatPanel.Controls.Add(this.scheduleFormatRadioButton2);
            this.scheduleFormatPanel.Controls.Add(this.scheduleFormatRadioButton1);
            this.scheduleFormatPanel.Controls.Add(this.scheduleFormatLabel);
            this.scheduleFormatPanel.Location = new System.Drawing.Point(3, 102);
            this.scheduleFormatPanel.Name = "scheduleFormatPanel";
            this.scheduleFormatPanel.Size = new System.Drawing.Size(880, 73);
            this.scheduleFormatPanel.TabIndex = 6;
            // 
            // scheduleConsultationsOnWeekendsCheckBox
            // 
            this.scheduleConsultationsOnWeekendsCheckBox.AutoSize = true;
            this.scheduleConsultationsOnWeekendsCheckBox.Location = new System.Drawing.Point(106, 45);
            this.scheduleConsultationsOnWeekendsCheckBox.Name = "scheduleConsultationsOnWeekendsCheckBox";
            this.scheduleConsultationsOnWeekendsCheckBox.Size = new System.Drawing.Size(224, 19);
            this.scheduleConsultationsOnWeekendsCheckBox.TabIndex = 4;
            this.scheduleConsultationsOnWeekendsCheckBox.Text = "Ставить консультации на выходных";
            this.scheduleConsultationsOnWeekendsCheckBox.UseVisualStyleBackColor = true;
            this.scheduleConsultationsOnWeekendsCheckBox.CheckedChanged += new System.EventHandler(this.scheduleConsultationsOnWeekendsCheckBox_CheckedChanged);
            // 
            // scheduleFormatRadioButton2
            // 
            this.scheduleFormatRadioButton2.AutoSize = true;
            this.scheduleFormatRadioButton2.Location = new System.Drawing.Point(12, 44);
            this.scheduleFormatRadioButton2.Name = "scheduleFormatRadioButton2";
            this.scheduleFormatRadioButton2.Size = new System.Drawing.Size(88, 19);
            this.scheduleFormatRadioButton2.TabIndex = 2;
            this.scheduleFormatRadioButton2.Text = "Недельный";
            this.scheduleFormatRadioButton2.UseVisualStyleBackColor = true;
            // 
            // scheduleFormatRadioButton1
            // 
            this.scheduleFormatRadioButton1.AutoSize = true;
            this.scheduleFormatRadioButton1.Checked = true;
            this.scheduleFormatRadioButton1.Location = new System.Drawing.Point(12, 19);
            this.scheduleFormatRadioButton1.Name = "scheduleFormatRadioButton1";
            this.scheduleFormatRadioButton1.Size = new System.Drawing.Size(82, 19);
            this.scheduleFormatRadioButton1.TabIndex = 1;
            this.scheduleFormatRadioButton1.TabStop = true;
            this.scheduleFormatRadioButton1.Text = "Исходный";
            this.scheduleFormatRadioButton1.UseVisualStyleBackColor = true;
            this.scheduleFormatRadioButton1.CheckedChanged += new System.EventHandler(this.scheduleFormatRadioButton1_CheckedChanged);
            // 
            // scheduleFormatLabel
            // 
            this.scheduleFormatLabel.AutoSize = true;
            this.scheduleFormatLabel.Location = new System.Drawing.Point(3, 1);
            this.scheduleFormatLabel.Name = "scheduleFormatLabel";
            this.scheduleFormatLabel.Size = new System.Drawing.Size(197, 15);
            this.scheduleFormatLabel.TabIndex = 0;
            this.scheduleFormatLabel.Text = "Формат визуализации расписания";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 498);
            this.Controls.Add(this.settingsFlowLayoutPanel);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.settingsFlowLayoutPanel.ResumeLayout(false);
            this.jsonSettingsPanel.ResumeLayout(false);
            this.jsonSettingsPanel.PerformLayout();
            this.scheduleFormatPanel.ResumeLayout(false);
            this.scheduleFormatPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel settingsFlowLayoutPanel;
        private Panel jsonSettingsPanel;
        private RadioButton jsonSaveLocationRadioButton2;
        private RadioButton jsonSaveLocationRadioButton1;
        private Label jsonSaveLocationLabel;
        private FolderBrowserDialog folderBrowserDialog;
        private Button pathToJsonViewButton;
        private Label pathToJsonLabel;
        private TextBox pathToJsonTextBox;
        private Panel scheduleFormatPanel;
        private RadioButton scheduleFormatRadioButton2;
        private RadioButton scheduleFormatRadioButton1;
        private Label scheduleFormatLabel;
        private CheckBox scheduleConsultationsOnWeekendsCheckBox;
    }
}