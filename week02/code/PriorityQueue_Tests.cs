using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add two items of the same priority (One, Onebase), and one high priority item (Two)
    // Expected Result: "Two" is deleted first, then "One" (because it entered first), and only "Onebase" remains 
    // Defect(s) Found: No item was deleted
    //                  "Two" was the last item remaining
    //                  The Asset.areEqual doesn't read both items as it should
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        var One = new PriorityItem("One", 1);
        var Onebase = new PriorityItem("Onebase", 1);
        var Two = new PriorityItem("Two", 2);
        PriorityItem[] expected_outs = [Two, One, Onebase];

        priorityQueue.Enqueue("One", 1);
        priorityQueue.Enqueue("Onebase", 1);
        priorityQueue.Enqueue("Two", 2);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expected_outs.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expected_outs[i].Value, person);
            i++;
        }

    }

    [TestMethod]
    // Scenario: We insert the highest-priority items at the middle (Three) and end of the list (Two)
    // Expected Result: The highest-priority items (Three, Two) are deleted first regardless of order
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        var One = new PriorityItem("One", 1);
        var Three = new PriorityItem("Three", 3);
        var Onebase = new PriorityItem("Onebase", 1);
        var Two = new PriorityItem("Two", 2);
        PriorityItem[] expected_outs = [Three, Two, One, Onebase];

        priorityQueue.Enqueue("One", 1);
        priorityQueue.Enqueue("Three", 3);
        priorityQueue.Enqueue("Onebase", 1);
        priorityQueue.Enqueue("Two", 2);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expected_outs.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expected_outs[i].Value, person);
            i++;
        }
    }

    [TestMethod]
    // Scenario: We insert three items of the same priority (One, One1, One2) and two higher 
    //           ones that have the same (Two, Two2)
    // Expected Result: The first higher-priority items will be deleted in the order they entered 
    //                  firts Two, then Two2, then One and One2. One3 should remain as its the lowest priority one
    //                  that was inserted last
    // Defect(s) Found: None
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        var One = new PriorityItem("One", 1);
        var Two = new PriorityItem("Two", 2);
        var One2 = new PriorityItem("One2", 1);
        var One3 = new PriorityItem("One3", 1);
        var Two2 = new PriorityItem("Two2", 2);
        PriorityItem[] expected_outs = [Two, Two2, One, One2, One3];

        priorityQueue.Enqueue("One", 1);
        priorityQueue.Enqueue("Two", 2);
        priorityQueue.Enqueue("One2", 1);
        priorityQueue.Enqueue("One3", 1);
        priorityQueue.Enqueue("Two2", 2);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expected_outs.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expected_outs[i].Value, person);
            i++;
        }
    }

    // Add more test cases as needed below.
}