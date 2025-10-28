using Home_work_3;

namespace MatrixTests
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMatrix? a = null;
            MyMatrix? b = null;
            Console.WriteLine(a == b);
            TestMatrixArbitrary();
            TestMatrixSquare();
            Console.WriteLine("\n=== Все тесты завершены ===");
        }

        static void TestMatrixArbitrary()
        {
            Console.WriteLine("=== ТЕСТИРОВАНИЕ MatrixArbitrary ===");

            // Тест 1: Создание матрицы и проверка размеров
            Console.WriteLine("\n1. Создание матрицы 3x2:");
            var matrix1 = new MyMatrix(3, 2);
            Console.WriteLine($"   Ожидаем: N=3, M=2");
            Console.WriteLine($"   Увидели: N={matrix1.N}, M={matrix1.M}");

            // Тест 2: Заполнение матрицы значениями
            Console.WriteLine("\n2. Заполнение матрицы значениями:");
            double[] testValues = { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6 };
            var matrix2 = new MyMatrix(2, 3, testValues);
            Console.WriteLine($"   Ожидаем: [0,0]=1.1, [1,2]=6.6");
            Console.WriteLine($"   Увидели: [0,0]={matrix2[0, 0]}, [1,2]={matrix2.GetSellValue(1, 2)}");

            // Тест 3: Индексатор
            Console.WriteLine("\n3. Работа индексатора:");
            var matrix3 = new MyMatrix(2, 2);
            matrix3[0, 0] = 10.5;
            matrix3[1, 1] = 20.5;
            Console.WriteLine($"   Ожидаем: [0,0]=10.5, [1,1]=20.5");
            Console.WriteLine($"   Увидели: [0,0]={matrix3[0, 0]}, [1,1]={matrix3[1, 1]}");

            // Тест 4: Сложение матриц
            Console.WriteLine("\n4. Сложение матриц:");
            var matrix4a = new MyMatrix(2, 2, new double[] { 1, 2, 3, 4 });
            var matrix4b = new MyMatrix(2, 2, new double[] { 5, 6, 7, 8 });
            var sum = matrix4a + matrix4b;
            Console.WriteLine($"   Ожидаем: [0,0]=6, [1,1]=12");
            Console.WriteLine($"   Увидели: [0,0]={sum[0, 0]}, [1,1]={sum[1, 1]}");
            // Тесты умножения матриц
            Console.WriteLine("\n=== Тесты умножения матриц ===");

            // Тест 1: Умножение 2x3 и 3x2 матриц
            Console.WriteLine("\n1. Умножение матриц 2x3 и 3x2:");
            var matrix1a = new MyMatrix(2, 3, new double[] { 1, 2, 3, 4, 5, 6 });
            var matrix1b = new MyMatrix(3, 2, new double[] { 7, 8, 9, 10, 11, 12 });
            var product1 = matrix1a * matrix1b;
            Console.WriteLine($"   Ожидаем: [0,0]=58, [0,1]=64, [1,0]=139, [1,1]=154");
            Console.WriteLine($"   Увидели: [0,0]={product1[0, 0]}, [0,1]={product1[0, 1]}, [1,0]={product1[1, 0]}, [1,1]={product1[1, 1]}");

            // Тест 2: Умножение 2x2 и 2x2 матриц
            Console.WriteLine("\n2. Умножение матриц 2x2 и 2x2:");
            var matrix2a = new MyMatrix(2, 2, new double[] { 2, 1, 3, 4 });
            var matrix2b = new MyMatrix(2, 2, new double[] { 1, 0, 2, 1 });
            var product2 = matrix2a * matrix2b;
            Console.WriteLine($"   Ожидаем: [0,0]=4, [0,1]=1, [1,0]=11, [1,1]=4");
            Console.WriteLine($"   Увидели: [0,0]={product2[0, 0]}, [0,1]={product2[0, 1]}, [1,0]={product2[1, 0]}, [1,1]={product2[1, 1]}");

            // Тест 3: Умножение 3x1 и 1x3 матриц
            Console.WriteLine("\n3. Умножение матриц 3x1 и 1x3:");
            var matrix3a = new MyMatrix(3, 1, new double[] { 2, 3, 4 });
            var matrix3b = new MyMatrix(1, 3, new double[] { 5, 6, 7 });
            var product3 = matrix3a * matrix3b;
            Console.WriteLine($"   Ожидаем: [0,0]=10, [0,1]=12, [0,2]=14, [2,2]=28");
            Console.WriteLine($"   Увидели: [0,0]={product3[0, 0]}, [0,1]={product3[0, 1]}, [0,2]={product3[0, 2]}, [2,2]={product3[2, 2]}");
            
            // Тест 4: Умножение на единичную матрицу
            Console.WriteLine("\n5. Умножение на единичную матрицу:");
            var matrix5a = new MyMatrix(2, 2, new double[] { 3, 7, 4, 9 });
            var identity = new MyMatrix(2, 2, new double[] { 1, 0, 0, 1 });
            var product5 = matrix5a * identity;
            Console.WriteLine($"   Ожидаем: [0,0]=3, [0,1]=7, [1,0]=4, [1,1]=9");
            Console.WriteLine($"   Увидели: [0,0]={product5[0, 0]}, [0,1]={product5[0, 1]}, [1,0]={product5[1, 0]}, [1,1]={product5[1, 1]}");

            // Тест 6: Транспонирование
            Console.WriteLine("\n6. Транспонирование матрицы:");
            var matrix6 = new MyMatrix(2, 3, new double[] { 1, 2, 3, 4, 5, 6 });
            var transposed = matrix6.Transpose;
            Console.WriteLine($"   Ожидаем: размеры 3x2, [0,0]=1, [2,1]=6");
            Console.WriteLine($"   Увидели: размеры {transposed.N}x{transposed.M}, [0,0]={transposed[0, 0]}, [2,1]={transposed[2, 1]}");

            // Тест 7: Умножение на скаляр
            Console.WriteLine("\n7. Умножение на скаляр:");
            var matrix7 = new MyMatrix(2, 2, new double[] { 2, 4, 6, 8 });
            var scaled = matrix7 * 2.5;
            Console.WriteLine($"   Ожидаем: [0,0]=5, [1,1]=20");
            Console.WriteLine($"   Увидели: [0,0]={scaled[0, 0]}, [1,1]={scaled[1, 1]}");
        }

        static void TestMatrixSquare()
        {
            Console.WriteLine("\n=== ТЕСТИРОВАНИЕ MatrixSquare ===");

            // Тест 1: Создание квадратной матрицы
            Console.WriteLine("\n1. Создание квадратной матрицы 3x3:");
            var matrix1 = new MyMatrixSquare(3);
            Console.WriteLine($"   Ожидаем: N=3, M=3");
            Console.WriteLine($"   Увидели: N={matrix1.N}, M={matrix1.M}");

            // Тест 2: Определитель матрицы 2x2
            Console.WriteLine("\n2. Определитель матрицы 2x2:");
            var matrix2 = new MyMatrixSquare(2, new double[] { 1, 2, 3, 4 });
            double det2 = matrix2.Determinant();
            Console.WriteLine($"   Ожидаем: -2");
            Console.WriteLine($"   Увидели: {det2}");
            

            // Тест 1: Определитель матрицы 1x1
            Console.WriteLine("\n1. Определитель матрицы 1x1:");
            var matrix1x1 = new MyMatrixSquare(1, new double[] { 5 });
            double det1x1 = matrix1x1.Determinant();
            Console.WriteLine($"   Ожидаем: 5");
            Console.WriteLine($"   Увидели: {det1x1}");
            Console.WriteLine($"   Результат: {(Math.Abs(det1x1 - 5) < 0.0001 ? "ПРОЙДЕН" : "НЕ ПРОЙДЕН")}");

            // Тест 2: Определитель матрицы 2x2
            Console.WriteLine("\n2. Определитель матрицы 2x2:");
            var matrix2x2 = new MyMatrixSquare(2, new double[] { 1, 2, 3, 4 });
            double det2x2 = matrix2x2.Determinant();
            Console.WriteLine($"   Ожидаем: -2");
            Console.WriteLine($"   Увидели: {det2x2}");
            Console.WriteLine($"   Результат: {(Math.Abs(det2x2 - (-2)) < 0.0001 ? "ПРОЙДЕН" : "НЕ ПРОЙДЕН")}");

            // Тест 3: Определитель матрицы 3x3
            Console.WriteLine("\n3. Определитель матрицы 3x3:");
            var matrix3x3 = new MyMatrixSquare(3, new double[] { 1, 2, 3, 0, 1, 4, 5, 6, 0 });
            double det3x3 = matrix3x3.Determinant();
            Console.WriteLine($"   Ожидаем: 1");
            Console.WriteLine($"   Увидели: {det3x3}");
            Console.WriteLine($"   Результат: {(Math.Abs(det3x3 - 1) < 0.0001 ? "ПРОЙДЕН" : "НЕ ПРОЙДЕН")}");

            // Тест 4: Определитель единичной матрицы
            Console.WriteLine("\n4. Определитель единичной матрицы:");
            var identity = new MyMatrixSquare(3);
            for (int i = 0; i < 3; i++) identity[i, i] = 1;
            double detIdentity = identity.Determinant();
            Console.WriteLine($"   Ожидаем: 1");
            Console.WriteLine($"   Увидели: {detIdentity}");
            Console.WriteLine($"   Результат: {(Math.Abs(detIdentity - 1) < 0.0001 ? "ПРОЙДЕН" : "НЕ ПРОЙДЕН")}");

            // Тест 5: Определитель нулевой матрицы
            Console.WriteLine("\n5. Определитель нулевой матрицы:");
            var zeroMatrix = new MyMatrixSquare(3, 0.0);
            double detZero = zeroMatrix.Determinant();
            Console.WriteLine($"   Ожидаем: 0");
            Console.WriteLine($"   Увидели: {detZero}");
            Console.WriteLine($"   Результат: {(Math.Abs(detZero) < 0.0001 ? "ПРОЙДЕН" : "НЕ ПРОЙДЕН")}");

            // Тест 6: Определитель матрицы с перестановкой строк
            Console.WriteLine("\n6. Определитель матрицы с перестановкой строк:");
            var swapMatrix = new MyMatrixSquare(2, new double[] { 0, 1, 1, 0 });
            double detSwap = swapMatrix.Determinant();
            Console.WriteLine($"   Ожидаем: -1");
            Console.WriteLine($"   Увидели: {detSwap}");
            Console.WriteLine($"   Результат: {(Math.Abs(detSwap - (-1)) < 0.0001 ? "ПРОЙДЕН" : "НЕ ПРОЙДЕН")}");
            
            // Тест 5: Обратная матрица для матрицы 2x2
            Console.WriteLine("\n5. Обратная матрица 2x2:");
            var matrix5 = new MyMatrixSquare(2, new double[] { 4, 7, 2, 6 });
            var inverse5 = matrix5.ReverseMatrixSquare();
            if (inverse5 != null)
            {
                Console.WriteLine($"   Ожидаем: определитель исходной матрицы = 10");
                Console.WriteLine($"   Увидели: определитель исходной матрицы = {matrix5.Determinant()}");
                Console.WriteLine($"   Проверяем: A * A⁻¹ = E");
                var shouldBeIdentity = matrix5 * inverse5;
                Console.WriteLine($"   [0,0]={shouldBeIdentity[0, 0]:F2}, [1,1]={shouldBeIdentity[1, 1]:F2}");
            }
            
            // Тест 7: Конструктор из двумерного массива
            Console.WriteLine("\n7. Создание из двумерного массива:");
            double[,] array = { { 1, 2 }, { 3, 4 } };
            var matrix7 = new MyMatrixSquare(array);
            Console.WriteLine($"   Ожидаем: N=2, M=2, [1,0]=3");
            Console.WriteLine($"   Увидели: N={matrix7.N}, M={matrix7.M}, [1,0]={matrix7[1, 0]}");
        }
        
    }
}