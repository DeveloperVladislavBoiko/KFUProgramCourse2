namespace Home_work_3;

public class MyMatrixSquare : MyMatrix
{
    public MyMatrixSquare(int n = 1) : base(n, n)
    {
    }

    public MyMatrixSquare(int n, double value) : base(n, n, value)
    {
    }

    public MyMatrixSquare(int n, double[] mas) : base(n, n, mas)
    {
    }

    public MyMatrixSquare(double[,] array) : base(array)
    {
        if (array == null)
            throw new MatrixNullException($"матрица {nameof(array)} не может быть получена из аргумента null");
        
        if (array.GetLength(0) != array.GetLength(1))
            throw new MatrixDimensionException($"Матрица {array.GetLength(0)}x{array.GetLength(1)} не является квадратной");
    }

    public MyMatrixSquare(MyMatrixSquare other) : base(other)
    {
        if (other == null)
            throw new MatrixNullException($"матрица {nameof(other)} не может быть создана из null");
    }

    public double Determinant()
    {
        if (N == 0) throw new MatrixDimensionException("Нельзя найти определитель для матрицы 0Х0");
        if (N == 1) return GetSellValue(0, 0);
        
        var matrix = new double[N, N];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = GetSellValue(i, j);
            }
        }
        
        double determinant = 1.0;
        int swapCount = 0;

        for (int i = 0; i < N; i++)
        {
            int maxRow = i;
            for (int j = i + 1; j < N; j++)
            {
                if (Math.Abs(matrix[j, i]) > Math.Abs(matrix[maxRow, i]))
                {
                    maxRow = j;
                }
            }

            if (Math.Abs(matrix[maxRow, i]) < double.Epsilon)
            {
                return 0;
            }

            if (maxRow != i)
            {
                SwapRows(matrix,i, maxRow);
                swapCount++;
            }

            determinant *= matrix[i, i];

            for (int j = i + 1; j < N; j++)
            {
                double factor = matrix[j, i] / matrix[i, i];
                for (int k = i; k < N; k++)
                {
                    matrix[j, k] -= factor * matrix[i, k];
                }
            }
        }

        return (swapCount % 2 == 0) ? determinant : -determinant;
    }
    private void SwapRows(double[,] matrix, int row1, int row2)
    {
        for (int i = 0; i < N; i++)
        {
            double temp = matrix[row1, i];
            matrix[row1, i] = matrix[row2, i];
            matrix[row2, i] = temp;
        }
    }

    public MyMatrixSquare? ReverseMatrixSquare()
    {
        if (N == 0) throw new MatrixDimensionException("Нельзя найти обратную матрицу для матрицы 0Х0");
        
        double det = Determinant();
        if (Math.Abs(det) < double.Epsilon)
            return null;

        if (N == 1) 
        {
            return new MyMatrixSquare(1, 1.0 / GetSellValue(0, 0));
        }

        double[,] augmented = new double[N, 2 * N];
        
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
                augmented[i, j] = GetSellValue(i, j);
            
            augmented[i, N + i] = 1;
        }

        for (int i = 0; i < N; i++)
        {
            int maxRow = i;
            for (int j = i + 1; j < N; j++)
            {
                if (Math.Abs(augmented[j, i]) > Math.Abs(augmented[maxRow, i]))
                {
                    maxRow = j;
                }
            }

            if (Math.Abs(augmented[maxRow, i]) < double.Epsilon)
            {
                return null;
            }

            if (maxRow != i)
            {
                SwapAugmentedRows(augmented, i, maxRow);
            }

            double pivot = augmented[i, i];
            for (int j = 0; j < 2 * N; j++)
            {
                augmented[i, j] /= pivot;
            }

            for (int j = 0; j < N; j++)
            {
                if (j != i)
                {
                    double factor = augmented[j, i];
                    for (int k = 0; k < 2 * N; k++)
                    {
                        augmented[j, k] -= factor * augmented[i, k];
                    }
                }
            }
        }

        double[,] inverseArray = new double[N, N];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                inverseArray[i, j] = augmented[i, N + j];
            }
        }

        return new MyMatrixSquare(inverseArray);
    }

    private void SwapAugmentedRows(double[,] matrix, int row1, int row2)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            double temp = matrix[row1, i];
            matrix[row1, i] = matrix[row2, i];
            matrix[row2, i] = temp;
        }
    }
}