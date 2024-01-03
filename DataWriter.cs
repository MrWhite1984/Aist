using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aist.TypesOfData;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;

namespace Aist
{
    class DataWriter
    {
        static Dictionary<int, string> times = new Dictionary<int, string>(){ { 0, "8.20-9.50" }, { 1, "10.00-11.30"}, { 2, "11.40-13.10" }, { 3, "13.45-15.15"}, { 4, "15.25-16.55" }, { 5, "17.05-18.30"}, { 6, "18.40-20.10" }, { 7, "20.20-21.50" } };
        public static void WriteConsultationsToFile(string path, List<Consultation> consultations, Dictionary<int, string> days, MainDelegateClean mainDelegateClean)
        {
            consultations = DataByDays(consultations);
            Application word = new Application();
            Document doc = word.Documents.Add();
            Microsoft.Office.Interop.Word.Range range = doc.Paragraphs[doc.Paragraphs.Count].Range;
            doc.Tables.Add(range, consultations.Count + 1, 3);
            doc.Tables[1].Cell(1, 1).Range.Text = "Преподаватель";
            doc.Tables[1].Cell(1, 2).Range.Text = "Дата/Время";
            doc.Tables[1].Cell(1, 3).Range.Text = "Аудитория";
            Table table = doc.Tables[1];
            int j = 2;
            for (int i = 0; i < consultations.Count; i++)
            {
                doc.Tables[1].Cell(j, 1).Range.Text = consultations[i].Teacher;
                doc.Tables[1].Cell(j, 2).Range.Text = consultations[i].Date + "/" + times[consultations[i].SubjPos];
                doc.Tables[1].Cell(j, 3).Range.Text = consultations[i].ScienceRoom;
                j++;
            }
            for (int i = 1; i < consultations.Count + 2; i++)
            {
                for (int f = 1; f < 4; f++)
                {
                    table.Cell(i, f).Range.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
                    table.Cell(i, f).Range.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleSingle;
                    table.Cell(i, f).Range.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
                    table.Cell(i, f).Range.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;
                }
            }
            doc.SaveAs(path + $@"\{consultations[0].Teacher}.doc");
            doc.Close();
            word.Quit();
            mainDelegateClean();
            MessageBox.Show($"Сохранено в файл: {consultations[0].Teacher}.doc");
        }
        public static List<Consultation> DataByDays(List<Consultation> ungroupedData)
        {
            List<int> daysForSort = new List<int>();
            foreach (Consultation consultation in ungroupedData)
            {
                daysForSort.Add(consultation.Day);
            }
            daysForSort.Sort();
            daysForSort = daysForSort.Distinct().ToList();
            List<Consultation> ungroupedDataWithSort = new List<Consultation>();
            foreach (int i in daysForSort)
            {
                foreach (Consultation consultation in ungroupedData)
                {
                    if (i == consultation.Day)
                        ungroupedDataWithSort.Add(consultation);
                }
            }
            ungroupedData.Clear();
            ungroupedData = ungroupedDataWithSort.ToList();
            ungroupedDataWithSort.Clear();
            List<List<Consultation>> data = new List<List<Consultation>>();
            List<Consultation> partOfData = new List<Consultation>();
            for (int i = 0; i < ungroupedData.Count; i++)
            {
                if (ungroupedData.Count != i + 1)
                {
                    if (ungroupedData[i].Day != ungroupedData[i + 1].Day)
                    {
                        partOfData.Add(ungroupedData[i]);
                        data.Add(partOfData);
                        partOfData = new List<Consultation>();
                    }
                    else
                    {
                        partOfData.Add(ungroupedData[i]);
                    }

                }
                else if(ungroupedData.Count != 1)
                {
                    if (ungroupedData[i].Day != ungroupedData[i - 1].Day)
                    {
                        partOfData.Add(ungroupedData[i]);
                        data.Add(partOfData);
                        partOfData = new List<Consultation>();
                    }
                    else
                    {
                        partOfData.Add(ungroupedData[i]);
                    }
                }
                else
                {
                    partOfData.Add(ungroupedData[0]);
                    data.Add(partOfData);
                    partOfData = new List<Consultation>();
                }
            }
            if (partOfData.Count != 0)
            {
                data.Add(partOfData);
            }
            List<Consultation> dataToReturn = new List<Consultation>();
            foreach (List<Consultation> dataDay in data)
            {
                daysForSort.Clear();
                foreach (Consultation consultation in dataDay)
                {
                    daysForSort.Add(consultation.SubjPos);
                }
                daysForSort.Sort();
                foreach (int i in daysForSort)
                {
                    foreach (Consultation consultation in dataDay)
                    {
                        if (i == consultation.SubjPos)
                            dataToReturn.Add(consultation);
                    }
                }
            }            
            return dataToReturn;
        }

