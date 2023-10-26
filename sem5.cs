using listlink;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace listlink
{
    public class Node<T>
    {
        T data;
        Node<T> next;

        public Node(T val)
        {
            data = val;
        }
        public Node() { }
        public T Data { get { return data; } set { data = value; } }
        public Node<T> Next { get { return next; } set { next = value; } }
    }

    public class MyList<T> : IEnumerable<T>, ISLList<T>
    {
        Node<T> head;
        int count;
        public MyList()
        {
            head = new Node<T>
            {
                Next = null
            };
            count = 0;
        }
        Node<T> node;
        public void Add(T data)
        {
            node = new Node<T>(data);

            if (head.Next == null)
            {
                head.Next = node;
            }
            else
            {
                current = head.Next;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = node;
            }
            count++;
        }

        public void PushFront(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head.Next == null)
            {
                Add(data);
            }
            else
            {
                node.Next = head.Next;
                head.Next = node;

            }
            count++;
        }

        public bool Remove(T data)
        {
            Node<T> current = head.Next;
            Node<T> previous = null;

            if (IsEmpty()) return false;

            do
            {
                if (current.Data.Equals(data))
                {
                    if (previous == null)
                    {
                        head.Next = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;

            } while (current != null);

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                this.PopFront();
            }
            else if (index == count - 1)
            {
                this.PopBack();
            }
            else
            {
                Node<T> current = head.Next;
                Node<T> previous = null;
                for (int i = 0; i < index; i++)
                {
                    previous = current;
                    current = current.Next;
                }
                previous.Next = current.Next;
                count--;
            }
        }

        public void PopFront()
        {
            head.Next = head.Next.Next;
            count--;
        }
        Node<T> current;
        public void Insert(int index, T data)
        {

            if (index >= count)
            {
                Add(data);
            }
            else
            {
                if (index == 0)
                {
                    PushFront(data);
                }
                else
                {
                    node = new Node<T>(data);
                    current = head.Next;

                    for (int i = 0; i < index; i++)
                    {
                        current = current.Next;
                    }

                    node.Next = current.Next;
                    current.Next = node;
                    ++count;
                }
            }
        }


        public int Count { get { return count; } }
        public bool IsEmpty() { return count == 0; }
        public void Clear()
        {
            head.Next = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            Node<T> current = head.Next;
            if (current == null) return false;
            for (int i = 0; i < count; i++)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }


        public T First() { return head.Next.Data; }

        public T Last()
        {
            Node<T> current = head.Next;
            for (int i = 0; i < count - 1; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public void PopBack()
        {
            Node<T> current = head.Next;
            Node<T> previos = null;
            if (count == 1)
            {
                head.Next = null;
                count = 0;
            }
            else
            {
                while (current.Next != null)
                {
                    previos = current;
                    current = current.Next;
                }
                previos.Next = null;
                count--;
            }
        }

        public int FindIndex(T data)
        {
            Node<T> current = head.Next;
            int ind = 0;
            for (int i = 0; i < count; i++)
            {
                if (current.Data.Equals(data))
                {
                    return ind;
                }
                current = current.Next;
                ind++;
            }
            return -1;

        }

        public T this[int index]
        {
            get
            {
                Node<T> current = head.Next;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            }
            set
            {
                Node<T> current = head.Next;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Data = value;
            }
        }

        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head.Next;
            for (int i = 0; i < count; i++)
            {

                yield return current.Data;
                current = current.Next;
            }
        }
    }
    interface ISLList<T>
    {
        void Add(T value); // добавляет элемент в конец списка;
        void PushFront(T value); // добавляет элемент в начало списка;
        void Insert(int index, T value); // добавляет элемент по индексу;
        void PopBack(); // удаляет последний элемент в списке;
        void PopFront(); // удаляет первый элемент в списке;
        void RemoveAt(int index); // удаляет элемент в списке по указанному индексу;
        T this[int index] { set; get; } // для записи/чтения элемента по указанному индексу;
        int Count { get; } // возвращает количество элементов в~списке;
        bool IsEmpty(); // отвечает на вопрос пустой ли список;
        void Clear(); // очищает список, удаляет все узлы;
        T First(); // возвращает первый элемент списка;
        T Last(); // возвращает последний элемент списка.
    }
    public class DoubleNode<T>
    {
        T data;
        Node<T> next;
        Node<T> prev;

        public DoubleNode(T data)
        {
            this.data = data;
        }
        public DoubleNode() { }

        public T Data { get; set; }
        public DoubleNode<T> Prev { get; set; }
        public DoubleNode<T> Next { get; set; }
    }
    public class DoubleList<T>
    {
        DoubleNode<T> head;
        DoubleNode<T> tail;
        int count;

        public int Count { get { return count; } }

        public void Add(T data)
        {
            DoubleNode<T> node = new DoubleNode<T>(data);
            if (head == null)
            {
                head = tail = node;
            }
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }
            count++;
        }
        DoubleNode<T> node;
        DoubleNode<T> previous;
        DoubleNode<T> current;
        public void Insert(int index, T data)
        {
            if (count == 0 || index >= count)
            {
                Add(data);
            }
            else
            {
                node = new DoubleNode<T>(data);
                previous = null;

                if (index == 0)
                {
                    head.Prev = node;
                    node.Next = head;
                    head = node;
                }
                else if (index < count / 2)
                {
                    current = head;

                    for (int i = 0; i < index; i++)
                    {
                        previous = current;
                        current = current.Next;
                    }
                    node.Next = current;
                    node.Prev = previous;
                    previous.Next = node;
                    current.Prev = node;
                }
                else
                {
                    current = tail;

                    for (int i = 0; i < count - index; i++)
                    {
                        previous = current;
                        current = current.Prev;
                    }
                    node.Next = previous;
                    node.Prev = current;
                    current.Next = node;
                    previous.Prev = node;
                }
                count++;
            }
        }
    }
    public class Test
    {
        static void Main()
        {
            Stopwatch watch;

            DoubleList<int> dl = new DoubleList<int>();
            MyList<int> l = new MyList<int>();
            Random rnd = new Random(1);

            long elapsedMs;
            int n = 20000;

            int[] A = new int[n];
            for (int i = 0, count = n; i < n; i++, count++)
                A[i] = rnd.Next(0, count);

            for (int i = 0; i < n; i++)
            {
                dl.Add(i);
                l.Add(i);
                
            }

            watch = Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
            {
                dl.Insert(A[i], -1);
            }
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("time for duoble linked list: " + elapsedMs);

            watch = Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
            {
                l.Insert(A[i], -1);
            }
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("time for linked list: " + elapsedMs);

        }
    }

}