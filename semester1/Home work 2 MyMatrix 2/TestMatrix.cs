using System;
using Xunit;
using Home_work_3;

namespace Home_work_3.Tests
{
    public class MyMatrixTests
    {
        [Fact]
        public void ConstructorWithPositiveDimensions()
        {
            
            var matrix = new MyMatrix(2, 3);
            Assert.Equal(2, matrix.N);
            Assert.Equal(3, matrix.M);
        }

        [Fact]
        public void ConstructorWithNotSizes()
        {
            Assert.Throws<MatrixDimensionException>(() => new MyMatrix(-1, 1));
            Assert.Throws<MatrixDimensionException>(() => new MyMatrix(1, -1));
            Assert.Throws<MatrixDimensionException>(() => new MyMatrix(-1, -1));
            Assert.Throws<MatrixDimensionException>(() => new MyMatrix(0, 1));
            Assert.Throws<MatrixDimensionException>(() => new MyMatrix(1, 0));
            Assert.Throws<MatrixDimensionException>(() => new MyMatrix(0, 0));
        }

        [Fact]
        public void Constructor_WithArray_CreatesMatrix()
        {
            double[] array = { 1, 2, 3, 4, 5, 6 };
            
            var matrix = new MyMatrix(2, 3, array);
            
            Assert.Equal(2, matrix.N);
            Assert.Equal(3, matrix.M);
            Assert.Equal(1, matrix.GetSellValue(0, 0));
            Assert.Equal(6, matrix.GetSellValue(1, 2));
        }

        [Fact]
        public void ConstructorWithInvalidArrayLength()
        {
            double[] array = { 1, 2, 3 };
            Assert.Throws<MatrixDimensionException>(() => new MyMatrix(2, 3, array));
        }

        [Fact]
        public void Constructor_With2DArray_CreatesMatrix()
        {
            double[,] array = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            
            var matrix = new MyMatrix(array);
            
            Assert.Equal(3, matrix.N);
            Assert.Equal(2, matrix.M);
            Assert.Equal(1, matrix[0, 0]);
            Assert.Equal(6, matrix[2, 1]);
        }


        [Fact]
        public void CreateMatrixAsConstant()
        {
            
            var matrix = new MyMatrix(2, 2, 5.5);
            
            
            Assert.Equal(5.5, matrix.GetSellValue(0, 0));
            Assert.Equal(5.5, matrix.GetSellValue(0, 1));
            Assert.Equal(5.5, matrix.GetSellValue(1, 0));
            Assert.Equal(5.5, matrix.GetSellValue(1, 1));
        }

        [Fact]
        public void CopyConstructorCreatesIdenticalMatrix()
        {
            var original = new MyMatrix(2, 2, [1, 2, 3, 4 ]);
            var copy = new MyMatrix(original);
            
            Assert.True(original.IsIdentical(copy));
            Assert.Equal(original.N, copy.N);
            Assert.Equal(original.M, copy.M);
        }


        [Fact]
        public void IndexerGetValidIndexReturnsValue()
        {
            var matrix = new MyMatrix(2, 2,[1, 2, 3, 4 ]);
            
            Assert.Equal(1, matrix[0, 0]);
            Assert.Equal(4, matrix[1, 1]);
        }

        [Fact]
        public void IndexerGetInvalidIndexReturnsNull()
        {
            var matrix = new MyMatrix(2, 2);
            
            Assert.Null(matrix[3, 1]);
            Assert.Null(matrix[1, 3]);
            Assert.Null(matrix[-1, 1]);
            Assert.Null(matrix[1, -1]);
        }

        [Fact]
        public void IndexerSetValidIndexUpdatesValue()
        {
            var matrix = new MyMatrix(2, 2);
            
            matrix[1, 1] = 15.7;
            
            Assert.Equal(15.7, matrix[1, 1]);
        }

