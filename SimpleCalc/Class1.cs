namespace SimpleCalc;

public class Class1
{
    public string FirstNum { get; set; }





    private string _backingField;

    public string GetBackingField()
    {
        return this._backingField;
    }

    public void SetBackingFiled(string value)
    {
        this._backingField = value;
    }
}