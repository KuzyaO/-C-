using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    struct Complex                                      // структура комплексного числа
    {
        public double im;
        public double re;
        public Complex Sum(Complex x)                   // метод сложения комплексных чисел
        {
            Complex y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }
        public Complex Minus(Complex x)                 // метод вычитания комплексных чисел
        {
            Complex y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }
        public override string ToString()               // строковое предсталение комплексного числа
        {   if (im < 0)
                return $"{re} {im}i";
            else
            return $"{re} + {im}i";
        }


    }
    class Ccomplex                                      // класс комплексного числа
    {
        public double im;
        public double re;
        public Ccomplex(double re, double im)           // конструктор
        {
            this.re = re;
            this.im = im;
        }
        public Ccomplex Cminus(Ccomplex x)              // вычитание
        {
            return new Ccomplex(re - x.re, im - x.im);
        }
        public Ccomplex Mult(Ccomplex x)                // умножение
        {
            return new Ccomplex(re * x.re, im * x.im);
        }
        public override string ToString()               // строковое представление комплексного числа
        {
            if (im < 0)
                return $"{re} {im}i";
            else
                return $"{re} + {im}i";
        }
    }
    class Fraction                                      // класс дробей
    {
        int num;                                        // поле числителя
        int den;                                        // поле знаменателя
        
        public int Num                                  // свойство числителя
        {
            get { return num; }
            set { num = value;}
        }
        public int Den                                  // свойство знаменателя
        {
            get { return den; }
            set { 
                if (value == 0)
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                else den = value;
            }
        }
        public double Fract => (double) num / den;      // свойство десятичного представления числа
                
        
        public Fraction(int num, int den)               // конструктор
        {
            if (den == 0)
                throw new ArgumentException("Знаменатель не может быть равен 0");
            this.num = num;
            this.den = den;
        }
        public static Fraction Sum(Fraction x, Fraction y)     // метод сложения
        {
            int n = x.num * y.den + y.num * x.den;
            int d = x.den * y.den;
            if (n == 0 || d == 0)
                return new Fraction(n, d);
            else
            return new Fraction(n / NOD(n, d), d / NOD(n, d) );

        }
        public static Fraction Minus(Fraction x, Fraction y)   // метод вычитания
        {
            int n = x.num * y.den - y.num * x.den;
            int d = x.den * y.den;
            if (n == 0 || d == 0)
                return new Fraction(n, d);
            else
                return new Fraction(n / NOD(n, d), d / NOD(n, d));
        }
        public static Fraction Mult(Fraction x, Fraction y)    // метод умножения
        {
            int n = x.num * y.num;
            int d = x.den * y.den;
            if (n == 0 || d == 0)
                return new Fraction(n, d);
            else
                return new Fraction(n / NOD(n, d), d / NOD(n, d));
        }
        public static Fraction Div(Fraction x, Fraction y)     // метод деления
        {
            int n = x.num * y.den;
            int d = x.den * y.num;
            if (n == 0 || d == 0)
                return new Fraction(n, d);
            else
                return new Fraction(n / NOD(n, d), d / NOD(n, d));
        }
        public static int NOD(int a, int b)                    // метод нахождения наибольшего общего знаменателя для упрощения дроби
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != b)
            {
                if (a > b)
                {
                    int t = a;
                    a = b;
                    b = t;
                }
                b = b - a;
            }
            return a;
        }
        public override string ToString()                       // строковое представление
        {   if (num == 0)
                return $"0";
            if (den == 1)
                return $"{num}";
            if (den == -1)
                return $"{num * -1}";
            if (num > 0 & den < 0)
                return $"-{num} / {Math.Abs(den)}";
            else
                return $"{num} / {den}";
        }

        
    }
        class Program
    {
        static void Task1()                                     // вычитание комплексных чисел с использование структуры Complex
        {
            Console.Write("Введите RE уменьшаемого комплексного числа: ");
            Complex complex1;
            complex1.re = double.Parse(Console.ReadLine());
            Console.Write("Введите IM уменьшаемого комплексного числа: ");
            complex1.im = double.Parse(Console.ReadLine());
            Console.Write("Введите RE вычитаемого комплексного числа: ");
            Complex complex2;
            complex2.re = double.Parse(Console.ReadLine());
            Console.Write("Введите IM вычитаемого комплексного числа: ");
            complex2.im = double.Parse(Console.ReadLine());

            Console.WriteLine($"Результат вычитания комплексных чисел {complex1}  и  {complex2}  :  {complex1.Minus(complex2)}");
            Console.ReadLine();

        }
        static void Task2()                                       // вычитание и умножение комплексных чисел с использованием класса Ccomplex
        {
            Console.Write("Введите RE первого комплексного числа: ");
            double re1 = double.Parse(Console.ReadLine());
            Console.Write("Введите IM первого комплексного числа: ");
            double im1 = double.Parse(Console.ReadLine());
            Ccomplex complex1 = new Ccomplex(re1, im1);           //первое комплексное число

            Console.Write("Введите RE второго комплексного числа: ");
            double re2 = double.Parse(Console.ReadLine());
            Console.Write("Введите IM второго комплексного числа: ");
            double im2 = double.Parse(Console.ReadLine());
            Ccomplex complex2 = new Ccomplex(re2, im2);            //второе комплексное число
                        
            Console.WriteLine($"Результат вычитания комплексных чисел {complex1}  и  {complex2}  :  {complex1.Cminus(complex2)}");
            Console.WriteLine($"Результат произведения комплексных чисел {complex1}  и  {complex2}  :  {complex1.Mult(complex2)}");
            Console.ReadLine();
        }
        static void Task3()                                         // подсчет суммы положительных нечетных чисел
        {
            int number;
            int sum = 0;
            string str = "Сумма чисел ";
            do
            {
                Console.WriteLine("Введите число. Для выхода введите 0");

                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (number > 0 & number % 2 != 0)
                    {
                        sum = sum + number;
                        str = $"{str} " + $"{number}";
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели некорректное число");
                }
                
            }
            while (number != 0);
            Console.WriteLine($"{str} = {sum}");
            Console.ReadLine();
        }

            static void Task4()                                     // демонстрация элементов класса дробей
        {
            Console.WriteLine("Введите числитель первого дробного числа");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите знаменатель первого дробного числа");
            int den1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите числитель второго дробного числа");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите знаменатель второго дробного числа");
            int den2 = int.Parse(Console.ReadLine());
            Fraction fraction1 = new Fraction(num1, den1);
            Fraction fraction2 = new Fraction(num2, den2);

            Console.WriteLine($"Первое дробное число {fraction1} и его десятичное представление {fraction1.Fract}" +
                $"\nВторое дробное число {fraction2} и его десятичное представление {fraction2.Fract}" +
                $"\nРезультат сложения {Fraction.Sum(fraction1, fraction2)} "+
                $"\nРезультат вычитания из первого второго {Fraction.Minus(fraction1, fraction2)}"+
                $"\nРезультат их умножения {Fraction.Mult(fraction1, fraction2)}" +
                $"\nРезультат деления первого на второе {Fraction.Div(fraction1, fraction2)}");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {   
            Console.WriteLine("1 - Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.");
            Console.WriteLine("\n2 - Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.");
            Console.WriteLine("\n3 - С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке)." + 
                " \nТребуется подсчитать сумму всех нечётных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse.");
            Console.WriteLine("\n4 - Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. " + 
                "\nПредусмотреть методы сложения, вычитания, умножения и деления дробей. " +
                "\nНаписать программу, демонстрирующую все разработанные элементы класса." +
                "\nДобавить свойства типа int для доступа к числителю и знаменателю." +
                "\nДобавить свойство типа double только на чтение, чтобы получить десятичную дробь числа" +
                "\nДобавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException(\"Знаменатель не может быть равен 0\")" +
                "\nДобавить упрощение дробей.");


            Console.Write("\nВведите номер задачи: ");
            int number = int.Parse(Console.ReadLine());

            switch (number)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;


                default:
                    Console.WriteLine("Вы ввели некорректное значение.\nПопробуйте еще раз.");
                    break;
            }
        }
    }
}
