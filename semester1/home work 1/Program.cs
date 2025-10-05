//"Код работает с числами в диапозоне от -4000 до 4000, работает с арабскими и римскими числами"
//спросить про то, нужно ли в стучае не корректной работы со свойством вызывать ошибку
//файл с демонстрацией работы класса Program.cs я сделал с помощью ИИ, сам класс изготовлен полностью самостоятельно

using System;
// 1. Демонстрация конструкторов
Console.WriteLine("1. СОЗДАНИЕ ОБЪЕКТОВ:");
Console.WriteLine("====================");

MyNumber num1 = new MyNumber(); // конструктор по умолчанию
Console.WriteLine($"Конструктор по умолчанию: {num1}");

MyNumber num2 = new MyNumber(42); // конструктор с арабским числом
Console.WriteLine($"Конструктор с числом 42: {num2}");

MyNumber num3 = new MyNumber("XIV"); // конструктор с римским числом
Console.WriteLine($"Конструктор с 'XIV': {num3}");

MyNumber num4 = new MyNumber(-123); // отрицательное число
Console.WriteLine($"Конструктор с -123: {num4}");

MyNumber num5 = new MyNumber("MCMXC"); // 1990
Console.WriteLine($"Конструктор с 'MCMXC': {num5}");

Console.WriteLine();

// 2. Демонстрация свойств
Console.WriteLine("2. СВОЙСТВА:");
Console.WriteLine("============");

MyNumber num = new MyNumber(256);
Console.WriteLine($"Исходное число: {num}");

num.ArabicNumberPerfomance = 512; // изменение через арабское свойство
Console.WriteLine($"После установки ArabicNumberPerfomance = 512: {num}");

num.RomeNumberPerformance = "CCL"; // изменение через римское свойство
Console.WriteLine($"После установки RomeNumberPerformance = 'CCL': {num}");

Console.WriteLine();

// 3. Демонстрация арифметических операций
Console.WriteLine("3. АРИФМЕТИЧЕСКИЕ ОПЕРАЦИИ:");
Console.WriteLine("===========================");

MyNumber a = new MyNumber(10);
MyNumber b = new MyNumber("III");

Console.WriteLine($"a = {a}, b = {b}");
Console.WriteLine($"a + b = {a + b}");
Console.WriteLine($"a - b = {a - b}");
Console.WriteLine($"a * b = {a * b}");
Console.WriteLine($"a / b = {a / b}");

// Более сложные вычисления
MyNumber x = new MyNumber("X"); // 10
MyNumber y = new MyNumber("V"); // 5
MyNumber z = new MyNumber("II"); // 2

MyNumber result = (x + y) * z;
Console.WriteLine($"\nСложное выражение: (X + V) * II = {result}");

Console.WriteLine();

// 4. Демонстрация операций сравнения
Console.WriteLine("4. ОПЕРАЦИИ СРАВНЕНИЯ:");
Console.WriteLine("======================");

MyNumber n1 = new MyNumber(15);
MyNumber n2 = new MyNumber("XV");
MyNumber n3 = new MyNumber(20);

Console.WriteLine($"n1 = {n1}, n2 = {n2}, n3 = {n3}");
Console.WriteLine($"n1 == n2: {n1 == n2}");
Console.WriteLine($"n1 != n3: {n1 != n3}");
Console.WriteLine($"n1 < n3: {n1 < n3}");
Console.WriteLine($"n3 > n1: {n3 > n1}");
Console.WriteLine($"n1 >= n2: {n1 >= n2}");
Console.WriteLine($"n1 <= n3: {n1 <= n3}");

Console.WriteLine();

// 5. Демонстрация метода Equals
Console.WriteLine("5. МЕТОД Equals:");
Console.WriteLine("================");

MyNumber numA = new MyNumber(100);
MyNumber numB = new MyNumber("C");
MyNumber numC = new MyNumber(200);

Console.WriteLine($"numA = {numA}, numB = {numB}, numC = {numC}");
Console.WriteLine($"numA.Equals(numB): {numA.Equals(numB)}");
Console.WriteLine($"numA.Equals(numC): {numA.Equals(numC)}");
Console.WriteLine($"numA.Equals(\"строка\"): {numA.Equals("строка")}");

Console.WriteLine();

// 6. Демонстрация работы с отрицательными числами
Console.WriteLine("6. ОТРИЦАТЕЛЬНЫЕ ЧИСЛА:");
Console.WriteLine("======================");

MyNumber neg1 = new MyNumber(-50);
MyNumber neg2 = new MyNumber("-XXV"); // -25

Console.WriteLine($"neg1 = {neg1}");
Console.WriteLine($"neg2 = {neg2}");
Console.WriteLine($"neg1 + neg2 = {neg1 + neg2}");
Console.WriteLine($"neg1 - neg2 = {neg1 - neg2}");
