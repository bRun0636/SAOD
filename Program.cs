using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2
{
    internal class Program
    {
        static int count_plus, count_fill, count_space;
        static void Main(string[] args)
        {
            int n, m, r, x, y;
            char z;
            char[] massive;
            while (true)
            {
                try
                {
                    Console.WriteLine("Укажите количество строк в массиве");
                    n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Укажите количество столбцов в массиве");
                    m = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Укажите вероятность появления + в массиве (от 0 до 9)");
                    r = Convert.ToInt32(Console.ReadLine());
                    massive = mas(n, m, r);
                    Console.WriteLine("Введите знак заполнения");
                    z = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine("Введите координату х");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите координату y");
                    y = Convert.ToInt32(Console.ReadLine());
                    zaliv(x, y, m, n, massive, z);
                    Show(massive, n);
                    Console.WriteLine($"Кол-во плюсов: {count_plus}");
                    Console.WriteLine($"Кол-во пропусков:{count_space}");
                    Console.WriteLine($"Кол-во заполненных:{count_fill}");
                    break;
                }
                catch
                {
                    Console.WriteLine("Неверно ввели знаечение");
                }
            }
        }
        static char[] mas(int n, int m, int r)
        {
            Random rnd = new Random();
            char[] massive = new char[n * m];
            for (int i = 0; i < massive.Length; i++)
            {
                if (r > rnd.Next(1, 10))
                {
                    massive[i] = '+';
                    count_plus++;
                }
                else
                {
                    massive[i] = ' ';
                    count_space++;
                }
                Console.Write(massive[i] + " ");
                if ((i + 1) % m == 0)
                    Console.WriteLine();
            }
            return massive;
        }
        static void Show(char[] mas, int m)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i] + " ");
                if ((i + 1) % m == 0)
                    Console.WriteLine();
            }
        }
        static void zaliv(int x, int y, int n, int m, char[] mas, char z)
        {
            MyStack<(int, int)> stack = new MyStack<(int, int)>();
            stack.Push((x, y));
            while (stack.Length > 0)
            {
                (int X, int Y) = stack.Pop();

                if (X >= 0 && Y >= 0 && X < m && Y < n && mas[Y * m + X] == ' ')
                {
                    mas[Y * m + X] = z;
                    stack.Push((X - 1, Y));
                    stack.Push((X + 1, Y));
                    stack.Push((X, Y + 1));
                    stack.Push((X, Y - 1));
                    count_fill++;
                }
            }
        }
    }
    internal class MyStack<T>
    {
        T[] array;
        int count;
        public MyStack()
        {
            array = new T[1];
        }
        public MyStack(int length)
        {
            array = new T[length];
        }
        public void Push(T item)
        {
            if (count >= array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
            array[count++] = item;
        }
        public T Pop()
        {
            if (count == 0)
            {
                throw new Exception("Stack empty");
            }
            T a = array[--count];
            array[count] = default(T);
            return a;
        }
        public T Top()
        {
            if (count == 0)
            {
                throw new Exception("Stack empty");
            }
            return array[count - 1];
        }
        public int Length
        {
            get { return count; }
        }
    }
}
