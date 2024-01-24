using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;

namespace Aist.TypesOfData
{
    public class Consultation
    {
        public int Day { get; set; }
        public string Date { get; set; }
        public int SubjPos { get; set; }
        public string Teacher { get; set; }
        public string ScienceRoom { get; set; }
        public string Group { get; set; }
    }
    public class ConsultationForJSON
    {
        public string Teacher { get; set; }
        public List<Consultation> Consultations { get; set; }
        public ConsultationForJSON(string teacher, List<Consultation> consultations)
        {
            Teacher = teacher;
            Consultations = consultations;
        }

        public static void WriteToJSON(string filePath, string fileName, ConsultationForJSON consultationForJSON)
        {
            filePath = filePath + @"\" + fileName + ".json";
            File.Create(filePath).Close();
            var serializedelements = JsonSerializer.Serialize(
                consultationForJSON,
                typeof(ConsultationForJSON),
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(filePath, serializedelements);
        }
    }
}
