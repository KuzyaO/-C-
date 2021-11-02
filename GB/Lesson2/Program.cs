using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {
        /// <summary>
        /// Задача 1. Написать метод, возвращающий минимальное из трёх чисел.
        /// </summary>  
        /// <param name="args"></param>
        static void Task1()
        {
            Console.Write("Введите первое число: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Введите третье число: ");
            int c = int.Parse(Console.ReadLine());
            if (a < b && a < c)
            {
                Console.WriteLine("Минимальное число - {0}", a);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Минимальное число - " + (b < c ?  b : c));
                Console.ReadLine();
            }
        
            
        }
       
        // Задача 2. Написать метод подсчета количества цифр числа.
        
        static void Task2()
        {
            Console.Write("Введите целое число: ");
            int a = int.Parse(Console.ReadLine());
            int k = 0;
            while (a != 0)
            {
                k++;
                a = a / 10;
            }
            Console.Write("Количество цифр в числе: " + k);
            Console.ReadLine();
        }
        // Задача 3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
        static void Task3()
        {
            int a;
            int summ=0;
            do
            {
                Console.Clear();
                Console.WriteLine("\nВведите положительное или отрицательное целое число. \nДля выхода введите 0.");
                a = int.Parse(Console.ReadLine());
                if (a > 0 && (a % 2) != 0)
                summ = summ + a;
             }
            while (a != 0);
            Console.Clear();
            Console.WriteLine("Сумма всех нечетных положительных чисел: " + summ);
            Console.ReadLine();
                          
        }
        /* 4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
         * На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
         * Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
         * С помощью цикла do while ограничить ввод пароля тремя попытками.
         */
        static bool auth()
        { 
            Console.WriteLine("Введите логин:");
             string log = Console.ReadLine();
             Console.WriteLine("Введите пароль:");
             string pass = Console.ReadLine();
        
           if (log == "root" && pass == "GeekBrains")
                {
                return true;
                }
           else
                return false;
            
          
        }
        static void Task4()
        {
            int i=0;
            bool a;
            do
            {
                a = auth();
                if (a)
                {
                    Console.WriteLine("Авторизация пройдена!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Попробуйте еще раз.");
                    
                };
                i++;
                       if (i==3)
                    {
                        Console.WriteLine("Превышено количество попыток ввода");
                        Console.ReadLine();
                    };
             }
          while ( !a &&  i < 3);

                  
                    
             
          }
        /*5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
             б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
         */
        static void Task5()
        {
            Console.Write("Введите вес в кг.: ");
            double m = double.Parse(Console.ReadLine());
            Console.Write("Введите рост в метрах: ");
            double h = double.Parse(Console.ReadLine());
            double imt = m/(h*h);
            int rec;
            if (imt < 18.5)
                {
                rec = 1;
                }
            else
                { 
                if (imt > 25)
                    {
                    rec = 2;
                    }
                else
                    {
                    rec = 3;
                    }
                };
            switch(rec)
            {
                case 1:
                    double nm = 18.5*h*h;
                    Console.WriteLine("Вы имеете недостаточную массу тела, необходимо набрать {0} кг.", nm-m);
                    Console.ReadLine();
                    break;

                case 2:
                    nm = 25*h*h;
                    Console.WriteLine("Вы имеете избыточную массу тела, необходимо похудеть на {0} кг.", m-nm);
                    Console.ReadLine();
                    break;

                case 3:
                    Console.WriteLine("Вы имеете нормальную массу тела.");
                    Console.ReadLine();
                    break;
            }

        }

        /*6. *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
         * «Хорошим» называется число, которое делится на сумму своих цифр. 
         * Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
         */
        static long Sum(long i)
        {
            if (i == 0)
                return 0;
            else return Sum(i/10) + i % 10;
        }
        static void Task6()
        {
            DateTime start=DateTime.Now;
            int count = 0;            
            for (long i=1; i < 1000000001; i++)
            {
                if (i % Sum(i) == 0)
                    {
                    count++;
                    }
            }
            DateTime finish=DateTime.Now;
            Console.WriteLine("\"Хороших\" чисел в диапазоне от 1 до 1000000000: " + count);
            Console.WriteLine("Время подсчета: " + (finish-start));
            Console.ReadLine();
        }

        /* Задача 7
            a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
            б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
         */
        static void Loop(int a, int b)
        {            
            Console.WriteLine("{0}", a);
             if (a < b) 
                {                  
                Loop(a + 1, b);   
                }     
        }
        static int Sum(int a, int b)
        {
            if (a == b) return b;
            else return Sum(a + 1, b) + a;
        }
        
        static void Task7()
        {
            Console.Write("Введите число a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите число b, больше, чем первое: ");
            int b = int.Parse(Console.ReadLine());
            Loop(a,b);
            Console.WriteLine("Сумма всех чисел: " + Sum(a,b));
            Console.ReadLine();

        }
            
           

        

        
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Задача 1");
            Console.WriteLine("2 - Задача 2");
            Console.WriteLine("3 - Задача 3");
            Console.WriteLine("4 - Задача 4");
            Console.WriteLine("5 - Задача 5");
            Console.WriteLine("6 - Задача 6");
            Console.WriteLine("7 - Задача 7");
            
            Console.Write("\nВведите номер задачи: ");
            int number = int.Parse(Console.ReadLine());

            switch(number)
            {
                case 1:
                    Console.WriteLine("Задача 1. Написать метод, возвращающий минимальное из трёх чисел.");
                    Task1();
                    break;
                case 2:
                    Console.WriteLine("Задача 2. Написать метод подсчета количества цифр числа.");
                    Task2();
                    break;
                case 3:
                    Console.WriteLine("Задача 3. С клавиатуры вводятся числа, пока не будет введен 0.\nПодсчитать сумму всех нечетных положительных чисел.");
                    Task3();
                    break;
                case 4:
                    Console.WriteLine("Задача 4. Проверка логина и пароля (Логин: root, Password: GeekBrains)");
                    Task4();
                    break;
                case 5:
                    Console.WriteLine("Задача 5. Расчет индекса массы тела и рекомендации по набору, сброса веса");
                    Task5();
                    break;                
                case 6:
                    Console.WriteLine("Задача 6. Подсчет \"хороших\" чисел.");
                    Task6();
                    break;
                case 7:
                    Console.WriteLine("Задача 7.");
                    Task7();
                    break;


                default:
                    Console.WriteLine("Вы ввели некорректное значение.\nПопробуйте еще раз.");
                    break;

            }

        }
    }
}
