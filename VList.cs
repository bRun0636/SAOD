using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTask
{
    public class List<T> : IEnumerable
    {
        private int capacity;
        private int size;
        private T[] array;

        public List() 
        {
            size = 0;
            capacity = 1;
            array = new T[1];
        }
        public List(int lenght)
        {
            size = 0;
            capacity = lenght;
            array = new T[lenght];
        }
        public void Add(T item)
        {
            if (size >= capacity)
            {
                Array.Resize(ref array, capacity*2)
            }
            array[size++] = item;
        }

        public void Foreach(Action<int> action)
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

        public T Find(int index) //???
        {
            return array[index];
        }

        public void Insert(int index, T item)
        {
            if (index<capacity)
            {
                for (int i = copacity-1; i > indx; i--)
                {
                    array[i] = array[i-1];
                }
            }
            else
            {
                Array.Resize(ref array, copacity*2);
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
            var lst = new List();
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
