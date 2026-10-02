namespace week06;

using Microsoft.VisualStudio.TestTools.UnitTesting;

// DO NOT MODIFY THIS FILE

[TestClass]
public class TreeInsertTests
{
    [TestMethod]
    public void TreeInsert_Basic()
    {
        BinarySearchTree tree = new();
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);
        Assert.AreEqual("<Bst>{3, 5, 7}", tree.ToString());
    }
}