﻿using System.Collections;
using CsvHelper.Configuration;
using CsvHelper;
using System.IO;
using System.Text;
using System.Windows;
using System.Globalization;

namespace SimpleCalc;

public class CsvFileManager : IFileManager
{
    /// <summary>
    /// CSVファイルに内容を書き込むメソッド
    /// </summary>
    /// <param name="filePath">保存先のパス</param>
    /// <param name="items">保存する値</param>
    public async Task SaveFile(string filePath, IEnumerable<CalculationHistory> items)
    {
        try
        {
            var records = items.Select(item => item as CalculationHistory).ToList();

            // CsvHelperを使用してリストをCSVに書き込む
            await using var writer = new StreamWriter(filePath, true, Encoding.UTF8);
            await using var csv = new CsvWriter(writer, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture));
            csv.WriteHeader<CalculationHistory>();
            await csv.NextRecordAsync();
            await csv.WriteRecordsAsync((IEnumerable)records);
            
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error saving file: " + ex.Message);
        }
    }


    /// <summary>
    /// CSVファイルの内容を読み込むメソッド
    /// </summary>
    /// <param name="filePath">読み込み元のパス</param>
    /// <param name="items">読み込む値</param>
    public async Task LoadFile(string filePath, ICollection<CalculationHistory> items)
    {
        try
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecordsAsync<CalculationHistory>();

            // ListBox にデータを追加
            await foreach (var record in records)
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