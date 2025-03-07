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

    private string _temp1;
    public string Temp1
    {
        get
        {
            return this._temp1;
        }
        set
        {
            this._temp1 = value;
        }
    }

    private string _temp2;
    public string Temp2
    {
        get => this._temp2;
        set => this._temp2 = value;
    }

}