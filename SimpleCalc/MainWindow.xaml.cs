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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleCalc;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int ResultNum;

    public MainWindow()
    {
        InitializeComponent();

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

        int.TryParse(firstNum, out firstNum_int);
        int.TryParse(secondNum, out secondNum_int);

        // DONE: 使用しない、しなくなったコードは消してください。

        var instance = new Class1()
        {
            FirstNum = firstNum,
        };

        //選択された演算子をインデックスではなく文字で判断。
        switch (fourArithmeticOpts) 
        {
            case "＋":
                 ResultNum = firstNum_int + secondNum_int;
                break;
            case "－":
                 ResultNum = firstNum_int - secondNum_int;
                break;
            case "×":
                 ResultNum = firstNum_int * secondNum_int;
                break;
            case "÷":
                if (secondNum_int != 0)
                    ResultNum = firstNum_int / secondNum_int;
                else
                    MessageBox.Show("ゼロで割ることはできません");
                break;
        }

        //TextBoxへ計算結果を出力するためにResultNumをstringに変換
        ResultNumericTextBox.Text = ResultNum.ToString(); 

    }

}