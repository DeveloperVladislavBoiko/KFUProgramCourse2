using Xunit;

namespace Home_work_3
{
    public class TestMatrixArbitrary
    {
        [Fact]
        public void TestBaseCreateMatrix()
        {
            var m = new MatrixArbitrary();
            Assert.Equal(0,m.N);
        }
    }
}