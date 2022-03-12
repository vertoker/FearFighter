using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using InventorySystem;

public class InventoryTest
{
    [Test]
    public void AddToEmptyInventory()
    {
        InventoryController.ClearInventory();
        InventoryController.AddItem(new InventoryItem(null, "first"));
        Assert.AreEqual(1, InventoryController.GetItemNumber("first"));
    }

    [Test]
    public void AddDuplicateItems()
    {
        InventoryController.ClearInventory();
        InventoryController.AddItem(new InventoryItem(null, "second"));
        InventoryController.AddItem(new InventoryItem(null, "second"));

        Assert.AreEqual(2, InventoryController.GetItemNumber("second"));
    }


    [Test]
    public void RemoveItem()
    {
        InventoryController.ClearInventory();
        InventoryController.AddItem(new InventoryItem(null, "third"));

        Assert.AreEqual(1, InventoryController.GetItemNumber("third"));

        InventoryController.RemoveItem("third");

        Assert.AreEqual(0, InventoryController.GetItemNumber("third"));
    }

    [Test]
    public void GetItems()
    {
        InventoryController.ClearInventory();

        InventoryController.AddItem(new InventoryItem(null, "fouth"));
        InventoryController.AddItem(new InventoryItem(null, "fouth"));
        InventoryController.AddItem(new InventoryItem(null, "fives"));

        Assert.AreEqual(2, InventoryController.GetItems().Count);
    }
}
