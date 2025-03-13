namespace SimpleCalc;

public interface IFileManager
{
    /// <summary>
    /// ファイルに保存
    /// </summary>
    /// <param name="filePath">保存先のパス</param>
    /// <param name="items">保存の内容</param>
    Task SaveFile(string filePath, IEnumerable<CalculationHistory> items);

    // 引数のコレクションを操作するのではなく、読み込んだコレクションを返却するほうがより適切な形式になる。
    // 非同期メソッドでTaskを返り値とする場合はTask<T>という形でオブジェクトを返却することができる。
    /// <summary>
    /// ファイルからの読み込み
    /// </summary>
    /// <param name="filePath">読み込み先のパス</param>
    /// <param name="items">読み込んだ内容の格納先</param>
    Task LoadFile(string filePath, ICollection<CalculationHistory> items);
}