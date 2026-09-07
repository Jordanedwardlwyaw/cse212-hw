using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace week02.code;

[TestClass]
public class PriorityQueueTests
{
    // Scenario: Enqueue items with different priorities and Dequeue them.
    // Expected Result: Higher priority items are returned first.
    // Defect Found: The loop in Dequeue missed the last element due to index < _queue.Count - 1.
    [TestMethod]
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new week02.code.PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    // Scenario: Enqueue multiple items with the SAME highest priority.
    // Expected Result: The item added first (closest to front) is returned first (FIFO).
    // Defect Found: Using >= instead of > caused LIFO order for equal priorities.
    [TestMethod]
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new week02.code.PriorityQueue();
        priorityQueue.Enqueue("FirstHigh", 5);
        priorityQueue.Enqueue("SecondHigh", 5);

        Assert.AreEqual("FirstHigh", priorityQueue.Dequeue());
        Assert.AreEqual("SecondHigh", priorityQueue.Dequeue());
    }

    // Scenario: Dequeue from an empty queue.
    // Expected Result: Throws InvalidOperationException with message "The queue is empty."
    // Defect Found: Dequeue did not throw an exception when the queue was empty.
    [TestMethod]
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new week02.code.PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}