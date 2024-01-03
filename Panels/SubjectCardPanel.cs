using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aist.Panels
{
    public class SubjectCardPanel : Panel
    {
        public string Time { get; set; }
        public string Subject { get; set; }
        public string Teacher { get; set; }
        public string ScienceRoom { get; set; }
        public string Group { get; set; }
        public SubjectCardPanel(string time, string subject, string teacher, string scienceRoom, string group)
        {
            Time = time;
            Subject = subject;
            Teacher = teacher;
            ScienceRoom = scienceRoom;
            Group = group;
        }
        public static SubjectCardPanel AddSubjectCardPanel(string time, string subject, string teacher, string scienceRoom, int posX, int posY, string type, string group)
        {
            SubjectCardPanel subjectCardPanel = new SubjectCardPanel(time, subject, teacher, scienceRoom, group);
            // scienceRoomLabel
            Label scienceRoomLabel = new Label();
            scienceRoomLabel.AutoSize = true;
            scienceRoomLabel.Location = new Point(0, 75);
            scienceRoomLabel.Name = "scienceRoomLabel";
            scienceRoomLabel.Size = new Size(66, 15);
            scienceRoomLabel.TabIndex = 8;
            scienceRoomLabel.Text = scienceRoom;
            // 
            // teacherLabel
            // 
            Label teacherLabel = new Label();
            teacherLabel.AutoSize = true;
            teacherLabel.Location = new Point(0, 60);
            teacherLabel.Name = "teacherLabel";
            teacherLabel.Size = new Size(91, 15);
            teacherLabel.TabIndex = 7;
            teacherLabel.Text = teacher;
            // 
            // subjectLabel
            // 
            Label subjectLabel = new Label();
            subjectLabel.Dock = DockStyle.Top;
            subjectLabel.Location = new Point(0, 15);
            subjectLabel.Name = "subjectLabel";
            subjectLabel.Size = new Size(263, 45);
            subjectLabel.TabIndex = 3;
            subjectLabel.Text = type + " " + subject;
            // 
            // timeLabel
            // 
            Label timeLabel = new Label();
            timeLabel.Dock = DockStyle.Top;
            timeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            timeLabel.Location = new Point(0, 0);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(263, 15);
            timeLabel.TabIndex = 2;
            timeLabel.Text = time;
            timeLabel.TextAlign = ContentAlignment.TopCenter;

            // groupLabel
            // 
            Label groupLabel = new Label();
            groupLabel.AutoSize = true;
            groupLabel.Location = new Point(0, 90);
            groupLabel.Name = "groupLabel";
            groupLabel.Size = new Size(46, 15);
            groupLabel.TabIndex = 9;
            groupLabel.Text = group;

            // subjectCardPanel
            subjectCardPanel.Controls.Add(scienceRoomLabel);
            subjectCardPanel.Controls.Add(teacherLabel);
            subjectCardPanel.Controls.Add(subjectLabel);
            subjectCardPanel.Controls.Add(timeLabel);
            subjectCardPanel.Controls.Add(groupLabel);
            subjectCardPanel.Dock = DockStyle.None;
            subjectCardPanel.BorderStyle = BorderStyle.FixedSingle;
            subjectCardPanel.Location = new Point(posX, posY);
            subjectCardPanel.Name = "subjectCardPanel";
            subjectCardPanel.Size = new Size(263, 109);
            subjectCardPanel.TabIndex = 1;

            switch (type)
            {
                case "лаб.":
                    subjectCardPanel.BackColor = Color.FromArgb(192, 0, 192);
                    break;
                case "л.":
                    subjectCardPanel.BackColor = Color.Lime;
                    break;
                case "пр.":
                    subjectCardPanel.BackColor = Color.FromArgb(255, 128, 0);
                    break;
                case "экз.":
                    subjectCardPanel.BackColor = Color.DodgerBlue;
                    break;
                case "зач.":
                    subjectCardPanel.BackColor = Color.LightSeaGreen;
                    break;
                default:
                    subjectCardPanel.BackColor = Color.White;
                    break;
            }
            return subjectCardPanel;
        }
    }
}
