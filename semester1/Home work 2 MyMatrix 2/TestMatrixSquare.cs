using Xunit;
using Home_work_3;

namespace Home_work_3.Tests
{
    public class MyMatrixSquareTests
    {
        [Fact]
        public void CreateWithSize()
        {
            var matrix = new MyMatrixSquare(3);
            
            Assert.Equal(3, matrix.N);
        }

        [Fact]
        public void CreateWithSizeAndValue()
        {
            var matrix = new MyMatrixSquare(2, 5.0);
            
            Assert.Equal(5.0, matrix[0, 0]);
            Assert.Equal(5.0, matrix[1, 1]);
        }

        [Fact]
        public void CreateFromArray()
        {
            double[,] array = {
                {1, 2},
                {3, 4}
            };
            
            var matrix = new MyMatrixSquare(array);
            
            Assert.Equal(1, matrix[0, 0]);
            Assert.Equal(2, matrix[0, 1]);
            Assert.Equal(3, matrix[1, 0]);
            Assert.Equal(4, matrix[1, 1]);
        }

        [Fact]
        public void ThrowWhenNotSquare()
        {
            double[,] array =
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };

            Assert.Throws<MatrixDimensionException>(() => new MyMatrixSquare(array));
        }

        [Fact]
        public void CopyMatrix()
        {
            var original = new MyMatrixSquare(2, 7.0);
            var copy = new MyMatrixSquare(original);
            
            Assert.Equal(7.0, copy[0, 0]);
            Assert.Equal(7.0, copy[1, 1]);
        }


        [Fact]
        public void Determinant1x1()
        {
            var matrix = new MyMatrixSquare(1, 5.0);
            
            var result = matrix.Determinant();
            
            Assert.Equal(5.0, result);
        }

        [Fact]
        public void Determinant2x2()
        {
            double[,] array = {
                {1, 2},
                {3, 4}
            };
            var matrix = new MyMatrixSquare(array);
            
            var result = matrix.Determinant();
            
            Assert.Equal(-2.0, result);
        }

        [Fact]
        public void Determinant3x3()
        {
            double[,] array = {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            var matrix = new MyMatrixSquare(array);
            
            var result = matrix.Determinant();
            
            Assert.Equal(0.0, result, 10);
        }

        [Fact]
        public void DeterminantZero()
        {
            var matrix = new MyMatrixSquare(2, 0.0);
            
            var result = matrix.Determinant();
            
            Assert.Equal(0.0, result);
        }

        [Fact]
        public void Inverse1x1()
        {
            var matrix = new MyMatrixSquare(1, 2.0);
            
            var result = matrix.ReverseMatrixSquare();
            
            Assert.Equal(0.5, result[0, 0]);
        }

        [Fact]
        public void Inverse2x2()
        {
            double[,] array = {
                {4, 7},
                {2, 6}
            };
            var matrix = new MyMatrixSquare(array);
    
            var result = matrix.ReverseMatrixSquare();
    
            Assert.NotNull(result);
            double tolerance = 0.0000000001;
            
            Assert.True(Math.Abs(0.6 - result[0, 0].Value) < tolerance);
            Assert.True(Math.Abs(-0.7 - result[0, 1].Value) < tolerance);
            Assert.True(Math.Abs(-0.2 - result[1, 0].Value) < tolerance);
            Assert.True(Math.Abs(0.4 - result[1, 1].Value) < tolerance);
        }
        
        [Fact]
        public void InverseReturnsNullForSingular()
        {
            double[,] array = {
                {1, 2},
                {2, 4}
            };
            var matrix = new MyMatrixSquare(array);
            
            var result = matrix.ReverseMatrixSquare();
            
            Assert.Null(result);
        }

        [Fact]
        public void CreateFromFlatArray()
        {
            double[] array = {1, 2, 3, 4};
            
            var matrix = new MyMatrixSquare(2, array);
            
            Assert.Equal(1, matrix[0, 0]);
            Assert.Equal(2, matrix[0, 1]);
            Assert.Equal(3, matrix[1, 0]);
            Assert.Equal(4, matrix[1, 1]);
        }
    }
}