        [Fact]
        public void IndexerSetInvalidIndexException()
        {
            var matrix = new MyMatrix(2, 2);
            
            Assert.Throws<MatrixIndexOutOfRangeException>(() => matrix[3, 1] = 10.5);
            Assert.Throws<MatrixIndexOutOfRangeException>(() => matrix[1, 3] = 10.5);
            Assert.Throws<MatrixIndexOutOfRangeException>(() => matrix[-1, 1] = 10.5);
            Assert.Throws<MatrixIndexOutOfRangeException>(() => matrix[1, -1] = 10.5);
        }

        [Fact]
        public void IndexerValidIndex_ReturnsValue()
        {
            var matrix = new MyMatrix(2, 2, new double[] { 1, 2, 3, 4 });
            
            Assert.Equal(1, matrix[0, 0]);
            Assert.Equal(4, matrix[1, 1]);
        }

        [Fact]
        public void TransposeReturnsTransposedMatrix()
        {
            var matrix = new MyMatrix(2, 3, new double[] { 1, 2, 3, 4, 5, 6 });
            
            var transposed = matrix.Transpose;

            Assert.Equal(3, transposed.N);
            Assert.Equal(2, transposed.M);
            Assert.Equal(1, transposed[0, 0]);
            Assert.Equal(4, transposed[0, 1]);
            Assert.Equal(2, transposed[1, 0]);
            Assert.Equal(5, transposed[1, 1]);
            Assert.Equal(3, transposed[2, 0]);
        }

        [Fact]
        public void IsIdenticalMatrixContents()
        {
            var matrix1 = new MyMatrix(2, 2, new double[] { 1, 2, 3, 4 });
            var matrix2 = new MyMatrix(2, 2, new double[] { 1, 2, 3, 4 });
            Assert.True(matrix1.IsIdentical(matrix2));
        }

        [Fact]
        public void DifferentMatrixContents()
        {
            var matrix1 = new MyMatrix(2, 2, [ 1, 2, 3, 4 ]);
            var matrix2 = new MyMatrix(2, 2, [ 1, 2, 3, 5 ]);
            
            Assert.False(matrix1.IsIdentical(matrix2));
        }

        [Fact]
        public void IsIdenticalWithDifferentDimensionsReturnsFalse()
        {
            var matrix1 = new MyMatrix(2, 2);
            var matrix2 = new MyMatrix(2, 3);
            
            Assert.False(matrix1.IsIdentical(matrix2));
        }

        [Fact]
        public void IsIdenticalWithNullReturnsFalse()
        {
            var matrix = new MyMatrix(2, 2);
            
            Assert.False(matrix.IsIdentical(null));
        }

        [Fact]
        public void EqualsWithIdenticalMatricesReturnsTrue()
        {
            var matrix1 = new MyMatrix(2, 2, new double[] { 1, 2, 3, 4 });
            var matrix2 = new MyMatrix(2, 2, new double[] { 1, 2, 3, 4 });
            
            Assert.True(matrix1.Equals(matrix2));
        }

        [Fact]
        public void OperatorIndenticalMatrix()
        {
            var matrix1 = new MyMatrix(2, 2, new double[] { 1, 2, 3, 4 });
            var matrix2 = new MyMatrix(2, 2, new double[] { 1, 2, 3, 4 });
            
            Assert.True(matrix1 == matrix2);
        }

        [Fact]
        public void OperatorNotIndenticalMatrix()
        {
            var matrix1 = new MyMatrix(2, 2,[ 1, 2, 3, 4 ]);
            var matrix2 = new MyMatrix(2, 2, [ 1, 2, 3, 5 ]);
            
            Assert.True(matrix1 != matrix2);
        }

        [Fact]
        public void Addition_ValidMatrices_ReturnsSumMatrix()
        {
            var matrix1 = new MyMatrix(2, 2,[ 1, 2, 3, 4 ]);
            var matrix2 = new MyMatrix(2, 2,[ 5, 6, 7, 8 ]);
            
            var result = matrix1 + matrix2;
            
            Assert.Equal(6, result.GetSellValue(0, 0));
            Assert.Equal(8, result.GetSellValue(0, 1));
            Assert.Equal(10, result.GetSellValue(1, 0));
            Assert.Equal(12, result.GetSellValue(1, 1));
        }

