using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;

namespace Aist.TypesOfData
{
    class Settings
    {
        public string JsonPathString { get; set; }
        public int JsonSaveLocationRadioButton { get; set; }
        public int Format { get; set; }
        public bool ScheduleConsultationsOnWeekends { get; set; }
        public static Settings ImportSettings()
        {
            return JsonSerializer.Deserialize<Settings>(File.ReadAllText("Settings.json"));
        }
        public static void SetSettings(Settings settings)
        {
            string filePath = @"Settings.json";
            File.Create(filePath).Close();
            var serializedelements = JsonSerializer.Serialize(
                settings,
                typeof(Settings),
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(filePath, serializedelements);
        }

    }
}
