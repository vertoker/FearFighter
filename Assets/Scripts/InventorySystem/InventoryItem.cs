using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace InventorySystem
{
    public class InventoryItem
    {
        private Action usingFunction;   // Функция использования

        public string id { get; private set; }

        public static event Action<InventoryItem> ItemUsedEvent;


        /// <summary>
        /// Создаёт новый объект для добавления в инвентарь
        /// </summary>
        /// <param name="sprite">Спрайт объекта</param>
        /// <param name="func">Функция использования объекта</param>
        /// <param name="id">id объекта</param>
        public InventoryItem(Action func, string id)
        {
            usingFunction = func;
            this.id = id;
        }


        /// <summary>
        /// Использует предмет 
        /// </summary>
        public void UseItem()
        {
            usingFunction();
            ItemUsedEvent?.Invoke(this);
        }
    }
}