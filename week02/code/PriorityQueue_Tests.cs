using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities.
    // Expected Result: The item with the highest priority is removed first.
    // Defect(s) Found: (Fill in after running the test.)
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Sue", 5);
        priorityQueue.Enqueue("Tim", 3);

        Assert.AreEqual("Sue", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add two items with the same highest priority.
    // Expected Result: The first item added should be removed first (FIFO).
    // Defect(s) Found: (Fill in after running the test.)
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Sue", 5);
        priorityQueue.Enqueue("Tim", 3);

        Assert.AreEqual("Bob", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Remove all items in priority order.
    // Expected Result: Items are removed highest priority first.
    // Defect(s) Found: (Fill in after running the test.)
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 8);
        priorityQueue.Enqueue("C", 4);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown.
    // Defect(s) Found: (Fill in after running the test.)
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}