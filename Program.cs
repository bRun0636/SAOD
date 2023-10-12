using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listlink
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<char> lst = new MyList<char>(); // ваш список
            Console.WriteLine(lst.Count + " " + lst.IsEmpty());
            for (int i = 0; i < 5; i++)
                lst.PushBack((char)(i + 97));
            print_lst(lst);
            for (int i = 0; i < 5; i++)
                lst.Insert(0, (char)(122 - i));
            print_lst(lst);
            for (int i = 0; i < lst.Count; i++)
                lst[i] = (char)(i + 97); // методы доступа set
            print_lst(lst);
            lst.PopBack();
            lst.PopFront();
            print_lst(lst);
            lst.RemoveAt(5);
            lst.Insert(3, 'o');
            print_lst(lst);
            lst.Clear();
            lst.PushBack('q');
            lst.PushFront('a');
            lst.PushBack('w');
            Console.WriteLine(lst.First() + " " + lst.Last());
            Console.WriteLine(lst.Count + " " + lst.IsEmpty());
        }
        static void print_lst(MyList<char> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                Console.Write(lst[i]);
            }
            Console.WriteLine();
        }
    }
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
        public void PushBack(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head.Next == null)
            {
                head.Next = node;
            }
            else
            {
                Node<T> cur = head.Next;
                while (cur.Next != null)
                {
                    cur = cur.Next;
                }
                cur.Next = node;
            }
            count++;
        }

        public void PushFront(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head.Next == null)
            {
                PushBack(data);
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

        public void Insert(int index, T data)
        {

            if (index >= count)
            {
                PushBack(data);
            }
            else
            {
                if (index == 0)
                {
                    PushFront(data);
                }
                else
                {
                    Node<T> node = new Node<T>(data);
                    Node<T> current = head.Next;

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
        void PushBack(T value); // добавляет элемент в конец списка;
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
}