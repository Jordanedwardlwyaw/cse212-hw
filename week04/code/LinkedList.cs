using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Node class representing each element in the doubly linked list.
    /// </summary>
    public class Node
    {
        public int Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }

        public Node(int data)
        {
            Data = data;
        }
    }

    /// <summary>
    /// Insert a new node at the front (head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        Node newNode = new Node(value);
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// Remove the head node from the linked list.
    /// </summary>
    public void RemoveHead()
    {
        if (_head is null) return;

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _head = _head.Next;
            if (_head is not null)
            {
                _head.Prev = null;
            }
        }
    }

    /// <summary>
    /// Insert a new node after the first node containing value.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new Node(newValue);
                    newNode.Prev = curr;
                    newNode.Next = curr.Next;
                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }
                return;
            }
            curr = curr.Next;
        }
    }

    // =========================================================================
    // ASSIGNMENT PROBLEMS TO IMPLEMENT
    // =========================================================================

    /// <summary>
    /// Problem 1: Insert a new node at the end (tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new Node(value);

        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }
    }

    /// <summary>
    /// Problem 2: Remove the last node (tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        if (_tail is null) return;

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail = _tail.Prev;
            if (_tail is not null)
            {
                _tail.Next = null;
            }
        }
    }

    /// <summary>
    /// Problem 3: Search starting from the head and remove the first node matching value.
    /// </summary>
    public void Remove(int value)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _head)
                {
                    RemoveHead();
                }
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                return;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Problem 4: Search for all nodes equal to oldValue and replace their Data with newValue.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Problem 5: Iterate backwards through the list starting at the tail.
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        Node? curr = _tail;

        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Prev;
        }
    }

    // =========================================================================
    // HELPER & ITERATOR METHODS USED BY TESTS
    // =========================================================================

    public IEnumerator<int> GetEnumerator()
    {
        Node? curr = _head;
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    public bool HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }
}

public static class IEnumerableExtensions
{
    public static string AsString<T>(this IEnumerable<T> collection)
    {
        return "<IEnumerable>{" + string.Join(", ", collection) + "}";
    }
}