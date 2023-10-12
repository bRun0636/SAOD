using System;
using System.Collections;
using System.Collections.Generic;


public class Node<T>
{
    T data;
    Node<T> next;

    public Node(T val)
    {
        data = val;
    }
    public T Data { get { return data; } set { data = value; } }
    public Node<T> Next { get { return next; } set { next = value; } }
}

public class MyList<T> : IEnumerable<T>
{
    Node<T> head;
    int count;
    public void PushBack(T data)
    {
        Node<T> node = new Node<T>(data);

        if (head == null)
        {
            head = node;
        }
        else
        {
            Node<T> cur = head;
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

        if (head == null)
        {
            PushBack(data);
        }
        else
        {
            node.Next = head;
            head = node;

        }
        count++;
    }

    public bool Remove(T data)
    {
        Node<T> current = head;
        Node<T> previous = null;

        if (IsEmpty) return false;

        do
        {
            if (current.Data.Equals(data))
            {
                if (previous == null)
                {
                    head = current.Next;
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
            Node<T> current = head;
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
        head = head.Next;
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
                Node<T> current = head;

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
    public bool IsEmpty { get { return count == 0; } }
    public void Clear()
    {
        head = null;
        count = 0;
    }

    public bool Contains(T data)
    {
        Node<T> current = head;
        if (current == null) return false;
        for (int i = 0; i < count; i++)
        {
            if (current.Data.Equals(data))
                return true;
            current = current.Next;
        }
        return false;
    }


    public T First() { return head.Data; }

    public T Last()
    {
        Node<T> current = head;
        for (int i = 0; i < count - 1; i++)
        {
            current = current.Next;
        }
        return current.Data;
    }

    public void PopBack()
    {
        Node<T> current = head;
        Node<T> previos = null;
        if (count == 1)
        {
            head = null;
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
        Node<T> current = head;
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
            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }
        set
        {
            Node<T> current = head;
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
        Node<T> current = head;
        for (int i = 0; i < count; i++)
        {

            yield return current.Data;
            current = current.Next;
        }
    }
}