
using System.Text;

namespace DoubleList;


public class DoublyLinkedList<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    public DoublyLinkedList()
    {
        _tail = null;
        _head = null;
    }

    
    public void Insert(T data)
    {
        var node = new DoubleNode<T>(data);
        
        if (_head == null)
        {
            _head = _tail = node;
            return;
        }
        
        if (Comparer<T>.Default.Compare(data, _head.Data) <= 0)
        {
            node.Next = _head;
            _head.Prev = node;
            _head = node;
            return;
        }
        
        var current = _head;
        while (current.Next != null && Comparer<T>.Default.Compare(current.Next.Data, data) < 0)
            current = current.Next;
        node.Next = current.Next;
        node.Prev = current;
        if (current.Next != null)
            current.Next.Prev = node;
        else
            _tail = node;
        current.Next = node;
    }

    
    public string GetForward()
    {
        var sb = new StringBuilder();
        var current = _head;
        while (current != null)
        {
            sb.Append(current.Data);
            if (current.Next != null)
                sb.Append(" <-> ");
            current = current.Next;
        }
        return sb.ToString();
    }

    
    public string GetBackward()
    {
        var sb = new StringBuilder();
        var current = _tail;
        while (current != null)
        {
            sb.Append(current.Data);
            if (current.Prev != null)
                sb.Append(" <-> ");
            current = current.Prev;
        }
        return sb.ToString();
    }

    
    public void SortAscending()
    {
        if (_head == null) return;
        bool swapped;
        do
        {
            swapped = false;
            var current = _head;
            while (current.Next != null)
            {
                if (Comparer<T>.Default.Compare(current.Data!, current.Next.Data!) > 0)
                {
                    var tmp = current.Data!;
                    current.Data = current.Next.Data!;
                    current.Next.Data = tmp;
                    swapped = true;
                }
                current = current.Next;
            }
        } while (swapped);
    }

    
    public void SortDescending()
    {
        SortAscending();
        Reverse();
    }

    
    public void Reverse()
    {
        DoubleNode<T>? prev = null;
        var current = _head;
        _tail = _head;
        while (current != null)
        {
            var next = current.Next;
            current.Next = prev;
            current.Prev = next;
            prev = current;
            current = next;
        }
        _head = prev;
    }

    
    public bool Contains(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
                return true;
            current = current.Next;
        }
        return false;
    }

    
    public bool Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    _head = current.Next;
                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    _tail = current.Prev;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    
    public int RemoveAll(T data)
    {
        int removed = 0;
        var current = _head;
        while (current != null)
        {
            var next = current.Next;
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    _head = current.Next;
                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    _tail = current.Prev;
                removed++;
            }
            current = next;
        }
        return removed;
    }

    
    public void Clear()
    {
        _head = null;
        _tail = null;
    }

    
    public IEnumerable<T> GetMode()
    {
        var freq = new Dictionary<T, int>();
        var current = _head;
        while (current != null)
        {
            freq[current.Data!] = freq.GetValueOrDefault(current.Data!) + 1;
            current = current.Next;
        }
        if (freq.Count == 0) yield break;
        int max = freq.Values.Max();
        foreach (var kv in freq)
            if (kv.Value == max) yield return kv.Key;
    }

    
    public string GetFrequencyGraph()
    {
        var sb = new StringBuilder();
        var freq = new Dictionary<T, int>();
        var current = _head;
        while (current != null)
        {
            freq[current.Data!] = freq.GetValueOrDefault(current.Data!) + 1;
            current = current.Next;
        }
        foreach (var kv in freq)
        {
            sb.Append(kv.Key);
            sb.Append(": ");
            sb.AppendLine(new string('*', kv.Value));
        }
        return sb.ToString();
    }

    public override string ToString() => GetForward();
}


