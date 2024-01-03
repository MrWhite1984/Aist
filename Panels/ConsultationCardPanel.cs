using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aist.TypesOfData;

namespace Aist.Panels
{
    class ConsultationCardPanel : Panel
    {
        public static (ConsultationCardPanel, int) createConsultationCardPanel(string teacher, int position, string group, string scienceRoom, MainDelegateDelete mainDelegateDelete)
        {
            //groupLabel
            //
            Label groupLabel = new Label();
            groupLabel.AutoSize = true;
            groupLabel.Location = new Point(0, 90);
            groupLabel.Name = "groupLabel";
            groupLabel.Size = new Size(45, 15);
            groupLabel.TabIndex = 9;
            groupLabel.Text = group;
            // deleteButton
            // 
            Button deleteButton = new Button();
            deleteButton.Location = new Point(233, 3);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(25, 25);
            deleteButton.TabIndex = 10;
            deleteButton.Text = "X";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += new EventHandler(mainDelegateDelete);
            // scienceRoomLabel
            // 
            Label scienceRoomLabel = new Label();
            scienceRoomLabel.AutoSize = true;
            scienceRoomLabel.Location = new Point(0, 75);
            scienceRoomLabel.Name = "scienceRoomLabel";
            scienceRoomLabel.Size = new Size(69, 15);
            scienceRoomLabel.TabIndex = 8;
            scienceRoomLabel.Text = scienceRoom;
            //teacherLabel
            //
            Label teacherLabel = new Label();
            teacherLabel.AutoSize = true;
            teacherLabel.Location = new Point(0, 60);
            teacherLabel.Name = "teacherLabel";
            teacherLabel.Size = new Size(96, 15);
            teacherLabel.TabIndex = 7;
            teacherLabel.Text = teacher;
            // consultationLabel
            // 
            Label consultationLabel = new Label();
            consultationLabel.Dock = DockStyle.Top;
            consultationLabel.Location = new Point(0, 15);
            consultationLabel.Name = "consultationLabel";
            consultationLabel.Size = new Size(261, 45);
            consultationLabel.TabIndex = 3;
            consultationLabel.Text = "Консультация";
            // timeLabel
            // 
            Label timeLabel = new Label();
            timeLabel.Dock = DockStyle.Top;
            timeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            timeLabel.Location = new Point(0, 0);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(261, 15);
            timeLabel.TabIndex = 2;
            switch (position)
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
            // consultationPanel
            // 
            ConsultationCardPanel consultationPanel = new ConsultationCardPanel();
            consultationPanel.BackColor = Color.Yellow;
            consultationPanel.BorderStyle = BorderStyle.FixedSingle;
            consultationPanel.Controls.Add(deleteButton);
            consultationPanel.Controls.Add(groupLabel);
            consultationPanel.Controls.Add(scienceRoomLabel);
            consultationPanel.Controls.Add(teacherLabel);
            consultationPanel.Controls.Add(consultationLabel);
            consultationPanel.Controls.Add(timeLabel);
            consultationPanel.Dock = DockStyle.None;
            switch (position)
            {
                case 0:
                    consultationPanel.Location = new Point(0, 29);
                    break;
                case 1:
                    consultationPanel.Location = new Point(0, 138);
                    break;
                case 2:
                    consultationPanel.Location = new Point(0, 247);
                    break;
                case 3:
                    consultationPanel.Location = new Point(0, 356);
                    break;
                case 4:
                    consultationPanel.Location = new Point(0, 465);
                    break;
                case 5:
                    consultationPanel.Location = new Point(0, 574);
                    break;
                case 6:
                    consultationPanel.Location = new Point(0, 683);
                    break;
                case 7:
                    consultationPanel.Location = new Point(0, 792);
                    break;
            }
            consultationPanel.Name = "consultationPanel";
            consultationPanel.Size = new Size(263, 109);
            consultationPanel.TabIndex = 5;

            return (consultationPanel, deleteButton.GetHashCode());
        }

