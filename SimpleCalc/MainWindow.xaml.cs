using System.Diagnostics;
using System.Formats.Asn1;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Win32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleCalc;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int ResultNum_int;
    private List<CalculationHistory> histories = new();

    public MainWindow()
    {
        InitializeComponent();
       
        CalcHistoryListBox.ItemsSource = histories;

        // DONE: コメントはコードとは別の行に記述してください。

        var items = new List<string> { "＋", "－", "×", "÷" }; 
        fourArithmeticOptsComboBox.ItemsSource = items;
    }
    private void NumericTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        // 数字(整数)だけを許可
        e.Handled = !IsNumeric(e.Text);
    }

    // DONE: summaryの内容を書いてください。
    /// <summary>
    /// 入力値が数値（整数）であるかどうかの結果を返却する。
    /// </summary>
    /// <param name="text">テキストボックス(firstNumericTextBox,secondNumericTextBox)に入力された文字列。</param>
    /// <returns>整数値→true,その他→false.</returns>
    private bool IsNumeric(string text)
    {
        // 数値だけ（整数）を許可
        // bool演算なので受け取った値が整数か否かを返却
        return text.All(Char.IsDigit);
    }



    private void Calc_Button(object sender, RoutedEventArgs e )
    {
        // DONE:処理をそのままなぞるだけのコメントは書かない
        // ソースコードから読み取れない実装意図などを記述してください。
        // TExtBoxはstring型でしか扱えないので、計算のために型を変換する。
        var firstNum = firstNumericTextBox.Text;   
        var secondNum = secondNumericTextBox.Text;　
        int firstNum_int, secondNum_int;  
        
        var fourArithmeticOpts = fourArithmeticOptsComboBox.Text;

        DateTime calculationTime = DateTime.Now;

        int.TryParse(firstNum, out firstNum_int);
        int.TryParse(secondNum, out secondNum_int);

        // DONE: 使用しない、しなくなったコードは消してください。

        //選択された演算子をインデックスではなく文字で判断。
        switch (fourArithmeticOpts)
        {
            case "＋":
                 ResultNum_int = firstNum_int + secondNum_int;
                break;
            case "－":
                 ResultNum_int = firstNum_int - secondNum_int;
                break;
            case "×":
                 ResultNum_int = firstNum_int * secondNum_int;
                break;
            case "÷":
                if (secondNum_int != 0)
                    ResultNum_int = firstNum_int / secondNum_int;
                else
                    MessageBox.Show("ゼロで割ることはできません");
                break;
        }

        //TextBoxへ計算結果を出力するためにResultNumをstringに変換
        ResultNumericTextBox.Text = ResultNum_int.ToString();

        

        var history = new CalculationHistory()
        {
            FirstNum = firstNum,
            SecondNum = secondNum,
            CalcDateTime = calculationTime,
            FourArithmeticOpts = fourArithmeticOpts,
            ResultNum = ResultNum_int,
        };
            histories.Add(history);
        CalcHistoryListBox.ItemsSource = null;
        CalcHistoryListBox.ItemsSource = histories;



    }

    private void SaveFileButton(object sender, RoutedEventArgs e)
    {

        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            // SaveFileDialog を使用して保存先を選択
            Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
        };

        // ダイアログを表示し、ユーザーが保存先を選択した場合
        if (saveFileDialog.ShowDialog() == true)
        {
            // ListBoxの内容をCSVファイルに保存
            string filePath = saveFileDialog.FileName;
            SaveCsvFile(filePath);
        }
    }



    // CSVファイルに内容を書き込むメソッド
    private void SaveCsvFile(string filePath)
    {
        try
        {

            {
                var records = new List<CalculationHistory>();
                foreach (var item in CalcHistoryListBox.Items)
                {
                    records.Add(item as CalculationHistory);
                }

                // CsvHelperを使用してリストをCSVに書き込む
                using (var writer = new StreamWriter(filePath))
                using (var csv = new CsvWriter(writer,
                           new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
                {
                    csv.WriteHeader<CalculationHistory>();
                    csv.NextRecord();
                    csv.WriteRecords(records);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error saving file: " + ex.Message);
        }
    }
}