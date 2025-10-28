using System.Numerics;

namespace Home_work_3;

public class MyMatrix
{
    private int _n;
    private int _m;
    private double[,] _matrix;
    public int N => _n;
    public int M => _m;
    
    public MyMatrix Transpose
    {
        get
        {
            var result = new MyMatrix(_m, _n);
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _m; j++)
                {
                    result._matrix[j, i] = _matrix[i, j];
                }
            }
            return result;
        }
    }
    public MyMatrix(int n = 1, int m = 1)
    {
        if (_n < 1 || _m < 1)
        {
            throw new ArgumentException("Матрица должна иметь положительную размерность, т.е. n>=1, m>=1");
        }
        _n = n;
        _m = m;
        _matrix = new double[n, m];
    }

    public MyMatrix(int n, int m, double[] mas)
    {
        _n = n;
        _m = m;
        if (_n < 1 || _m < 1)
        {
            throw new ArgumentException("Матрица должна иметь положительную размерность, т.е. n>=1, m>=1");
        }
        _matrix = new double[n, m];
        if (mas.Length != n * m) throw new Exception("Количество элементов не удовлетворяет размерам матрицы");
        for (int i = 0; i < _n; i++)
        {
            for (int j = 0; j < _m; j++)
            {
                _matrix[i, j] = mas[i * _m + j];
            }
        }
    }
    public MyMatrix(double[,] array)
    {
        if (array == null)
            throw new ArgumentNullException($"массив {nameof(array)} пуст, им нельзя задать матрицу");
        
        _n = array.GetLength(0);//получаю количество строк в массиве
        _m = array.GetLength(1);//получаю количество столбцов в массиве
        _matrix = new double[_n, _m];
    
        for (int i = 0; i < _n; i++)
        {
            for (int j = 0; j < _m; j++)
            {
                _matrix[i, j] = array[i, j];
            }
        }
    }
    public MyMatrix(MyMatrix other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));
            
        _n = other.N;
        _m = other.M;
        _matrix = new double[_n, _m];
        
        for (int i = 0; i < _n; i++)
        {
            for (int j = 0; j < _m; j++)
            {
                _matrix[i, j] = other._matrix[i, j];
            }
        }
    }

    public MyMatrix(int n, int m, double value)
    {
        _n = n;
        _m = m;
        if (_n < 1 || _m < 1)
        {
            throw new ArgumentException("Матрица должна иметь положительную размерность, т.е. n>=1, m>=1");
        }
        _matrix = new double[n, m];
        for (int i = 0; i < _n; i++)
        {
            for (int j = 0; j < _m; j++)
            {
                _matrix[i, j] = value;
            }
        }
    }

    public void Insert(int x, int y, double value)
    {
        if (x > _n - 1 || x < 0 || y > _m - 1 || y < 0)
        {
            throw new ArgumentException("Индекс элемента в матрице вне диапозона");
        }
        else
        {
            _matrix[x, y] = value;
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is MyMatrix other && IsIdentical(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_n, _m, _matrix);
    }

    public bool IsIdentical(MyMatrix? other)
    {
        if (other == null || _n != other._n || _m != other._m)
            return false;
        
        for (int i = 0; i < _n; i++)
        {
            for (int j = 0; j < _m; j++)
            {
                if (Math.Abs(_matrix[i, j] - other._matrix[i, j]) > double.Epsilon)
                    return false;
            }
        }
        return true;
    }
    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"Matrix {_n}x{_m}:");
    
        for (int i = 0; i < _n; i++)
        {
            for (int j = 0; j < _m; j++)
            {
                sb.Append($"{_matrix[i, j]:F2}\t");
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
    public static bool operator ==(MyMatrix left, MyMatrix right)
    {
        return left.IsIdentical(right);
    }

    public static bool operator !=(MyMatrix left, MyMatrix right)
    {
        return !(left == right);
    }
    
    public static MyMatrix operator +(MyMatrix m1, MyMatrix m2)
    {
        if (m1._m != m2._m || m1._n != m2._n)
        {
            throw new ArgumentException("Нельзя складывать матрицы разного размера");
        }
        else
        {
            var m3 = new MyMatrix(m1._n, m1._m);
            for (int i = 0; i < m3._n; i++)
            {
                for (int j = 0; j < m3._m; j++)
                {
                    m3._matrix[i, j] = m1._matrix[i, j] + m2._matrix[i, j];
                }
            }
            return m3;
        }
    }

    public static MyMatrix operator -(MyMatrix m1, MyMatrix m2) => m1 + (-1*m2);

    public static MyMatrix operator *(double h, MyMatrix m)
    {
        var m3 = new MyMatrix(m._n, m._m);
        for (int i = 0; i < m3._n; i++)
        {
            for (int j = 0; j < m3._m; j++)
            {
                m3._matrix[i, j] = m._matrix[i, j] * h;
            }
        }
        return m3;
    }

    public static MyMatrix operator *(MyMatrix m, double h)=> h*m;


    public static MyMatrix operator /(MyMatrix m, double h)
    {
        if (h == 0)
        {
            throw new ArgumentException("нельзя делить на ноль");
        }
        else
        {
            return (m * (1.0 / h));
        }
    }

    public static MyMatrix operator *(MyMatrix m1, MyMatrix m2)
    {
        if (m1._m != m2._n) 
            throw new Exception("Нельзя умножать матрицы с такими размерами");
    
        var m3 = new MyMatrix(m1._n, m2._m);
    
        for (int i = 0; i < m1._n; i++)
        {
            for (int j = 0; j < m2._m; j++)
            {
                double sum = 0;
                for (int k = 0; k < m1._m; k++)
                {
                    sum += m1._matrix[i, k] * m2._matrix[k, j];
                }
                m3._matrix[i, j] = sum;
            }
        }
        return m3;
    }

    public double GetSellValue(int n, int m)
    {
        if (n < 0 || n >= _n || m < 0 || m >= _m) throw new ArgumentException("индексы вне диапазона матрицы");
        return _matrix[n, m];
    }
    

    public double? this[int x, int y]
    {
        get
        {
            if (x >= _n || y >= _m || x < 0 || y < 0)
                return null;
            else
            {
                return _matrix[x, y];
            }
        }
        set ///////////// переписать под некоректную работу пользователя 
        {
            if (x >= _n || y >= _m || x < 0 || y < 0)
                throw new ArgumentException($"Введены не корректные индексы. В данной матрице индексы должны быть 0 <= n < {N} и 0<= m < {M}");
            else
            {
                if (value != null) _matrix[x, y] = value.Value;
            }
        }
    }
}