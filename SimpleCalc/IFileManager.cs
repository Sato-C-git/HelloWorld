namespace SimpleCalc;

public interface IFileManager
{
    /// <summary>
    /// ファイルに保存
    /// </summary>
    /// <param name="filePath">保存先のパス</param>
    /// <param name="items">保存の内容</param>
    void SaveFile(string filePath, IEnumerable<CalculationHistory> items);

    /// <summary>
    /// ファイルからの読み込み
    /// </summary>
    /// <param name="filePath">読み込み先のパス</param>
    /// <param name="items">読み込んだ内容の格納先</param>
    void LoadFile(string filePath, ICollection<CalculationHistory> items);
}