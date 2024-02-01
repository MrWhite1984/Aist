using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aist.TypesOfData;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Aist
{
    class DataReader
    {
        static Dictionary<int, string> daysOfTheWeek = new Dictionary<int, string>() { { 0, "пнд" }, { 1, "втр" }, { 2, "срд" }, { 3, "чтв" }, { 4, "птн" }, { 5, "сбт" }, { 6, "вск" } };
        public static List<string[]> ReadAllData(Worksheet ws)
        {
            int i = 7;
            List<string[]> data = new List<string[]>();
            while (ws.Cells[i, 8].Value != null)
            {
                string s1 = ws.Cells[i, 1].Value;
                string s2 = ws.Cells[i, 3].Value;
                string s3 = ws.Cells[i, 8].Value;
                string s4 = ws.Cells[i, 9].Value;
                string s5 = ws.Cells[i, 10].Value;
                string s6 = ws.Cells[i, 11].Value;
                string s7 = ws.Cells[i, 13].Value;
                string[] row = { s1, s2, s3, s4, s5, s6, s7 };
                data.Add(row);
                i++;
            }
            return data;
        }
        public static List<List<string[]>> DataByDays(List<string[]> ungroupedData)
        {
            List<List<string[]>> data = new List<List<string[]>>();
            List<string> datesInStringFormat = new();
            List<DateTime> dates = new();
            foreach(var item in ungroupedData)
            {
                if (!dates.Contains(Convert.ToDateTime(item[2]+ "." + DateTime.Now.Year.ToString())))
                {
                    dates.Add(Convert.ToDateTime(item[2] + "." + DateTime.Now.Year.ToString()));
                }
            }
            dates.Sort();
            foreach(var item in dates)
            {
                datesInStringFormat.Add(item.ToString("dd/MM/yyyy").Remove(5));
            }
            foreach(var dateItem in datesInStringFormat)
            {
                List<string[]> partOfData = ungroupedData.FindAll(item => item[2] == dateItem);
                data.Add(partOfData);
            }
            return data;
        }
        public static Dictionary<int, string> GetDateByCode(List<List<string[]>> data)
        {
            Dictionary<int, string> date = new Dictionary<int, string>();
            for (int i = 0; i < data.Count; i++)
            {
                date.Add(i, data[i][0][2]);
            }
            return date;
        }

        public static (List<string[]>, string, string) GetDataFromTxt(string filePath)
        {
            List<string[]> data = new List<string[]>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("WINDOWS-1251"));
            var dataFromTxt1251 = File.ReadAllLines(filePath);
            string[] dataFromTxt = new string[dataFromTxt1251.Length];
            for (int i = 0; i < dataFromTxt1251.Length; i++)
            {
                dataFromTxt[i] = reader.ReadLine();
            }
            reader.Close();
            string teacher = dataFromTxt[5].Split(' ', StringSplitOptions.RemoveEmptyEntries)[9] + " " + dataFromTxt[5].Split(' ', StringSplitOptions.RemoveEmptyEntries)[10];
            string department = dataFromTxt[5].Split(' ', StringSplitOptions.RemoveEmptyEntries)[11] + " " + dataFromTxt[5].Split(' ', StringSplitOptions.RemoveEmptyEntries)[12] + " " + dataFromTxt[5].Split(' ', StringSplitOptions.RemoveEmptyEntries)[13];
            for (int i = 14; i < dataFromTxt1251.Length; i++)
            {
                if (dataFromTxt[i].Split('¦', StringSplitOptions.RemoveEmptyEntries).Length == 6)
                {
                    string[] s = new string[7];
                    for (int j = 0; j < 7; j++)
                    {
                        if (j == 0)
                        {
                            var chunks = dataFromTxt[i].Split('¦', StringSplitOptions.RemoveEmptyEntries)[j].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                            if (chunks.Length > 1)
                            {
                                if (chunks[0] == "л." | chunks[0] == "лаб." | chunks[0] == "пр." | chunks[0] == "экз." | chunks[0] == "зач.")
                                {
                                    s[0] = chunks[0];
                                    j++;

                                    if (chunks.Length > 2)
                                    {
                                        s[1] = chunks[1];
                                        for (int k = 2; k < chunks.Length; k++)
                                        {
                                            s[1] = s[1] + " " + chunks[k];
                                        }
                                    }
                                    else
                                    {
                                        s[1] = chunks[1];
                                    }
                                }
                                else
                                {
                                    s[0] = "";
                                    s[1] = dataFromTxt[i].Split('¦', StringSplitOptions.RemoveEmptyEntries)[j];
                                }                                    
                            }
                        }
                        else
                        {
                            if (j == 3)
                            {
                                s[j] = dataFromTxt[i].Split('¦', StringSplitOptions.RemoveEmptyEntries)[j - 1].Trim(' ');
                            }
                            else
                            {
                                s[j] = dataFromTxt[i].Split('¦', StringSplitOptions.RemoveEmptyEntries)[j - 1];
                            }
                        }
                            
                    }
                    data.Add(s);
                }
            }
            return (data, teacher, department);
        }

        //public static List<List<string[]>> MergeData(List<List<string[]>> data1, List<List<string[]>> data2)
        //{
        //    List<List<string[]>> data = new List<List<string[]>>();
        //    List<List<string[]>> dataForReturn = new List<List<string[]>>();
        //    List<List<string[]>> ungroupedData = new List<List<string[]>>();
        //    ungroupedData.AddRange(data1);
        //    ungroupedData.AddRange(data2);
        //    List<DateTime> date = new List<DateTime>();
        //    foreach(var partOfData in ungroupedData)
        //    {
        //        date.Add(Convert.ToDateTime(partOfData[0][2] + "." + DateTime.Now.Year.ToString()));
        //        date.Sort();
        //    }
        //    List<string> dateString = new List<string>();
        //    foreach (var oneDate in date)
        //    {
        //        dateString.Add(oneDate.ToString("dd/MM/yyyy").Remove(5));
        //    }
        //    foreach (var oneDate in dateString)
        //    {
        //        foreach (var partOfData in ungroupedData)
        //        {
        //            if (oneDate.Equals(partOfData[0][2]))
        //            {
        //                data.Add(partOfData);
        //            }
        //        }
        //    }
        //    foreach (var partOfData in data)
        //    {
        //        Dictionary<int, string[]> subjects = new Dictionary<int, string[]>();
        //        List<string[]> day = new List<string[]>();
        //        foreach (var partOfData2 in partOfData)
        //        {
        //            switch (partOfData2[4])
        //            {
        //                case "08.20-09.50 ":
        //                    subjects.Add(1, partOfData2);
        //                    break;
        //                case "10.00-11.30 ":
        //                    subjects.Add(2, partOfData2);
        //                    break;
        //                case "11.40-13.10 ":
        //                    subjects.Add(3, partOfData2);
        //                    break;
        //                case "13.45-15.15 ":
        //                    subjects.Add(4, partOfData2);
        //                    break;
        //                case "15.25-16.55 ":
        //                    subjects.Add(5, partOfData2);
        //                    break;
        //                case "17.05-18.35 ":
        //                    subjects.Add(6, partOfData2);
        //                    break;
        //                case "18.40-20.10 ":
        //                    subjects.Add(7, partOfData2);
        //                    break;
        //                case "20.20-21.50 ":
        //                    subjects.Add(8, partOfData2);
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //        var keys = subjects.Keys.ToList();
        //        keys.Sort();
        //        foreach (var subject in keys)
        //        {
        //            day.Add(subjects[subject]);
        //        }
        //        dataForReturn.Add(day);
        //    }
        //    return dataForReturn;
        //}

        public static List<List<string[]>> MergeData(List<List<string[]>> data1, List<List<string[]>> data2)
        {
            List<List<string[]>> ungroupedDataInDayFormat = new List<List<string[]>>();
            List<List<string[]>> dataForReturn = new List<List<string[]>>();
            List<string[]> ungroupedData = new List<string[]>();
            List<string[]> dataToByDays = new List<string[]>();
            List<List<string[]>> data = new List<List<string[]>>();
            ungroupedDataInDayFormat.AddRange(data1);
            ungroupedDataInDayFormat.AddRange(data2);
            List<DateTime> date = new List<DateTime>();
            foreach (var item in ungroupedDataInDayFormat)
            {
                foreach(var partOfItem in item)
                {
                    ungroupedData.Add(partOfItem);
                }
            }
            foreach (var partOfData in ungroupedData)
            {
                if (!date.Contains(Convert.ToDateTime(partOfData[2] + "." + DateTime.Now.Year.ToString())))
                {
                    date.Add(Convert.ToDateTime(partOfData[2] + "." + DateTime.Now.Year.ToString()));
                }
                date.Sort();
            }
            List<string> dateString = new List<string>();
            foreach (var oneDate in date)
            {
                dateString.Add(oneDate.ToString("dd/MM/yyyy").Remove(5));
            }
            foreach (var oneDate in dateString)
            {
                foreach (var partOfData in ungroupedData)
                {
                    if (oneDate.Equals(partOfData[2]))
                    {
                        dataToByDays.Add(partOfData);
                    }
                }
            }
            data = DataByDays(dataToByDays);
            foreach (var partOfData in data)
            {
                Dictionary<int, string[]> subjects = new Dictionary<int, string[]>();
                List<string[]> day = new List<string[]>();
                try
                {
                    foreach (var partOfData2 in partOfData)
                    {
                        switch (partOfData2[4])
                        {
                            case "08.20-09.50 ":
                                subjects.Add(1, partOfData2);
                                break;
                            case "10.00-11.30 ":
                                subjects.Add(2, partOfData2);
                                break;
                            case "11.40-13.10 ":
                                subjects.Add(3, partOfData2);
                                break;
                            case "13.45-15.15 ":
                                subjects.Add(4, partOfData2);
                                break;
                            case "15.25-16.55 ":
                                subjects.Add(5, partOfData2);
                                break;
                            case "17.05-18.35 ":
                                subjects.Add(6, partOfData2);
                                break;
                            case "18.40-20.10 ":
                                subjects.Add(7, partOfData2);
                                break;
                            case "20.20-21.50 ":
                                subjects.Add(8, partOfData2);
                                break;
                            default:
                                break;
                        }
                    }
                }
                catch(Exception ex) { 
                MessageBox.Show(ex.Message);
                }
                var keys = subjects.Keys.ToList();
                keys.Sort();
                foreach (var subject in keys)
                {
                    day.Add(subjects[subject]);
                }
                dataForReturn.Add(day);
            }
            MessageBox.Show("");
            return dataForReturn;
        }

        public static List<List<string[]>> ConvertToWeeklyFormat(List<List<string[]>> data)
        {
            List<List<string[]>> dataInWeeklyFormat = new List<List<string[]>>();
            List<List<string[]>> dataCopy = new List<List<string[]>>();
            dataCopy.AddRange(data);
            int weekCounter = 0;
            while(data.Count != 0)
            {
                List <List<string[]>> dataForRemove = new List<List<string[]>>();
                string[] weekDays = new string[7];
                if (data[0][0][3] == "втp")
                {
                    data[0][0][3] = "втр";
                }
                else if(data[0][0][3] == "сpд")
                {
                    data[0][0][3] = "срд";
                }
                switch (data[0][0][3])
                {
                    case "пнд":
                        weekDays[0] = data[0][0][2];
                        weekDays[1] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(1).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[2] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(2).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[3] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(3).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[4] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(4).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[5] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(5).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[6] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(6).ToString("dd/MM/yyyy").Remove(5);
                        for (int i = 0; i < 7; i++)
                        {
                            bool flag = false;
                            foreach (var partOfData in dataCopy)
                            {
                                if (partOfData[0][2] == weekDays[i])
                                {
                                    dataInWeeklyFormat.Add(partOfData);
                                    dataForRemove.Add(partOfData);
                                    flag = true;
                                }
                            }
                            if (!flag)
                            {
                                List<string[]> dataDay = new List<string[]>();
                                dataDay.Add(new string[5] { "", "Выходной", weekDays[i], daysOfTheWeek[i], "08.20-09.50 " });
                                dataInWeeklyFormat.Add(dataDay);
                            }
                        }
                        break;
                    case "втр":
                        weekDays[1] = data[0][0][2];
                        weekDays[2] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(1).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[3] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(2).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[4] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(3).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[5] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(4).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[6] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(5).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[0] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-1).ToString("dd/MM/yyyy").Remove(5);
                        for (int i = 0; i < 7; i++)
                        {
                            bool flag = false;
                            foreach (var partOfData in dataCopy)
                            {
                                if (partOfData[0][2] == weekDays[i])
                                {
                                    dataInWeeklyFormat.Add(partOfData);
                                    dataForRemove.Add(partOfData);
                                    flag = true;
                                }
                            }
                            if (!flag)
                            {
                                List<string[]> dataDay = new List<string[]>();
                                dataDay.Add(new string[5] { "", "Выходной", weekDays[i], daysOfTheWeek[i], "08.20-09.50 " });
                                dataInWeeklyFormat.Add(dataDay);
                            }
                        }
                        break;
                    case "срд":
                        weekDays[2] = data[0][0][2];
                        weekDays[3] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(1).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[4] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(2).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[5] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(3).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[6] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(4).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[0] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-2).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[1] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-1).ToString("dd/MM/yyyy").Remove(5);
                        for (int i = 0; i < 7; i++)
                        {
                            bool flag = false;
                            foreach (var partOfData in dataCopy)
                            {
                                if (partOfData[0][2] == weekDays[i])
                                {
                                    dataInWeeklyFormat.Add(partOfData);
                                    dataForRemove.Add(partOfData);
                                    flag = true;
                                }
                            }
                            if (!flag)
                            {
                                List<string[]> dataDay = new List<string[]>();
                                dataDay.Add(new string[5] { "", "Выходной", weekDays[i], daysOfTheWeek[i], "08.20-09.50 " });
                                dataInWeeklyFormat.Add(dataDay);
                            }
                        }
                        break;
                    case "чтв":
                        weekDays[3] = data[0][0][2];
                        weekDays[4] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(1).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[5] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(2).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[6] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(3).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[0] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-3).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[1] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-2).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[2] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-1).ToString("dd/MM/yyyy").Remove(5);
                        for (int i = 0; i < 7; i++)
                        {
                            bool flag = false;
                            foreach (var partOfData in dataCopy)
                            {
                                if (partOfData[0][2] == weekDays[i])
                                {
                                    dataInWeeklyFormat.Add(partOfData);
                                    dataForRemove.Add(partOfData);
                                    flag = true;
                                }
                            }
                            if (!flag)
                            {
                                List<string[]> dataDay = new List<string[]>();
                                dataDay.Add(new string[5] { "", "Выходной", weekDays[i], daysOfTheWeek[i], "08.20-09.50 " });
                                dataInWeeklyFormat.Add(dataDay);
                            }
                        }
                        break;
                    case "птн":
                        weekDays[4] = data[0][0][2];
                        weekDays[5] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(1).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[6] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(2).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[0] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-4).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[1] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-3).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[2] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-2).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[3] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-1).ToString("dd/MM/yyyy").Remove(5);
                        for (int i = 0; i < 7; i++)
                        {
                            bool flag = false;
                            foreach (var partOfData in dataCopy)
                            {
                                if (partOfData[0][2] == weekDays[i])
                                {
                                    dataInWeeklyFormat.Add(partOfData);
                                    dataForRemove.Add(partOfData);
                                    flag = true;
                                }
                            }
                            if (!flag)
                            {
                                List<string[]> dataDay = new List<string[]>();
                                dataDay.Add(new string[5] { "", "Выходной", weekDays[i], daysOfTheWeek[i], "08.20-09.50 " });
                                dataInWeeklyFormat.Add(dataDay);
                            }
                        }
                        break;
                    case "сбт":
                        weekDays[5] = data[0][0][2];
                        weekDays[6] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(1).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[0] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-5).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[1] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-4).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[2] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-3).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[3] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-2).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[4] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-1).ToString("dd/MM/yyyy").Remove(5);
                        for (int i = 0; i < 7; i++)
                        {
                            bool flag = false;
                            foreach (var partOfData in dataCopy)
                            {
                                if (partOfData[0][2] == weekDays[i])
                                {
                                    dataInWeeklyFormat.Add(partOfData);
                                    dataForRemove.Add(partOfData);
                                    flag = true;
                                }
                            }
                            if (!flag)
                            {
                                List<string[]> dataDay = new List<string[]>();
                                dataDay.Add(new string[5] { "", "Выходной", weekDays[i], daysOfTheWeek[i], "08.20-09.50 " });
                                dataInWeeklyFormat.Add(dataDay);
                            }
                        }
                        break;
                    case "вск":
                        weekDays[6] = data[0][0][2];
                        weekDays[0] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-6).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[1] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-5).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[2] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-4).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[3] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-3).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[4] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-2).ToString("dd/MM/yyyy").Remove(5);
                        weekDays[5] = Convert.ToDateTime((data[0][0][2] + "." + DateTime.Now.Year)).AddDays(-1).ToString("dd/MM/yyyy").Remove(5);
                        for (int i = 0; i < 7; i++)
                        {
                            bool flag = false;
                            foreach (var partOfData in dataCopy)
                            {
                                if (partOfData[0][2] == weekDays[i])
                                {
                                    dataInWeeklyFormat.Add(partOfData);
                                    dataForRemove.Add(partOfData);
                                    flag = true;
                                }
                            }
                            if (!flag)
                            {
                                List<string[]> dataDay = new List<string[]>();
                                dataDay.Add(new string[5] { "", "Выходной", weekDays[i], daysOfTheWeek[i], "08.20-09.50 " });
                                dataInWeeklyFormat.Add(dataDay);
                            }
                        }
                        break;
                }
                foreach(var partOfData in dataForRemove)
                {
                    data.Remove(partOfData);
                }
            }
            return dataInWeeklyFormat;
        }
        public static List<List<string[]>> ConvertToNormalFormat(List<List<string[]>> data, List<Consultation> consultations)
        {
            List<string> consultationsDates = new List<string>();
            foreach (var consultation in consultations)
            {
                if (!consultationsDates.Contains(consultation.Date))
                {
                    consultationsDates.Add(consultation.Date);
                }
            }
            List < List<string[]> > dataCopy = new List<List<string[]>>();
            dataCopy.AddRange(data);
            foreach (var partOfData in dataCopy)
            {
                if (partOfData[0][1] == "Выходной" && !consultationsDates.Contains(partOfData[0][2]))
                    data.Remove(partOfData);
            }
            return data;
        }

        public static bool DataComparison(List<string[]> data1, List<string[]> data2)
        {
            if (data1.Count != data2.Count)
                return false;
            foreach(var item in data1)
            {
                if (!data2.Any(data2Item=> data2Item[2] == item[2] && data2Item[4] == item[4]))
                    return false;
            }
            return true;
        }
    }
}
