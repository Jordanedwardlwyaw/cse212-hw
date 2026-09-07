namespace week02.code;

/// <summary>
/// A basic implementation of a Queue using a List internally.
/// Items are added to the back (index Count) and removed from the front (index 0).
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    public void Enqueue(Person person)
    {
        _queue.Add(person); // Add to the back of the queue
    }

    public Person Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var person = _queue[0]; // Remove from the front of the queue
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty()
    {
        return _queue.Count == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}