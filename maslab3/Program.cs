using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maslab3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Реализовать проект – операций над массивами, каждая подзадача реализуется в виде отдельной функции:
            //1-инициализация массива с помощью датчика случайных чисел. Размер массива определяет пользователь
            //2-сложение массивов поэлементно в случае равенства длины массивов
            //3- умножение массива на число осуществляется поэлементно
            //4- поиск общих значений двух массивов(длины массивов могут быть разные)
            //5-печать значений массива
            //6-упорядочивание значений массива по убыванию(без использования стандартных функций)
            //7-поиск min, max значение в массиве, среднего значения всех значений массива(без использования стандартных функций)

            int[] arr1=new int[1] {0};
            bool run = true, arrex=false;
            int opt;
            string buf;
            visual_menu();

            while (run == true) 
            {
                Console.Write("\nВведите опцию: ");
                buf = Console.ReadLine();
                opt = Convert.ToInt32(buf);

                switch (opt)
                {
                    case 1:                                                       
                        Console.Write("Введите размер массива: ");
                        buf = Console.ReadLine();
                        arr1 = firstf(Convert.ToInt32(buf));
                        arrex = true;

                        break;
                    case 2:

                        if (arrex == true)
                        {
                            Console.Write("Введите число элементов второго массива: ");
                            int[] arr2 = new int[Convert.ToInt32(Console.ReadLine())];

                            Console.Write("Введите второй массив: ");
                            arr2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

                            secondf(arr1, arr2);
                        }

                        break;
                    case 3:

                        if (arrex == true)
                        {
                            Console.Write("Введите множитель элементов массива: ");
                            int mult = Convert.ToInt32(Console.ReadLine());

                            thirdf(arr1, mult);
                        }

                        break;
                    case 4:

                        if (arrex == true)
                        {
                            Console.Write("Введите число элементов второго массива: ");
                            int[] arr2 = new int[Convert.ToInt32(Console.ReadLine())];

                            Console.Write("Введите второй массив: ");
                            arr2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

                            fourthf(arr1, arr2);
                        }

                        break;
                    case 5:

                        if (arrex == true)
                        {
                            fifthf(arr1);
                        }

                        break;
                    case 6:
                        if (arrex == true)
                        {
                            sixthf(arr1);
                        }
                        break;
                    case 7:
                        if (arrex == true)
                        {
                            seventhf(arr1);
                        }
                        break;
                    case '8':

                        run = false;

                        break;
                }
            }
        }

        public static void visual_menu()
        {                                       //VISUAL
            Console.WriteLine("Меню:\n 1.инициализация массива с помощью датчика случайных чисел\n 2.сложение массивов поэлементно в случае равенства длины массивов\n 3.умножение массива на число осуществляется поэлементно\n 4.поиск общих значений двух массивов(длины массивов могут быть разные)\n 5.печать значений массива\n 6.упорядочивание значений массива по убыванию\n 7.поиск min, max значение в массиве, среднего значения всех значений массива\n 8.Выход\n");
        }

        public static int[] firstf(int size) 
        {
            int[] arr = new int[size];
            Random r = new Random();

            for (int i = 0; i < size; i++) 
            {
                arr[i] = r.Next(0, 100);
            }

            Console.WriteLine("Получившийся массив: ");
            for (int i = 0; i < size; i++)
            {
                Console.Write(arr[i] + " ");
            }

            return arr;

        }

        public static void secondf(int[] arr1, int[] arr2) 
        {

            if (arr1.Length == arr2.Length) 
                {
                    int[] arr3 = new int[arr1.Length];

                    for (int i = 0; i < arr1.Length; i++) 
                    {
                    arr3[i] = arr1[i] + arr2[i];
                    }

                Console.WriteLine("Получившийся массив: ");
                for (int i = 0; i < arr1.Length; i++)
                {
                    Console.Write(arr3[i] + " ");
                }
            }
            else Console.WriteLine("Длины массивов не совпадают ");
        }

        public static void thirdf(int[] arr1, int mult) 
        {
            int[] arr2 = new int[arr1.Length];
            for (int i = 0; i < arr1.Length; i++) 
            {
                arr2[i] = arr1[i] * mult;
            }

            Console.WriteLine("Получившийся массив: ");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }
        }

        public static void fourthf(int[] arr1, int[] arr2) 
        {
            int[] match = new int[Math.Min(arr1.Length, arr2.Length)];
            int count=0;
            foreach (int num1 in arr1) 
            {
                foreach (int num2 in arr2)
                {
                    if (num1 == num2) 
                    {
                        match[count] = num1; count++;
                    }
                }
            }

            Array.Resize(ref match, count);

            Console.WriteLine("Совпадающие числа массивов: ");
            for (int i = 0; i < match.Length; i++)
            {
                Console.Write(match[i] + " ");
            }

        }

        public static void fifthf(int[] arr1)
        {
            Console.WriteLine("Значения массива: ");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(arr1[i] + " ");
            }
        }

        public static void sixthf(int[] arr1)
        {
            int[]arr2 = (int[])arr1.Clone();

            for (int i = 0; i < arr1.Length; i++) 
            {
                for (int j = arr1.Length - 2; j >= 0; j--) 
                {
                    if (arr2[j] < arr2[j + 1]) { int buf = arr2[j]; arr2[j] = arr2[j + 1]; arr2[j + 1] = buf;  }
                }
            }

            Console.WriteLine("Упорядоченный по убыванию массив: ");
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }
        }

        public static void seventhf(int[] arr1)   
        {
            int min, max,sum=0; double avg;
            int[] arr2 = (int[])arr1.Clone();

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j =0; j < arr1.Length - 1; j++)
                {
                    if (arr2[j] > arr2[j + 1]) { int buf = arr2[j]; arr2[j] = arr2[j + 1]; arr2[j + 1] = buf; }
                }
            }

            min = arr2[0]; max = arr2[arr2.Length - 1];

            for (int i = 0; i < arr2.Length; i++) { sum += arr2[i]; }
            avg = (float)sum / arr2.Length;

            Console.WriteLine("Минимальное значение: {0}", min);
            Console.WriteLine("Максимальное значение: {0}", max);
            Console.WriteLine("Среднее арифметическое значение: {0}", avg);

        }
    }
}
