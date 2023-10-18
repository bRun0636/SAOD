using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTask
{
    public class MyList<T> : IEnumerable
    {
        private int copacity;
        private int size;
        private T[] array;

        public MyList()
        {
            size = 0;
            copacity = 1;
            array = new T[1];
        }
        public MyList(int lenght)
        {
            size = 0;
            copacity = lenght;
            array = new T[lenght];
        }
        public void Add(T item)
        {
            if (size >= copacity)
            {
                Array.Resize(ref array, copacity * 2);
            }
            array[size++] = item;
        }

        public void Foreach(Action<T> action)
        {
            for (int i = 0; i < size; i++)
            {
                action(array[i]);
            }
        }


        public int Count { get { return size; } }

        public int FindIndex(T item)
        {
            for (int i = 0; i < size; i++)
            {
                if (item.Equals(array[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public T Find(int index)
        {
            return array[index];
        }

        public void Insert(int index, T item)
        {
            if (index < copacity)
            {
                for (int i = copacity - 1; i > index; i--)
                {
                    array[i] = array[i - 1];
                }
            }
            else
            {
                Array.Resize(ref array, copacity * 2);
            }
            array[index] = item;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return array[i];
            }
        }
    }

    class Example
    {
        public static void Main()
        {
            MyList<int> lst = new MyList<int>();
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            Console.WriteLine(lst.Count);
            lst.Foreach(x => Console.Write(x + " "));
            Console.WriteLine();
            Console.WriteLine(lst.Find(1));


            //Console.WriteLine("FindIndex: " + lst.Find(ch => ch > 1 && ch < 5));


            foreach (var obj in lst)
                Console.Write(obj + " ");
            Console.WriteLine();
        }
    }
}
