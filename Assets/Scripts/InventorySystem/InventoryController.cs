using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace InventorySystem
{
    public class InventoryController
    {
        public static Dictionary<InventoryItem, int> inventory;


        /// <summary>
        /// Добавляет новый предмет в инвентарь
        /// </summary>
        /// <param name="item">Объект для добавления</param>
        public static void AddItem(InventoryItem item)
        {
            if (inventory == null)
                inventory = new Dictionary<InventoryItem, int>();

            foreach (var it in inventory)
            {
                if (it.Key.id == item.id)
                {
                    inventory[it.Key]++;
                    return;
                }
            }

            inventory.Add(item, 1);

            Debug.Log("Add item with " + item.id + " id");
        }


        /// <summary>
        /// Удаляет единицу предмета из инвентаря
        /// </summary>
        /// <param name="id">id предмета</param>
        public static void RemoveItem(string id)
        {
            if (inventory == null)
                return;

            InventoryItem itemForRemove = null;

            foreach (var item in inventory)
            {
                if (item.Key.id == id)
                {
                    itemForRemove = item.Key;
                    break;
                }
            }

            inventory[itemForRemove]--;
            if (inventory[itemForRemove] <= 0)
                inventory.Remove(itemForRemove);
        }


        /// <summary>
        /// Количество определённого предмета в инвентаре
        /// </summary>
        /// <param name="id">id предмета</param>
        /// <returns>Количество предмета</returns>
        public static int GetItemNumber(string id)
        {
            if (inventory == null)
                return 0;

            foreach (var item in inventory)
            {
                if (item.Key.id == id)
                    return item.Value;
            }

            return 0;
        }


        /// <summary>
        /// Количество определённого предмета в инвентаре
        /// </summary>
        /// <typeparam name="T">Тип предмета</typeparam>
        /// <returns>Количество предмета</returns>
        public static int GetItemNumber<T>()
            where T: InventoryItem
        {
            if (inventory == null)
                return 0;

            var tmp = inventory.Keys.OfType<T>().ToArray();

            return tmp.Length == 0 ? 0 : inventory[tmp[0]];
        }


        /// <summary>
        /// Возвращает список различных предметов в инвенторе игрока
        /// </summary>
        /// <returns></returns>
        public static List<InventoryItem> GetItems()
        {
            if (inventory == null)
                return null;

            return inventory.Keys.ToList();
        }


        /// <summary>
        /// Очищает инвентарь
        /// </summary>
        public static void ClearInventory()
        {
            if (inventory != null)
                inventory.Clear();
        }
    }
}