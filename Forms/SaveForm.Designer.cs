namespace Aist
{
    partial class SaveForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public int consultationsNum = 0;
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
            this.consultationsDocCheckBox = new System.Windows.Forms.CheckBox();
            this.consultationsJsonCheckBox = new System.Windows.Forms.CheckBox();
            this.scheduleCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // consultationsDocCheckBox
            // 
            this.consultationsDocCheckBox.AutoSize = true;
            this.consultationsDocCheckBox.Location = new System.Drawing.Point(12, 12);
            this.consultationsDocCheckBox.Name = "consultationsDocCheckBox";
            this.consultationsDocCheckBox.Size = new System.Drawing.Size(199, 19);
            this.consultationsDocCheckBox.TabIndex = 0;
            this.consultationsDocCheckBox.Text = "Сохранить \"Консультации.doc\"";
            this.consultationsDocCheckBox.UseVisualStyleBackColor = true;
            // 
            // consultationsJsonBheckBox
            // 
            this.consultationsJsonCheckBox.AutoSize = true;
            this.consultationsJsonCheckBox.Location = new System.Drawing.Point(12, 37);
            this.consultationsJsonCheckBox.Name = "consultationsJsonBheckBox";
            this.consultationsJsonCheckBox.Size = new System.Drawing.Size(201, 19);
            this.consultationsJsonCheckBox.TabIndex = 1;
            this.consultationsJsonCheckBox.Text = "Сохранить \"Консультации.json\"";
            this.consultationsJsonCheckBox.UseVisualStyleBackColor = true;
            // 
            // scheduleCheckBox
            // 
            this.scheduleCheckBox.AutoSize = true;
            this.scheduleCheckBox.Location = new System.Drawing.Point(12, 62);
            this.scheduleCheckBox.Name = "scheduleCheckBox";
            this.scheduleCheckBox.Size = new System.Drawing.Size(186, 19);
            this.scheduleCheckBox.TabIndex = 2;
            this.scheduleCheckBox.Text = "Сохранить \"Расписание.doc\"";
            this.scheduleCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(136, 87);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // SaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 122);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.scheduleCheckBox);
            this.Controls.Add(this.consultationsJsonCheckBox);
            this.Controls.Add(this.consultationsDocCheckBox);
            this.Name = "SaveForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сохранить как";
            this.Load += new System.EventHandler(this.SaveForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public CheckBox consultationsDocCheckBox;
        public CheckBox consultationsJsonCheckBox;
        public CheckBox scheduleCheckBox;
        private Button saveButton;
    }
}