        [Fact]
        public void ReturnExceptionDifferentSizesMatrices()
        {
            var matrix1 = new MyMatrix(2, 2);
            var matrix2 = new MyMatrix(2, 3);
            
            Assert.Throws<MatrixDimensionException>(() => matrix1 + matrix2);
        }

        [Fact]
        public void Subtraction_ValidMatrices_ReturnsDifference()
        {
            var matrix1 = new MyMatrix(2, 2,[5, 6, 7, 8 ]);
            var matrix2 = new MyMatrix(2, 2, [1, 2, 3, 4 ]);
            var result = matrix1 - matrix2;
            Assert.Equal(4, result[0, 0]);
            Assert.Equal(4, result[0, 1]);
            Assert.Equal(4, result[1, 0]);
            Assert.Equal(4, result[1, 1]);
        }

        [Fact]
        public void ScalarMultiplicationReturnsScaledMatrix()
        {
            var matrix = new MyMatrix(2, 2,[ 1, 2, 3, 4 ]);
            
            var result1 = 2 * matrix;
            var result2 = matrix * 2;
            
            Assert.Equal(2, result1[0, 0]);
            Assert.Equal(4, result1[0, 1]);
            Assert.Equal(6, result1[1, 0]);
            Assert.Equal(8, result1[1, 1]);
            
            Assert.True(result1.IsIdentical(result2));
        }

        [Fact]
        public void Division_ByNumberNonZero()
        {
            var matrix = new MyMatrix(2, 2, [ 2, 4, 6, 8 ]);
            
            var result = matrix / 2;
            
            Assert.Equal(4, result[1, 1]);
            Assert.Equal(1, result[0, 0]);
            Assert.Equal(2, result[0, 1]);
            Assert.Equal(3, result[1, 0]);
        }

        [Fact]
        public void ExceptionDivisionByZero()
        {
            var matrix = new MyMatrix(2, 2);
            
            Assert.Throws<MatrixException>(() => matrix / 0);
        }

        [Fact]
        public void MultiplyMatricesByValidMatrices()
        {
            var matrix1 = new MyMatrix(2, 3, [ 1, 2, 3, 4, 5, 6 ]);
            var matrix2 = new MyMatrix(3, 2, [ 7, 8, 9, 10, 11, 12 ]);
            
            var result = matrix1 * matrix2;
            
            Assert.Equal(2, result.N);
            Assert.Equal(2, result.M);
            Assert.Equal(58, result[0, 0]);
            Assert.Equal(64, result[0, 1]);
            Assert.Equal(139, result[1, 0]);
            Assert.Equal(154, result[1, 1]);
        }

        [Fact]
        public void GettingExceptionAnDifferentSizesWhenMultiplyingMatrix()
        {
            var matrix1 = new MyMatrix(2, 2);
            var matrix2 = new MyMatrix(3, 3);
            
            Assert.Throws<MatrixMultiplicationException>(() => matrix1 * matrix2);
        }

        [Fact]
        public void ToString_ReturnsFormattedString()
        {
            var matrix = new MyMatrix(2, 2, [ 1.123, 2.456, 3.789, 4.012 ]);
            var result = matrix.ToString();
            Assert.Contains("Matrix 2x2:", result);
            Assert.Contains("1,12", result); 
            Assert.Contains("2,46", result);
        }

        [Fact]
        public void GetHashCode_ReturnsSameHashCode()
        {
            var matrix1 = new MyMatrix(2, 2, [ 1, 2, 3, 4 ]);
            var matrix2 = new MyMatrix(2, 2, [ 1, 2, 3, 4 ]);
            var hash1 = matrix1.GetHashCode();
            var hash2 = matrix2.GetHashCode();
            Assert.Equal(hash1, hash2);
        }
    }
}