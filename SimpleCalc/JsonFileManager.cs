using System.Collections;
using CsvHelper.Configuration;
using CsvHelper;
using System.IO;
using System.Text;
using System.Windows;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;
using System;



namespace SimpleCalc;

public class JsonFileManager : IFileManager
{
    /// <inheritdoc />
    public async Task SaveFile(string filePath, IEnumerable<CalculationHistory> items)
    {
        try
        {
            var records = items.Select(item => item as CalculationHistory).ToList();

            var json = JsonConvert.SerializeObject(records, Formatting.Indented);
            await File.WriteAllTextAsync(filePath, json, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            // GUIでの通知はここでやるべきではない(イベントハンドラー内などが良い)
            MessageBox.Show("Error saving file: " + ex.Message);
        }

    }

    /// <inheritdoc />
    public async Task LoadFile(string filePath, ICollection<CalculationHistory> items)
    {
        try
        {
            var json = await File.ReadAllTextAsync(filePath);
             var records = JsonConvert.DeserializeObject<List<CalculationHistory>>(json) ?? [];


            // ListBox にデータを追加
            foreach (var record in records)
            {
                items.Add(record);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error load file: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}