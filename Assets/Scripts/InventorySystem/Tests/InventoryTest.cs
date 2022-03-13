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
        InventoryController inventory = new InventoryController();
        inventory.ClearInventory();
        inventory.AddItem(new InventoryItem(null, "first"));
        Assert.AreEqual(1, inventory.GetItemNumber("first"));
    }

    [Test]
    public void AddDuplicateItems()
    {
        InventoryController inventory = new InventoryController();
        inventory.AddItem(new InventoryItem(null, "second"));
        inventory.AddItem(new InventoryItem(null, "second"));

        Assert.AreEqual(2, inventory.GetItemNumber("second"));
    }


    [Test]
    public void RemoveItem()
    {
        InventoryController inventory = new InventoryController();
        inventory.AddItem(new InventoryItem(null, "third"));

        Assert.AreEqual(1, inventory.GetItemNumber("third"));

        inventory.RemoveItem("third");

        Assert.AreEqual(0, inventory.GetItemNumber("third"));
    }

    [Test]
    public void GetItems()
    {
        InventoryController inventory = new InventoryController();

        inventory.AddItem(new InventoryItem(null, "fouth"));
        inventory.AddItem(new InventoryItem(null, "fouth"));
        inventory.AddItem(new InventoryItem(null, "fives"));

        Assert.AreEqual(2, inventory.GetItems().Count);
    }
}
