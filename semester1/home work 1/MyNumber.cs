using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.Encodings.Web;
using System.Threading.Tasks.Dataflow;
public class MyNumber {
    private int _value;
    public MyNumber()
    {
        _value = 0;
    }
    public MyNumber(int value)
    {
        if (CorectnessInputArabicNumber(value)) _value = value;
    }
    public MyNumber(string inputValue)
    {
        string value = CorectnessInputRomeNumber(inputValue);
        _value = TranslateToArabic(value);
    }
    public string RomeNumberPerformance
    {
        get => TranslateToRome();
        set => _value = TranslateToArabic(
            CorectnessInputRomeNumber(value));
    }
    public int ArabicNumberPerfomance
    {
        get => _value;
        set
        {
            if (CorectnessInputArabicNumber(value)) _value = value;
        }
    }
    static private Dictionary<int, string> ArabicToRomeTable
    = new Dictionary<int, string>
    {
        {1000,"M" },
        {900,"CM" },
        {500,"D" },
        {400,"CD" },
        {100,"C" },
        {90,"XC" },
        {50,"L" },
        {40,"XL" },
        {10,"X" },
        {9,"IX" },
        {5,"V" },
        {4,"IV" },
        {1,"I" }
    };
    static private List<int> ListKeysArabicToRomeTable
    = ArabicToRomeTable.Keys.ToList<int>();
    private string TranslateToRome()
    {
        string symbolOfNegativity = (_value<0) ?"-":"";   
        string romeNumber = "";
        int value = Math.Abs(_value);
        int len = ArabicToRomeTable.Count();
        for (int index = 0; index < len; index++)
        {
            while (value >= ListKeysArabicToRomeTable[index])
            {
                romeNumber += ArabicToRomeTable[
                    ListKeysArabicToRomeTable[index]];
                value -= ListKeysArabicToRomeTable[index];
            }
        }
        if (romeNumber == "") return "0";
        return symbolOfNegativity+romeNumber;
    }
    static private Dictionary<char, int> RomeToArabicTable
    = new Dictionary<char, int>
    {
        {'M',1000 },
        {'D',500 },
        {'C',100 },
        {'L',50 },
        {'X', 10},
        {'V', 5},
        {'I', 1},
        {'0', 0},
    };
    private static List<char> ListKeysRomeToArabicTable =
    RomeToArabicTable.Keys.ToList();
    private int TranslateToArabic(string romeNumber)
    {
        int symbolOfNegativity = 1;
        string romeValue = romeNumber.Replace(" ","");
        if (romeNumber[0] == '-')
        {
            symbolOfNegativity = -1;
            romeValue = romeNumber.Substring(1).Replace(" ","");
        }
        int arabicValue = 0;
        int prevValueChar = 0;
        int strSize = romeValue.Length;
        for (int index = 0; index < strSize; index++)
        {
            int thisValueChar = RomeToArabicTable[romeValue[strSize - 1 - index]];
            if (thisValueChar < prevValueChar)
            {
                arabicValue -= thisValueChar;
            }
            else
            {
                arabicValue += thisValueChar;
            }
            prevValueChar = thisValueChar;
        }
        return arabicValue*symbolOfNegativity;
    }
    private int TranslateToArabic()
    {
        return _value;
    }
    public override string ToString()
    {
        return $"Arabic number: {TranslateToArabic()}, Rome number: {TranslateToRome()}";
    }
    private static string CorectnessInputRomeNumber(string inputValue)
    {
        string value = inputValue.Replace(" ", "");
        for (int index = 0; index < value.Length; index++)
        {
            if (!(ListKeysRomeToArabicTable.Contains(value[index])) && (value[index] != '-'))
                throw new ArgumentException("НЕ известный символ,",
                " используете символы для обозначения римских чисел");
        }
        return value;
    }
    
    private static bool CorectnessInputArabicNumber (int value)
    {
        if (value < -4000 || value > 4000)
            throw new ArgumentException("Числа вне диапозона от -4000 до 4000");
        else return true;
    }
    public static MyNumber operator +(MyNumber n1, MyNumber n2)
    => new MyNumber(n1._value + n2._value);
    public static MyNumber operator -(MyNumber n1, MyNumber n2)
    => new MyNumber(n1._value - n2._value);
    public static MyNumber operator *(MyNumber n1, MyNumber n2)
    => new MyNumber(n1._value * n2._value);
    public static MyNumber operator /(MyNumber n1, MyNumber n2)
    => new MyNumber(n1._value / n2._value);
    public static bool operator ==(MyNumber n1, MyNumber n2)
    => n1.ArabicNumberPerfomance == n2.ArabicNumberPerfomance;
    public static bool operator !=(MyNumber n1, MyNumber n2)
    => n1.ArabicNumberPerfomance != n2.ArabicNumberPerfomance;
    public static bool operator < (MyNumber n1, MyNumber n2)
    => n1.ArabicNumberPerfomance < n2.ArabicNumberPerfomance;
    public static bool operator >(MyNumber n1, MyNumber n2)
    => n1.ArabicNumberPerfomance > n2.ArabicNumberPerfomance;
    public static bool operator >=(MyNumber n1, MyNumber n2)
    => n1.ArabicNumberPerfomance >= n2.ArabicNumberPerfomance;
    public static bool operator <=(MyNumber n1, MyNumber n2)
    => n1.ArabicNumberPerfomance <= n2.ArabicNumberPerfomance;

    public override bool Equals(object? obj)
    {
        if (obj is MyNumber n)
        {
            return n.ArabicNumberPerfomance == ArabicNumberPerfomance;
        }
        // if (obj is double n)
        // {
        //     return n == ArabicNumberPerfomance;
        // }//////////добавить после добавления explicit и implicit
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(ArabicNumberPerfomance, RomeNumberPerformance);
    }
}