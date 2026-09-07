using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace week02.code;

[TestClass]
public class TakingTurnsQueueTests
{
    // Scenario: Create a queue with Bob (2 turns), Tim (5 turns), Sue (3 turns) and dequeue until empty.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect Found: Persons with finite turns were not being decremented or properly re-enqueued when turns expired.
    [TestMethod]
    public void TestTakingTurnsQueue_FiniteTurns()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, sue, tim, tim];

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        Assert.AreEqual(0, players.Length);
    }

    // Scenario: Create a queue with Bob (2 turns), Tim (5 turns), Sue (3 turns).
    // Dequeue 5 times, then add George (3 turns), then dequeue until empty.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
    // Defect Found: Inserting new players mid-queue failed to preserve execution order due to improper state updates.
    [TestMethod]
    public void TestTakingTurnsQueue_AddPlayersAgain()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        Person[] expectedResult1 = [bob, tim, sue, bob, tim];

        for (int i = 0; i < expectedResult1.Length; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult1[i].Name, person.Name);
        }

        var george = new Person("George", 3);
        players.AddPerson(george.Name, george.Turns);

        Person[] expectedResult2 = [sue, tim, george, sue, tim, george, tim, george];

        for (int i = 0; i < expectedResult2.Length; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult2[i].Name, person.Name);
        }

        Assert.AreEqual(0, players.Length);
    }

    // Scenario: Create a queue with Bob (1 turn), Tim (infinite turns <= 0), Sue (3 turns).
    // Dequeue 10 times.
    // Expected Result: Bob, Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim
    // Defect Found: Players with turns <= 0 were being decremented or treated as finite turns instead of infinite turns.
    [TestMethod]
    public void TestTakingTurnsQueue_InfiniteTurns()
    {
        var bob = new Person("Bob", 1);
        var tim = new Person("Tim", 0);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = [bob, tim, sue, tim, sue, tim, sue, tim, tim, tim];

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }
    }

    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "No one in the queue."
    // Defect Found: Dequeue on an empty queue failed to throw the required InvalidOperationException.
    [TestMethod]
    public void TestTakingTurnsQueue_Empty()
    {
        var players = new TakingTurnsQueue();

        try
        {
            players.GetNextPerson();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("No one in the queue.", e.Message);
        }
    }
}