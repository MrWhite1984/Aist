using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aist.TypesOfData;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Aist.Panels
{
    public class DayCardPanel : Panel
    {
        public string Date { get; set; }
        public string DayOfTheWeek { get; set; }
        public string Teacher { get; set; }
        public List<string[]> partOfData { get; set; }

        public DayCardPanel(string date, string dayOfTheWeek, string teacher, List<string[]> partOfData)
        {
            Date = date;
            DayOfTheWeek = dayOfTheWeek;
            Teacher = teacher;
            this.partOfData = partOfData;
        }
        public static (DayCardPanel, HashTable) AddDayCardPanel(List<string[]> strings, string teacher, int day, MainDelegateRefresh del)
        {
            Settings settings = Settings.ImportSettings();
            Panel[] panels = new Panel[9];
            DayCardPanel dayCardPanel = new DayCardPanel(strings[0][2], strings[0][3], teacher, strings);
            Label dateLabel = new Label();
            dateLabel.Dock = DockStyle.Fill;
            dateLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dateLabel.Location = new Point(0, 0);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(263, 29);
            dateLabel.TabIndex = 0;
            dateLabel.Text = dayCardPanel.Date + " " + dayCardPanel.DayOfTheWeek;
            dateLabel.TextAlign = ContentAlignment.MiddleCenter;

            Panel datePanel = new Panel();
            datePanel.BackColor = SystemColors.ButtonHighlight;
            datePanel.Dock = DockStyle.Top;
            datePanel.Location = new Point(0, 0);
            datePanel.Name = "datePanel";
            datePanel.Size = new Size(263, 29);
            datePanel.TabIndex = 0;

            dayCardPanel.BackColor = SystemColors.ButtonHighlight;
            dayCardPanel.Controls.Add(datePanel);
            dayCardPanel.Location = new Point(13, 13);
            dayCardPanel.Name = "dayCardPanel";
            dayCardPanel.Padding = new Padding(0, 0, 0, 1);
            dayCardPanel.Size = new Size(263, 906);
            dayCardPanel.TabIndex = 0;
            List<bool> flags = new List<bool>() { false, false, false, false, false, false, false, false };
            if (strings[0][1] != "Выходной")
            {
                for (int i = 0; i < strings.Count; i++)
                {
                    string time = strings[i][4];
                    switch (time)
                    {
                        case "08.20-09.50 ":
                            panels[1] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 29, strings[i][0], strings[i][6]);
                            flags[0] = true;
                            break;
                        case "10.00-11.30 ":
                            panels[2] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 138, strings[i][0], strings[i][6]);
                            flags[1] = true;
                            break;
                        case "11.40-13.10 ":
                            panels[3] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 247, strings[i][0], strings[i][6]);
                            flags[2] = true;
                            break;
                        case "13.45-15.15 ":
                            panels[4] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 356, strings[i][0], strings[i][6]);
                            flags[3] = true;
                            break;
                        case "15.25-16.55 ":
                            panels[5] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 465, strings[i][0], strings[i][6]);
                            flags[4] = true;
                            break;
                        case "17.05-18.35 ":
                            panels[6] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 574, strings[i][0], strings[i][6]);
                            flags[5] = true;
                            break;
                        case "18.40-20.10 ":
                            panels[7] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 683, strings[i][0], strings[i][6]);
                            flags[6] = true;
                            break;
                        case "20.20-21.50 ":
                            panels[8] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 792, strings[i][0], strings[i][6]);
                            flags[7] = true;
                            break;
                    }
                }
            }
            HashTable hashTable = new HashTable();
            AddCardPanel addCardPanel = new AddCardPanel("", 0, 0);
            if (settings.Format == 1)
            {
                if (!settings.ScheduleConsultationsOnWeekends)
                {
                    if (strings[0][1] != "Выходной")
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    if (!flags[0])
                                    {
                                        var cardPanel = addCardPanel.addCardPanel("08.20-09.50 ", 0, 29, del);
                                        panels[1] = cardPanel.Item1;
                                        hashTable.Hashes.Add(cardPanel.Item2, (day, 0));
                                        flags[0] = true;
                                    }
                                    break;
                                case 1:
                                    if (!flags[1])
                                    {
                                        var cardPanel = addCardPanel.addCardPanel("10.00-11.30 ", 0, 138, del);
                                        panels[2] = cardPanel.Item1;
                                        hashTable.Hashes.Add(cardPanel.Item2, (day, 1));
                                        flags[1] = true;
                                    }
                                    break;
                                case 2:
                                    if (!flags[2])
                                    {
                                        var cardPanel = addCardPanel.addCardPanel("11.40-13.10 ", 0, 247, del);
                                        panels[3] = cardPanel.Item1;
                                        hashTable.Hashes.Add(cardPanel.Item2, (day, 2));
                                        flags[2] = true;
                                    }
                                    break;
                                case 3:
                                    if (!flags[3])
                                    {
                                        var cardPanel = addCardPanel.addCardPanel("13.45-15.15 ", 0, 356, del);
                                        panels[4] = cardPanel.Item1;
                                        hashTable.Hashes.Add(cardPanel.Item2, (day, 3));
                                        flags[3] = true;
                                    }
                                    break;
                                case 4:
                                    if (!flags[4])
                                    {
                                        var cardPanel = addCardPanel.addCardPanel("15.25-16.55 ", 0, 465, del);
                                        panels[5] = cardPanel.Item1;
                                        hashTable.Hashes.Add(cardPanel.Item2, (day, 4));
                                        flags[4] = true;
                                    }
                                    break;
                                case 5:
                                    if (!flags[5])
                                    {
                                        var cardPanel = addCardPanel.addCardPanel("17.05-18.35 ", 0, 574, del);
                                        panels[6] = cardPanel.Item1;
                                        hashTable.Hashes.Add(cardPanel.Item2, (day, 5));
                                        flags[5] = true;
                                    }
                                    break;
                                case 6:
                                    if (!flags[6])
                                    {
                                        var cardPanel = addCardPanel.addCardPanel("17.05-18.35 ", 0, 683, del);
                                        panels[7] = cardPanel.Item1;
                                        hashTable.Hashes.Add(cardPanel.Item2, (day, 6));
                                        flags[6] = true;
                                    }
                                    break;
                                case 7:
                                    if (!flags[7])
                                    {
                                        var cardPanel = addCardPanel.addCardPanel("20.20-21.50 ", 0, 792, del);
                                        panels[8] = cardPanel.Item1;
                                        hashTable.Hashes.Add(cardPanel.Item2, (day, 7));
                                        flags[7] = true;
                                    }
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 8; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                if (!flags[0])
                                {
                                    var cardPanel = addCardPanel.addCardPanel("08.20-09.50 ", 0, 29, del);
                                    panels[1] = cardPanel.Item1;
                                    hashTable.Hashes.Add(cardPanel.Item2, (day, 0));
                                    flags[0] = true;
                                }
                                break;
                            case 1:
                                if (!flags[1])
                                {
                                    var cardPanel = addCardPanel.addCardPanel("10.00-11.30 ", 0, 138, del);
                                    panels[2] = cardPanel.Item1;
                                    hashTable.Hashes.Add(cardPanel.Item2, (day, 1));
                                    flags[1] = true;
                                }
                                break;
                            case 2:
                                if (!flags[2])
                                {
                                    var cardPanel = addCardPanel.addCardPanel("11.40-13.10 ", 0, 247, del);
                                    panels[3] = cardPanel.Item1;
                                    hashTable.Hashes.Add(cardPanel.Item2, (day, 2));
                                    flags[2] = true;
                                }
                                break;
                            case 3:
                                if (!flags[3])
                                {
                                    var cardPanel = addCardPanel.addCardPanel("13.45-15.15 ", 0, 356, del);
                                    panels[4] = cardPanel.Item1;
                                    hashTable.Hashes.Add(cardPanel.Item2, (day, 3));
                                    flags[3] = true;
                                }
                                break;
                            case 4:
                                if (!flags[4])
                                {
                                    var cardPanel = addCardPanel.addCardPanel("15.25-16.55 ", 0, 465, del);
                                    panels[5] = cardPanel.Item1;
                                    hashTable.Hashes.Add(cardPanel.Item2, (day, 4));
                                    flags[4] = true;
                                }
                                break;
                            case 5:
                                if (!flags[5])
                                {
                                    var cardPanel = addCardPanel.addCardPanel("17.05-18.35 ", 0, 574, del);
                                    panels[6] = cardPanel.Item1;
                                    hashTable.Hashes.Add(cardPanel.Item2, (day, 5));
                                    flags[5] = true;
                                }
                                break;
                            case 6:
                                if (!flags[6])
                                {
                                    var cardPanel = addCardPanel.addCardPanel("18.40-20.10 ", 0, 683, del);
                                    panels[7] = cardPanel.Item1;
                                    hashTable.Hashes.Add(cardPanel.Item2, (day, 6));
                                    flags[6] = true;
                                }
                                break;
                            case 7:
                                if (!flags[7])
                                {
                                    var cardPanel = addCardPanel.addCardPanel("20.20-21.50 ", 0, 792, del);
                                    panels[8] = cardPanel.Item1;
                                    hashTable.Hashes.Add(cardPanel.Item2, (day, 7));
                                    flags[7] = true;
                                }
                                break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    switch (i)
                    {
                        case 0:
                            if (!flags[0])
                            {
                                var cardPanel = addCardPanel.addCardPanel("08.20-09.50 ", 0, 29, del);
                                panels[1] = cardPanel.Item1;
                                hashTable.Hashes.Add(cardPanel.Item2, (day, 0));
                                flags[0] = true;
                            }
                            break;
                        case 1:
                            if (!flags[1])
                            {
                                var cardPanel = addCardPanel.addCardPanel("10.00-11.30 ", 0, 138, del);
                                panels[2] = cardPanel.Item1;
                                hashTable.Hashes.Add(cardPanel.Item2, (day, 1));
                                flags[1] = true;
                            }
                            break;
                        case 2:
                            if (!flags[2])
                            {
                                var cardPanel = addCardPanel.addCardPanel("11.40-13.10 ", 0, 247, del);
                                panels[3] = cardPanel.Item1;
                                hashTable.Hashes.Add(cardPanel.Item2, (day, 2));
                                flags[2] = true;
                            }
                            break;
                        case 3:
                            if (!flags[3])
                            {
                                var cardPanel = addCardPanel.addCardPanel("13.45-15.15 ", 0, 356, del);
                                panels[4] = cardPanel.Item1;
                                hashTable.Hashes.Add(cardPanel.Item2, (day, 3));
                                flags[3] = true;
                            }
                            break;
                        case 4:
                            if (!flags[4])
                            {
                                var cardPanel = addCardPanel.addCardPanel("15.25-16.55 ", 0, 465, del);
                                panels[5] = cardPanel.Item1;
                                hashTable.Hashes.Add(cardPanel.Item2, (day, 4));
                                flags[4] = true;
                            }
                            break;
                        case 5:
                            if (!flags[5])
                            {
                                var cardPanel = addCardPanel.addCardPanel("17.05-18.35 ", 0, 574, del);
                                panels[6] = cardPanel.Item1;
                                hashTable.Hashes.Add(cardPanel.Item2, (day, 5));
                                flags[5] = true;
                            }
                            break;
                        case 6:
                            if (!flags[6])
                            {
                                var cardPanel = addCardPanel.addCardPanel("18.40-20.10 ", 0, 683, del);
                                panels[7] = cardPanel.Item1;
                                hashTable.Hashes.Add(cardPanel.Item2, (day, 6));
                                flags[6] = true;
                            }
                            break;
                        case 7:
                            if (!flags[7])
                            {
                                var cardPanel = addCardPanel.addCardPanel("20.20-21.50 ", 0, 792, del);
                                panels[8] = cardPanel.Item1;
                                hashTable.Hashes.Add(cardPanel.Item2, (day, 7));
                                flags[7] = true;
                            }
                            break;
                    }
                }
            }
            datePanel.Controls.Add(dateLabel);
            dayCardPanel.Controls.AddRange(panels);
            return (dayCardPanel, hashTable);
        }

        public static (DayCardPanel, HashTable) AddDayCardPanelWithSkipPanel(List<string[]> strings, string teacher, int day, MainDelegateRefresh del, List<int> skipPanel)
        {
            Panel[] panels = new Panel[9];
            DayCardPanel dayCardPanel = new DayCardPanel(strings[0][2], strings[0][3], teacher, strings);
            Label dateLabel = new Label();
            dateLabel.Dock = DockStyle.Fill;
            dateLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dateLabel.Location = new Point(0, 0);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(263, 29);
            dateLabel.TabIndex = 0;
            dateLabel.Text = dayCardPanel.Date + " " + dayCardPanel.DayOfTheWeek;
            dateLabel.TextAlign = ContentAlignment.MiddleCenter;

            Panel datePanel = new Panel();
            datePanel.BackColor = SystemColors.ButtonHighlight;
            datePanel.Dock = DockStyle.Top;
            datePanel.Location = new Point(0, 0);
            datePanel.Name = "datePanel";
            datePanel.Size = new Size(263, 29);
            datePanel.TabIndex = 0;

            dayCardPanel.BackColor = SystemColors.ButtonHighlight;
            dayCardPanel.Controls.Add(datePanel);
            dayCardPanel.Location = new Point(13, 13);
            dayCardPanel.Name = "dayCardPanel";
            dayCardPanel.Padding = new Padding(0, 0, 0, 1);
            dayCardPanel.Size = new Size(263, 906);
            dayCardPanel.TabIndex = 0;
            List<bool> flags = new List<bool>() { false, false, false, false, false, false, false, false };
            for (int i = 0; i < strings.Count; i++)
            {
                if (strings[i][1] != "Выходной")
                {
                    string time = strings[i][4];
                    switch (time)
                    {
                        case "08.20-09.50 ":
                            panels[1] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 29, strings[i][0], strings[i][6]);
                            flags[0] = true;
                            break;
                        case "10.00-11.30 ":
                            panels[2] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 138, strings[i][0], strings[i][6]);
                            flags[1] = true;
                            break;
                        case "11.40-13.10 ":
                            panels[3] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 247, strings[i][0], strings[i][6]);
                            flags[2] = true;
                            break;
                        case "13.45-15.15 ":
                            panels[4] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 356, strings[i][0], strings[i][6]);
                            flags[3] = true;
                            break;
                        case "15.25-16.55 ":
                            panels[5] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 465, strings[i][0], strings[i][6]);
                            flags[4] = true;
                            break;
                        case "17.05-18.35 ":
                            panels[6] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 574, strings[i][0], strings[i][6]);
                            flags[5] = true;
                            break;
                        case "18.40-20.10 ":
                            panels[7] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 683, strings[i][0], strings[i][6]);
                            flags[6] = true;
                            break;
                        case "20.20-21.50 ":
                            panels[8] = SubjectCardPanel.AddSubjectCardPanel(strings[i][4], strings[i][1], dayCardPanel.Teacher, strings[i][5], 0, 792, strings[i][0], strings[i][6]);
                            flags[7] = true;
                            break;
                    }
                }
            }
            HashTable hashTable = new HashTable();
            AddCardPanel addCardPanel = new AddCardPanel("", 0, 0);
            for (int i = 0; i < 8; i++)
            {
                switch (i)
                {
                    case 0:
                        if (!flags[0] && !skipPanel.Contains(0))
                        {
                            var cardPanel = addCardPanel.addCardPanel("08.20-09.50 ", 0, 29, del);
                            panels[1] = cardPanel.Item1;
                            hashTable.Hashes.Add(cardPanel.Item2, (day, 0));
                            flags[0] = true;
                        }
                        break;
                    case 1:
                        if (!flags[1] && !skipPanel.Contains(1))
                        {
                            var cardPanel = addCardPanel.addCardPanel("10.00-11.30 ", 0, 138, del);
                            panels[2] = cardPanel.Item1;
                            hashTable.Hashes.Add(cardPanel.Item2, (day, 1));
                            flags[1] = true;
                        }
                        break;
                    case 2:
                        if (!flags[2] && !skipPanel.Contains(2))
                        {
                            var cardPanel = addCardPanel.addCardPanel("11.40-13.10 ", 0, 247, del);
                            panels[3] = cardPanel.Item1;
                            hashTable.Hashes.Add(cardPanel.Item2, (day, 2));
                            flags[2] = true;
                        }
                        break;
                    case 3:
                        if (!flags[3] && !skipPanel.Contains(3))
                        {
                            var cardPanel = addCardPanel.addCardPanel("13.45-15.15 ", 0, 356, del);
                            panels[4] = cardPanel.Item1;
                            hashTable.Hashes.Add(cardPanel.Item2, (day, 3));
                            flags[3] = true;
                        }
                        break;
                    case 4:
                        if (!flags[4] && !skipPanel.Contains(4))
                        {
                            var cardPanel = addCardPanel.addCardPanel("15.25-16.55 ", 0, 465, del);
                            panels[5] = cardPanel.Item1;
                            hashTable.Hashes.Add(cardPanel.Item2, (day, 4));
                            flags[4] = true;
                        }
                        break;
                    case 5:
                        if (!flags[5] && !skipPanel.Contains(5))
                        {
                            var cardPanel = addCardPanel.addCardPanel("17.05-18.35 ", 0, 574, del);
                            panels[6] = cardPanel.Item1;
                            hashTable.Hashes.Add(cardPanel.Item2, (day, 5));
                            flags[5] = true;
                        }
                        break;
                    case 6:
                        if (!flags[6] && !skipPanel.Contains(6))
                        {
                            var cardPanel = addCardPanel.addCardPanel("18.40-20.10 ", 0, 683, del);
                            panels[7] = cardPanel.Item1;
                            hashTable.Hashes.Add(cardPanel.Item2, (day, 6));
                            flags[6] = true;
                        }
                        break;
                    case 7:
                        if (!flags[7] && !skipPanel.Contains(7))
                        {
                            var cardPanel = addCardPanel.addCardPanel("20.20-21.50 ", 0, 792, del);
                            panels[8] = cardPanel.Item1;
                            hashTable.Hashes.Add(cardPanel.Item2, (day, 7));
                            flags[7] = true;
                        }
                        break;
                }
            }
            datePanel.Controls.Add(dateLabel);
            dayCardPanel.Controls.AddRange(panels);
            return (dayCardPanel, hashTable);
        }
    }
}
