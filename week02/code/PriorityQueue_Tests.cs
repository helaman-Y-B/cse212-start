using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Three items with different priorities are enqueued. Itmes: Chair(2), Table(5), Lamp(3). Dequeue is called once.
    // Expected Result: Table
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Chair", 2);
        priorityQueue.Enqueue("Table", 5);
        priorityQueue.Enqueue("Lamp", 3);
        Assert.AreEqual("Table", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Two items have the same highest priority. Items: Notebook(2), Pen(4), Book(4). Dequeue is called once. The one that needs to be dequeued is the Pen
    // Expected Result: Pen
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Notebook", 1);
        priorityQueue.Enqueue("Pen", 4);
        priorityQueue.Enqueue("Book", 4);
        Assert.AreEqual("Pen", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: If a empty queue is called, then an error should appear.
    // Expected Result: InvalidOperationException "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}