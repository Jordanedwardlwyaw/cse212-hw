namespace week02.code;

public class PriorityQueue
{
    private readonly List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        var newItem = new PriorityItem(value, priority);
        _queue.Add(newItem);
    }

    /// <summary>
    /// Remove and return the item with the highest priority.
    /// If there are ties, remove the item closest to the front of the queue (FIFO).
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority
        var highPriorityIndex = 0;
        for (var index = 1; index < _queue.Count; index++)
        {
            // Use strictly > to maintain FIFO order for equal priorities
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // Remove and return the item with the highest priority
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }

    // Inner class representing items with priorities
    internal class PriorityItem
    {
        internal string Value { get; }
        internal int Priority { get; }

        internal PriorityItem(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }

        public override string ToString()
        {
            return $"{Value} (Pri:{Priority})";
        }
    }
}