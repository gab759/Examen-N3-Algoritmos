using System;
using System.Collections;
using UnityEngine;

public class ListaSimple<T>
{
    Node Head;
    public int Length = 0;

    class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            this.Value = value;
            Next = null;
        }
    }
    public void InsertAtStart(T value)
    {
        if (Head == null)
        {
            Node newNode = new Node(value);
            Head = newNode;
            Length++;
        }
        else
        {
            Node newNode = new Node(value);
            newNode.Next = Head;
            Head = newNode;
            Length++;
        }
    }

    public void InsertAtEnd(T value)
    {
        if (Head == null)
        {
            InsertAtStart(value);
        }
        else
        {
            Node last = Head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            Node newNode = new Node(value);
            last.Next = newNode;
            Length++;
        }
    }

    public void InsertAtPosition(T value, int position)
    {
        if (position == 0)
        {
            InsertAtStart(value);
        }
        else if (position == Length - 1)
        {
            InsertAtEnd(value);
        }
        else if (position >= Length)
        {
            throw new Exception("The provided position exceeds the length of the list.");
        }
        else
        {
            Node previous = Head;
            int iterator = 0;
            while (iterator < position - 1)
            {
                previous = previous.Next;
                iterator++;
            }
            Node next = previous.Next;
            Node newNode = new Node(value);
            previous.Next = newNode;
            newNode.Next = next;
            Length++;
        }
    }

    public T GetFirstNode()
    {
        if (Head == null)
        {
            throw new Exception("The list is empty.");
        }
        else
        {
            return Head.Value;
        }
    }

    public T GetLastNode()
    {
        if (Head == null)
        {
            return GetFirstNode();
        }
        else
        {
            Node last = Head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            return last.Value;
        }
    }

    public T GetNodeAtPosition(int position)
    {
        if (position == 0)
        {
            return GetFirstNode();
        }
        else if (position == Length)
        {
            return GetLastNode();
        }
        else if (position >= Length)
        {
            throw new Exception("The provided position exceeds the length of the list.");
        }
        else
        {
            Node nodeAtPosition = Head;
            int iterator = 0;
            while (iterator < position)
            {
                nodeAtPosition = nodeAtPosition.Next;
                iterator++;
            }
            return nodeAtPosition.Value;
        }
    }
}
