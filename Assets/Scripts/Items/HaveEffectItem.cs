using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;
using Core.Entities;
using System;

public class HaveEffectItem : InventoryItem, IHaveEffect
{
    public HaveEffectItem(Action func, string id) : base(func, id)
    {

    }

    public Stats GetEffect()
    {
        return new Stats(10, 10, 10, 10, 10, 10);
    }
}