        public static void SavingDataInScheduleFormat(string path, List<Consultation> consultations, Dictionary<int, string> days, MainDelegateClean mainDelegateClean, List<List<string[]>> data)
        {
            Application word = new Application();
            Document doc = word.Documents.Add();
            doc.Application.Selection.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            doc.Content.ParagraphFormat.LeftIndent = doc.Content.Application.CentimetersToPoints((float)1);
            doc.Content.ParagraphFormat.RightIndent = doc.Content.Application.CentimetersToPoints((float)1);


            if (Settings.ImportSettings().Format == 0)
            {
                int tableCount = 0;
                if (days.Count%7 == 0 && days.Count >= 7)
                {
                    tableCount = days.Count / 7;
                }
                else if (days.Count >= 7)
                {
                    tableCount = (days.Count / 7) + 1;
                }
                else
                {
                    tableCount = 1;
                }
                List<List<string[]>> dataForRemove = new List<List<string[]>>();
                for (int i = 0; i < tableCount; i++)
                {
                    Microsoft.Office.Interop.Word.Range range = doc.Paragraphs[doc.Paragraphs.Count].Range;
                    doc.Tables.Add(range, 9, 7);
                    doc.Words.Last.InsertBreak(WdBreakType.wdPageBreak);
                }
                for (int i = 1; i <= tableCount; i++)
                {
                    Table table = doc.Tables[i];
                    List<string> dateInWeek = new List<string>();
                    for (int j = 0; j < 7; j++)
                    {
                        if (data.Count != 0 && data.Count > j)
                        {
                            table.Cell(1, j + 1).Range.Text = data[j][0][2] + " " + data[j][0][3];
                            dateInWeek.Add(data[j][0][2]);
                            foreach (var partOfData in data[j])
                            {
                                switch (partOfData[4])
                                {
                                    case "08.20-09.50 ":
                                        table.Cell(2, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(2, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(2, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(2, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(2, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(2, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                    case "10.00-11.30 ":
                                        table.Cell(3, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(3, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(3, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(3, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(3, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(3, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                    case "11.40-13.10 ":
                                        table.Cell(4, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(4, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(4, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(4, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(4, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(4, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                    case "13.45-15.15 ":
                                        table.Cell(5, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(5, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(5, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(5, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(5, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(5, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                    case "15.25-16.55 ":
                                        table.Cell(6, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(6, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(6, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(6, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(6, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(6, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                    case "17.05-18.30 ":
                                        table.Cell(7, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(7, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(7, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(7, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(7, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(7, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                    case "18.40-20.10 ":
                                        table.Cell(8, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(8, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(8, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(8, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(8, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(8, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                    case "20.20-21.50 ":
                                        table.Cell(9, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(9, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(9, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(9, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(9, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(9, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                }
                            }
                            dataForRemove.Add(data[j]);
                        }
                    }
                    foreach (var partOfData in dataForRemove)
                    {
                        data.Remove(partOfData);
                    }
                    foreach (var consultation in consultations)
                    {
                        if (dateInWeek.Contains(consultation.Date))
                        {
                            Table openedTable = doc.Tables[consultation.Day / 7 + 1];
                            table.Cell(consultation.SubjPos + 2, consultation.Day % 7 + 1).Range.Text = times[consultation.SubjPos] + "\n" + "Консультация" + "\n" + consultation.Teacher + "\n" + consultation.ScienceRoom;
                            table.Cell(consultation.SubjPos + 2, consultation.Day % 7 + 1).Shading.BackgroundPatternColor = WdColor.wdColorYellow;
                        }
                    }
                    for (int k = 0; k < 10; k++)
                    {
                        for (int f = 0; f < 8; f++)
                        {
                            table.Cell(k, f).Range.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
                            table.Cell(k, f).Range.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleSingle;
                            table.Cell(k, f).Range.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
                            table.Cell(k, f).Range.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;
                        }
                    }
                }
            }
            else
            {
                int tableCount = days.Count / 7;
                List<List<string[]>> dataForRemove = new List<List<string[]>>();
                for (int i = 0; i < tableCount; i++)
                {
                    Microsoft.Office.Interop.Word.Range range = doc.Paragraphs[doc.Paragraphs.Count].Range;
                    doc.Tables.Add(range, 9, 7);
                    doc.Words.Last.InsertBreak(WdBreakType.wdPageBreak);
                }
                for (int i = 1; i <= tableCount; i++)
                {
                    Table table = doc.Tables[i];

                    List<string> dateInWeek = new List<string>();
                    for (int j = 0; j < 7; j++)
                    {
                        table.Cell(1, j + 1).Range.Text = data[j][0][2] + " " + data[j][0][3];
                        dateInWeek.Add(data[j][0][2]);
                        foreach (var partOfData in data[j])
                        {
                            if (partOfData[1] != "Выходной")
                            {
                                switch (partOfData[4])
                                {
                                    case "08.20-09.50 ":
                                        table.Cell(2, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(2, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(2, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(2, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(2, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(2, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                    case "10.00-11.30 ":
                                        table.Cell(3, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(3, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(3, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(3, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(3, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(3, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                    case "11.40-13.10 ":
                                        table.Cell(4, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(4, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(4, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(4, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(4, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(4, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                    case "13.45-15.15 ":
                                        table.Cell(5, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(5, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(5, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(5, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(5, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(5, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                    case "15.25-16.55 ":
                                        table.Cell(6, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(6, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(6, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(6, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(6, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(6, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                    case "17.05-18.30 ":
                                        table.Cell(7, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(7, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(7, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(7, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(7, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(7, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                    case "18.40-20.10 ":
                                        table.Cell(8, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(8, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(8, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(8, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(8, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(8, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                    case "20.20-21.50 ":
                                        table.Cell(9, j + 1).Range.Text = partOfData[4] + "\n" + partOfData[0] + " " + partOfData[1] + "\n" + partOfData[5] + "\n" + partOfData[6];
                                        switch (partOfData[0])
                                        {
                                            case "л.":
                                                table.Cell(9, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorBrightGreen;
                                                break;
                                            case "пр.":
                                                table.Cell(9, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorOrange;
                                                break;
                                            case "лаб.":
                                                table.Cell(9, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorViolet;
                                                break;
                                            case "экз.":
                                                table.Cell(9, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorLightBlue;
                                                break;
                                            case "зач.":
                                                table.Cell(9, j + 1).Shading.BackgroundPatternColor = WdColor.wdColorTurquoise;
                                                break;
                                        }
                                        break;
                                }
                            }
                        }
                        dataForRemove.Add(data[j]);
                    }
                    foreach (var partOfData in dataForRemove)
                    {
                        data.Remove(partOfData);
                    }
                    foreach (var consultation in consultations)
                    {
                        if (dateInWeek.Contains(consultation.Date))
                        {
                            Table openedTable = doc.Tables[consultation.Day / 7 + 1];
                            table.Cell(consultation.SubjPos + 2, consultation.Day % 7 + 1).Range.Text = times[consultation.SubjPos] + "\n" + "Консультация" + "\n" + consultation.Teacher + "\n" + consultation.ScienceRoom;
                            table.Cell(consultation.SubjPos + 2, consultation.Day % 7 + 1).Shading.BackgroundPatternColor = WdColor.wdColorYellow;
                        }
                    }
                    for (int k = 0; k < 10; k++)
                    {
                        for (int f = 0; f < 8; f++)
                        {
                            table.Cell(k, f).Range.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
                            table.Cell(k, f).Range.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleSingle;
                            table.Cell(k, f).Range.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
                            table.Cell(k, f).Range.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;
                        }
                    }
                }
            }
            doc.SaveAs(path + $@"\{consultations[0].Teacher} Расписание.doc");
            doc.Close();
            word.Quit();
            mainDelegateClean();
            MessageBox.Show($"Сохранено в файл: {consultations[0].Teacher} Расписание.doc");
        }
    }
}
