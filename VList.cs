using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTask
{
    public class List : IEnumerable
    {
        private int capacity;
        private int size;
        private int[] array;

        public List() 
        {
            size = 0;
            capacity = 1;
            array = new int[1];
        }
        public List(int lenght)
        {
            size = 0;
            capacity = lenght;
            array = new int[lenght];
        }
        public void Add(int item)
        {

            if (size < capacity)
            {
                array[size] = item;
                size++;
            }
            else if (size >= capacity)
            {
                capacity *= 2;
                int[] newarray = new int[capacity];
                for (int i = 0; i < size; i++)
                {
                    newarray[i] = array[i];

                }
                newarray[size] = item;
                size++;
                array = newarray;
            }
        }

        public void Foreach(Action<int> action)
        {
            for (int i = 0; i < size; i++)
            {
                action(array[i]);
            }
        }


        public int Count { get { return size; } }

        public int FindIndex(int item)
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

        public int Find(int val)//Predicate<int> predicate
        {
            for (int i = 0; i < size; i++)
            {
                if(array[i] == val)
                    return i;
                // if (predicate(array[i]))
                // {
                //     return array[i];
                // }
            }

            return default(int);
        }

        public void Insert(int index, int item)
        {
            if (size<capacity)
            {
                for (int i = size; i >index; i--)
                {
                    array[i] = array[i - 1];
                }
                array[index] = item;
            }
            else if (size==capacity)
            {
                capacity *= 2;
                int[] newarray = new int[capacity];
                newarray[index] = item;
                for (int i = 0; i < index; i++)
                {
                    newarray[i] = array[i];
                }
                for (int i = index; i < size; i++)
                {
                    newarray[i + 1] = array[i];
                }
                array = newarray;
                ++size;
            }

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
