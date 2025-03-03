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

        var items = new List<string> { "＋", "－", "×", "÷" }; //インデックスではなく文字で判断
        fourArithmeticOptsComboBox.ItemsSource = items;
    }
    private void NumericTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        // 数字(整数)だけを許可
        e.Handled = !IsNumeric(e.Text); 
    }

    /// <summary>
    /// test
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private bool IsNumeric(string text) 
    {
        // 数値だけ（整数）を許可 
        // bool演算なので受け取った値が整数か否かを返却
        return text.All(Char.IsDigit);
    }

  

    private void Calc_Button(object sender, RoutedEventArgs e )
    {
        var firstNum = firstNumericTextBox.Text;    //一つ目のTextBoxから文字列の読み込み
        var secondNum = secondNumericTextBox.Text;　//二つ目のTextBoxから文字列の読み込み
        int firstNum_int, econdNum_int;                   //intへ返還後の変数名
        var fourArithmeticOpts = fourArithmeticOptsComboBox.Text;  //ComboBoxから演算子を読み込む

        int.TryParse(firstNum, out firstNum_int);
        int.TryParse(secondNum, out econdNum_int);
        //fourArithmeticOptsComboBox

        
        switch (fourArithmeticOpts) //ComboBoxで選択された演算子を読み込み、caseで場合分けし、結果をResultNumに代入
        {
            case "＋":
                 ResultNum = firstNum_int + econdNum_int;
                break;
            case "－":
                 ResultNum = firstNum_int - econdNum_int;
                break;
            case "×":
                 ResultNum = firstNum_int * econdNum_int;
                break;
            case "÷":
                 ResultNum = firstNum_int / econdNum_int;
                break;
        }

        ResultNumericTextBox.Text = ResultNum.ToString(); //ResultNumをstringに変換し、ResultNumericTextBoxに出力させる

    }
}