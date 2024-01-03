using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aist.Panels
{
    class AddCardPanel : Panel
    {
        public string Time { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Button addButton { get; set; }
        public Label timeLabel { get; set; }
        AddCardPanel addPanel { get; set; }
        public AddCardPanel(string time, int posX, int posY)
        {
            Time = time;
            PosX = posX;
            PosY = posY;
        }

        public (AddCardPanel, int) addCardPanel(string time, int posX, int posY, MainDelegateRefresh del)
        {
            // 
            // addButton
            // 
            addButton = new Button();
            addButton.Location = new Point(0, 15);
            addButton.Name = "addButton" + posX + ";" + posY;
            addButton.Size = new Size(261, 92);
            addButton.TabIndex = 3;
            addButton.Text = "Добавить...";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += new EventHandler(del);
            // 
            // timeLabel
            // 
            timeLabel = new Label();
            timeLabel.Dock = DockStyle.Top;
            timeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            timeLabel.Location = new Point(0, 0);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(261, 15);
            timeLabel.TabIndex = 2;
            timeLabel.Text = time;
            timeLabel.TextAlign = ContentAlignment.TopCenter;
            // addPanel
            // 
            addPanel = new AddCardPanel(time, posX, posY);
            addPanel.BackColor = Color.White;
            addPanel.BorderStyle = BorderStyle.FixedSingle;
            addPanel.Controls.Add(addButton);
            addPanel.Controls.Add(timeLabel);
            addPanel.Dock = DockStyle.None;
            addPanel.Location = new Point(posX, posY);
            addPanel.Name = "addPanel";
            addPanel.Size = new Size(263, 109);
            addPanel.TabIndex = 6;

            return (addPanel, addButton.GetHashCode());
        }
        public (AddCardPanel, int) addCardPanelByCode(int code, MainDelegateRefresh del)
        {
            // 
            // addButton
            // 
            addButton = new Button();
            addButton.Location = new Point(0, 15);
            addButton.Name = "addButton";
            addButton.Size = new Size(261, 92);
            addButton.TabIndex = 3;
            addButton.Text = "Добавить...";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += new EventHandler(del);
            // 
            // timeLabel
            // 
            timeLabel = new Label();
            timeLabel.Dock = DockStyle.Top;
            timeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            timeLabel.Location = new Point(0, 0);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(261, 15);
            timeLabel.TabIndex = 2;
            switch (code)
            {
                case 0:
                    timeLabel.Text = "8.20-9.50";
                    break;
                case 1:
                    timeLabel.Text = "10.00-11.30";
                    break;
                case 2:
                    timeLabel.Text = "11.40-13.10";
                    break;
                case 3:
                    timeLabel.Text = "13.45-15.15";
                    break;
                case 4:
                    timeLabel.Text = "15.25-16.55";
                    break;
                case 5:
                    timeLabel.Text = "17.05-18.30";
                    break;
                case 6:
                    timeLabel.Text = "18.40-20.10";
                    break;
                case 7:
                    timeLabel.Text = "20.20-21.50";
                    break;
            }
            timeLabel.TextAlign = ContentAlignment.TopCenter;
            // addPanel
            // 
            addPanel = new AddCardPanel("", 0, 0);
            addPanel.BackColor = Color.White;
            addPanel.BorderStyle = BorderStyle.FixedSingle;
            addPanel.Controls.Add(addButton);
            addPanel.Controls.Add(timeLabel);
            addPanel.Dock = DockStyle.None;
            switch (code)
            {
                case 0:
                    addPanel.Location = new Point(0, 29);
                    break;
                case 1:
                    addPanel.Location = new Point(0, 138);
                    break;
                case 2:
                    addPanel.Location = new Point(0, 247);
                    break;
                case 3:
                    addPanel.Location = new Point(0, 356);
                    break;
                case 4:
                    addPanel.Location = new Point(0, 465);
                    break;
                case 5:
                    addPanel.Location = new Point(0, 574);
                    break;
                case 6:
                    addPanel.Location = new Point(0, 683);
                    break;
                case 7:
                    addPanel.Location = new Point(0, 792);
                    break;
            }
            addPanel.Name = "addPanel";
            addPanel.Size = new Size(263, 109);
            addPanel.TabIndex = 6;

            return (addPanel, addButton.GetHashCode());
        }

    }
}
