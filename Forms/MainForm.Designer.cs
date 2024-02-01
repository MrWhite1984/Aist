using Aist.Panels;
using Aist.TypesOfData;

namespace Aist
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public string path = "";
        public static Dictionary<int, string> days = new Dictionary<int, string>();
        public string teacher = "";
        public string department = "";
        public static HashTable hashes = new HashTable();
        public static List<DayCardPanel> cards = new List<DayCardPanel>();
        public static List<Consultation> consultations = new List<Consultation>();
        public static List<List<string[]>> dataForPrintingToScreen = new List<List<string[]>>();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.scheduleFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dayCardPanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.addPanel = new System.Windows.Forms.Panel();
            this.addButton = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.consultationPanel = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.consultationLabel = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.subjectCardPanel = new System.Windows.Forms.Panel();
            this.groupLabel = new System.Windows.Forms.Label();
            this.scienceRoomLabel = new System.Windows.Forms.Label();
            this.teacherLabel = new System.Windows.Forms.Label();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.datePanel = new System.Windows.Forms.Panel();
            this.dateLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ToolBarFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.openFileButton = new System.Windows.Forms.Button();
            this.AddFileButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.ToolBar = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.consultationIntNumLabel = new System.Windows.Forms.Label();
            this.consultationsNumLabel = new System.Windows.Forms.Label();
            this.scheduleFlowLayoutPanel.SuspendLayout();
            this.dayCardPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.addPanel.SuspendLayout();
            this.consultationPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.subjectCardPanel.SuspendLayout();
            this.datePanel.SuspendLayout();
            this.ToolBarFlowLayoutPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // scheduleFlowLayoutPanel
            // 
            this.scheduleFlowLayoutPanel.AutoScroll = true;
            this.scheduleFlowLayoutPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.scheduleFlowLayoutPanel.Controls.Add(this.dayCardPanel);
            this.scheduleFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.scheduleFlowLayoutPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scheduleFlowLayoutPanel.Location = new System.Drawing.Point(0, 30);
            this.scheduleFlowLayoutPanel.Name = "scheduleFlowLayoutPanel";
            this.scheduleFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 15);
            this.scheduleFlowLayoutPanel.Size = new System.Drawing.Size(1904, 948);
            this.scheduleFlowLayoutPanel.TabIndex = 1;
            // 
            // dayCardPanel
            // 
            this.dayCardPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dayCardPanel.Controls.Add(this.panel5);
            this.dayCardPanel.Controls.Add(this.panel4);
            this.dayCardPanel.Controls.Add(this.addPanel);
            this.dayCardPanel.Controls.Add(this.consultationPanel);
            this.dayCardPanel.Controls.Add(this.panel3);
            this.dayCardPanel.Controls.Add(this.panel2);
            this.dayCardPanel.Controls.Add(this.panel1);
            this.dayCardPanel.Controls.Add(this.subjectCardPanel);
            this.dayCardPanel.Controls.Add(this.datePanel);
            this.dayCardPanel.Location = new System.Drawing.Point(13, 13);
            this.dayCardPanel.Name = "dayCardPanel";
            this.dayCardPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.dayCardPanel.Size = new System.Drawing.Size(263, 906);
            this.dayCardPanel.TabIndex = 0;
            this.dayCardPanel.Visible = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.button2);
            this.panel5.Controls.Add(this.label21);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 792);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(263, 109);
            this.panel5.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(0, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(261, 92);
            this.button2.TabIndex = 3;
            this.button2.Text = "Добавить...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.Dock = System.Windows.Forms.DockStyle.Top;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label21.Location = new System.Drawing.Point(0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(261, 15);
            this.label21.TabIndex = 2;
            this.label21.Text = "Время";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 683);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(263, 109);
            this.panel4.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(0, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(261, 92);
            this.button1.TabIndex = 3;
            this.button1.Text = "Добавить...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(261, 15);
            this.label19.TabIndex = 2;
            this.label19.Text = "Время";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // addPanel
            // 
            this.addPanel.BackColor = System.Drawing.Color.White;
            this.addPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addPanel.Controls.Add(this.addButton);
            this.addPanel.Controls.Add(this.label25);
            this.addPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.addPanel.Location = new System.Drawing.Point(0, 574);
            this.addPanel.Name = "addPanel";
            this.addPanel.Size = new System.Drawing.Size(263, 109);
            this.addPanel.TabIndex = 6;
            // 
            // addButton
            // 
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addButton.Location = new System.Drawing.Point(0, 15);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(261, 92);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Добавить...";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.Dock = System.Windows.Forms.DockStyle.Top;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label25.Location = new System.Drawing.Point(0, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(261, 15);
            this.label25.TabIndex = 2;
            this.label25.Text = "Время";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // consultationPanel
            // 
            this.consultationPanel.BackColor = System.Drawing.Color.LightSeaGreen;
            this.consultationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consultationPanel.Controls.Add(this.deleteButton);
            this.consultationPanel.Controls.Add(this.label16);
            this.consultationPanel.Controls.Add(this.label17);
            this.consultationPanel.Controls.Add(this.label18);
            this.consultationPanel.Controls.Add(this.consultationLabel);
            this.consultationPanel.Controls.Add(this.label20);
            this.consultationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.consultationPanel.Location = new System.Drawing.Point(0, 465);
            this.consultationPanel.Name = "consultationPanel";
            this.consultationPanel.Size = new System.Drawing.Size(263, 109);
            this.consultationPanel.TabIndex = 5;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(233, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(25, 25);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(0, 90);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 15);
            this.label16.TabIndex = 9;
            this.label16.Text = "Группа";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(0, 75);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 15);
            this.label17.TabIndex = 8;
            this.label17.Text = "Аудитория";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(0, 60);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 15);
            this.label18.TabIndex = 7;
            this.label18.Text = "Преподаватель";
            // 
            // consultationLabel
            // 
            this.consultationLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.consultationLabel.Location = new System.Drawing.Point(0, 15);
            this.consultationLabel.Name = "consultationLabel";
            this.consultationLabel.Size = new System.Drawing.Size(261, 45);
            this.consultationLabel.TabIndex = 3;
            this.consultationLabel.Text = "Консультация";
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Top;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(261, 15);
            this.label20.TabIndex = 2;
            this.label20.Text = "Время";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 356);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(263, 109);
            this.panel3.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(0, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 15);
            this.label11.TabIndex = 9;
            this.label11.Text = "Группа";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(0, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 15);
            this.label12.TabIndex = 8;
            this.label12.Text = "Аудитория";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(0, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 15);
            this.label13.TabIndex = 7;
            this.label13.Text = "Преподаватель";
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Location = new System.Drawing.Point(0, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(261, 45);
            this.label14.TabIndex = 3;
            this.label14.Text = "Предмет";
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(261, 15);
            this.label15.TabIndex = 2;
            this.label15.Text = "Время";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 247);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(263, 109);
            this.panel2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Группа";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Аудитория";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Преподаватель";
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(261, 45);
            this.label9.TabIndex = 3;
            this.label9.Text = "Предмет";
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(261, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "Время";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 109);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Группа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Аудитория";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Преподаватель";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 45);
            this.label4.TabIndex = 3;
            this.label4.Text = "Предмет";
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(261, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Время";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // subjectCardPanel
            // 
            this.subjectCardPanel.BackColor = System.Drawing.Color.White;
            this.subjectCardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.subjectCardPanel.Controls.Add(this.groupLabel);
            this.subjectCardPanel.Controls.Add(this.scienceRoomLabel);
            this.subjectCardPanel.Controls.Add(this.teacherLabel);
            this.subjectCardPanel.Controls.Add(this.subjectLabel);
            this.subjectCardPanel.Controls.Add(this.timeLabel);
            this.subjectCardPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.subjectCardPanel.Location = new System.Drawing.Point(0, 29);
            this.subjectCardPanel.Name = "subjectCardPanel";
            this.subjectCardPanel.Size = new System.Drawing.Size(263, 109);
            this.subjectCardPanel.TabIndex = 1;
            // 
            // groupLabel
            // 
            this.groupLabel.AutoSize = true;
            this.groupLabel.Location = new System.Drawing.Point(0, 90);
            this.groupLabel.Name = "groupLabel";
            this.groupLabel.Size = new System.Drawing.Size(45, 15);
            this.groupLabel.TabIndex = 9;
            this.groupLabel.Text = "Группа";
            // 
            // scienceRoomLabel
            // 
            this.scienceRoomLabel.AutoSize = true;
            this.scienceRoomLabel.Location = new System.Drawing.Point(0, 75);
            this.scienceRoomLabel.Name = "scienceRoomLabel";
            this.scienceRoomLabel.Size = new System.Drawing.Size(69, 15);
            this.scienceRoomLabel.TabIndex = 8;
            this.scienceRoomLabel.Text = "Аудитория";
            // 
            // teacherLabel
            // 
            this.teacherLabel.AutoSize = true;
            this.teacherLabel.Location = new System.Drawing.Point(0, 60);
            this.teacherLabel.Name = "teacherLabel";
            this.teacherLabel.Size = new System.Drawing.Size(96, 15);
            this.teacherLabel.TabIndex = 7;
            this.teacherLabel.Text = "Преподаватель";
            // 
            // subjectLabel
            // 
            this.subjectLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.subjectLabel.Location = new System.Drawing.Point(0, 15);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(261, 45);
            this.subjectLabel.TabIndex = 3;
            this.subjectLabel.Text = "Предмет";
            // 
            // timeLabel
            // 
            this.timeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.timeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timeLabel.Location = new System.Drawing.Point(0, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(261, 15);
            this.timeLabel.TabIndex = 2;
            this.timeLabel.Text = "Время";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // datePanel
            // 
            this.datePanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.datePanel.Controls.Add(this.dateLabel);
            this.datePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.datePanel.Location = new System.Drawing.Point(0, 0);
            this.datePanel.Name = "datePanel";
            this.datePanel.Size = new System.Drawing.Size(263, 29);
            this.datePanel.TabIndex = 0;
            // 
            // dateLabel
            // 
            this.dateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dateLabel.Location = new System.Drawing.Point(0, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(263, 29);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Дата";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ToolBarFlowLayoutPanel
            // 
            this.ToolBarFlowLayoutPanel.Controls.Add(this.openFileButton);
            this.ToolBarFlowLayoutPanel.Controls.Add(this.AddFileButton);
            this.ToolBarFlowLayoutPanel.Controls.Add(this.settingsButton);
            this.ToolBarFlowLayoutPanel.Controls.Add(this.saveButton);
            this.ToolBarFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolBarFlowLayoutPanel.Name = "ToolBarFlowLayoutPanel";
            this.ToolBarFlowLayoutPanel.Size = new System.Drawing.Size(1904, 30);
            this.ToolBarFlowLayoutPanel.TabIndex = 3;
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(3, 3);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(75, 23);
            this.openFileButton.TabIndex = 1;
            this.openFileButton.Text = "Открыть...";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // AddFileButton
            // 
            this.AddFileButton.Location = new System.Drawing.Point(84, 3);
            this.AddFileButton.Name = "AddFileButton";
            this.AddFileButton.Size = new System.Drawing.Size(75, 23);
            this.AddFileButton.TabIndex = 2;
            this.AddFileButton.Text = "Добавить";
            this.AddFileButton.UseVisualStyleBackColor = true;
            this.AddFileButton.Click += new System.EventHandler(this.AddFileButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(165, 3);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(75, 23);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.Text = "Настройки...";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(246, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ToolBar
            // 
            this.ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(1904, 30);
            this.ToolBar.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.consultationIntNumLabel);
            this.panel6.Controls.Add(this.consultationsNumLabel);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 981);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1904, 30);
            this.panel6.TabIndex = 7;
            // 
            // consultationIntNumLabel
            // 
            this.consultationIntNumLabel.Location = new System.Drawing.Point(155, 6);
            this.consultationIntNumLabel.Name = "consultationIntNumLabel";
            this.consultationIntNumLabel.Size = new System.Drawing.Size(85, 15);
            this.consultationIntNumLabel.TabIndex = 2;
            this.consultationIntNumLabel.Text = "0";
            // 
            // consultationsNumLabel
            // 
            this.consultationsNumLabel.Location = new System.Drawing.Point(3, 6);
            this.consultationsNumLabel.Name = "consultationsNumLabel";
            this.consultationsNumLabel.Size = new System.Drawing.Size(156, 15);
            this.consultationsNumLabel.TabIndex = 1;
            this.consultationsNumLabel.Text = "Количество консультаций:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1011);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.ToolBarFlowLayoutPanel);
            this.Controls.Add(this.scheduleFlowLayoutPanel);
            this.Controls.Add(this.ToolBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1918, 1030);
            this.Name = "MainForm";
            this.Text = "Аист";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.scheduleFlowLayoutPanel.ResumeLayout(false);
            this.dayCardPanel.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.addPanel.ResumeLayout(false);
            this.consultationPanel.ResumeLayout(false);
            this.consultationPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.subjectCardPanel.ResumeLayout(false);
            this.subjectCardPanel.PerformLayout();
            this.datePanel.ResumeLayout(false);
            this.ToolBarFlowLayoutPanel.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private FlowLayoutPanel scheduleFlowLayoutPanel;
        private Panel dayCardPanel;
        private Panel subjectCardPanel;
        private Panel datePanel;
        private Label scienceRoomLabel;
        private Label teacherLabel;
        private Label subjectLabel;
        private Label timeLabel;
        private Label dateLabel;
        private Label groupLabel;
        private OpenFileDialog openFileDialog;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel addPanel;
        private Label label25;
        private Panel consultationPanel;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label consultationLabel;
        private Label label20;
        private Panel panel3;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Panel panel2;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button addButton;
        private Button deleteButton;
        private FolderBrowserDialog folderBrowserDialog;
        private FlowLayoutPanel ToolBarFlowLayoutPanel;
        private Button AddFileButton;
        private Button openFileButton;
        private Button saveButton;
        private Panel ToolBar;
        private Button settingsButton;
        private Panel panel5;
        private Button button2;
        private Label label21;
        private Panel panel4;
        private Button button1;
        private Label label19;
        private Panel panel6;
        private Label consultationIntNumLabel;
        private Label consultationsNumLabel;
    }
}