        public static (List<DayCardPanel>, HashTable, List<Consultation>) AddConsultationCardPanel(List<DayCardPanel> cards, Consultation consultation, MainDelegateRefresh del, MainDelegateDelete mainDelegateDelete, List<Consultation> consultations)
        {
            consultations.Add(consultation);
            List<Consultation> consultsByDay = new List<Consultation>();
            foreach (var consult in consultations)
            {
                if (consult.Day == consultation.Day)
                {
                    consultsByDay.Add(consult);
                }
            }
            List<int> skipList = new List<int>();
            foreach (var consult in consultsByDay)
            {
                skipList.Add(consult.SubjPos);
            }
            var dayCardItems = DayCardPanel.AddDayCardPanelWithSkipPanel(cards[consultation.Day].partOfData, consultation.Teacher, consultation.Day, del, skipList);
            cards[consultation.Day] = dayCardItems.Item1;
            HashTable newHashTable = dayCardItems.Item2;
            foreach (var part in consultsByDay)
            {
                var items = createConsultationCardPanel(part.Teacher, part.SubjPos, part.Group, part.ScienceRoom, mainDelegateDelete);
                cards[part.Day].Controls.Add(items.Item1);
                newHashTable.Hashes.Add(items.Item2, (part.Day, part.SubjPos));
            }
            return (cards, newHashTable, consultations);
        }

        public static (List<DayCardPanel>, HashTable, List<Consultation>) DropConsultationCardPanel(List<DayCardPanel> cards, int day, int subjPos, MainDelegateRefresh del, MainDelegateDelete mainDelegateDelete, List<Consultation> consultations)
        {
            Consultation consultation = new Consultation();

            List<Consultation> consultsByDay = new List<Consultation>();
            foreach (var consult in consultations)
            {
                if (consult.Day == day)
                {
                    consultsByDay.Add(consult);
                }
            }
            foreach (var consult in consultsByDay)
            {
                if (consult.SubjPos == subjPos)
                    consultation = consult;
            }
            consultations.Remove(consultation);
            List<int> skipList = new List<int>();
            consultsByDay = new List<Consultation>();
            foreach (var consult in consultations)
            {
                if (consult.Day == day)
                {
                    consultsByDay.Add(consult);
                }
            }
            foreach (var consult in consultsByDay)
            {
                skipList.Add(consult.SubjPos);
            }
            var dayCardItems = DayCardPanel.AddDayCardPanelWithSkipPanel(cards[consultation.Day].partOfData, consultation.Teacher, consultation.Day, del, skipList);
            cards[consultation.Day] = dayCardItems.Item1;
            HashTable newHashTable = dayCardItems.Item2;
            foreach (var part in consultsByDay)
            {
                var items = createConsultationCardPanel(part.Teacher, part.SubjPos, part.Group, part.ScienceRoom, mainDelegateDelete);
                cards[part.Day].Controls.Add(items.Item1);
                newHashTable.Hashes.Add(items.Item2, (part.Day, part.SubjPos));
            }
            return (cards, newHashTable, consultations);
        }
        public static (List<DayCardPanel>, HashTable, List<Consultation>) AddConsultationCardPanelInRefresher(List<DayCardPanel> cards, Consultation consultation, MainDelegateRefresh del, MainDelegateDelete mainDelegateDelete, List<Consultation> consultations, List<List<string[]>> firstFileData)
        {
            consultations[consultations.IndexOf(consultation)].Day = GetNewConsultationDay(consultation, firstFileData);
            List<Consultation> consultsByDay = new List<Consultation>();
            consultation.Day = GetNewConsultationDay(consultation, firstFileData);
            foreach (var consult in consultations)
            {
                if (consult.Day == consultation.Day)
                {
                    consultsByDay.Add(consult);
                }
            }
            List<int> skipList = new List<int>();
            foreach (var consult in consultsByDay)
            {
                skipList.Add(consult.SubjPos);
            }
            var dayCardItems = DayCardPanel.AddDayCardPanelWithSkipPanel(cards[consultation.Day].partOfData, consultation.Teacher, consultation.Day, del, skipList);
            cards[consultation.Day] = dayCardItems.Item1;
            HashTable newHashTable = dayCardItems.Item2;
            foreach (var part in consultsByDay)
            {
                var items = createConsultationCardPanel(part.Teacher, part.SubjPos, part.Group, part.ScienceRoom, mainDelegateDelete);
                cards[part.Day].Controls.Add(items.Item1);
                newHashTable.Hashes.Add(items.Item2, (part.Day, part.SubjPos));
            }
            return (cards, newHashTable, consultations);
        }
        public static int GetNewConsultationDay(Consultation consultation, List<List<string[]>> firstFileData)
        {
            for (int i = 0; i < firstFileData.Count; i++)
            {
                if (firstFileData[i][0][2] == consultation.Date)
                    return i;
            }
            return -1;
        }
    }
}
