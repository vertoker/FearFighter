using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public static class Formulas
    {
        public static int ArmorMultiplier(int damage, int armor)
        {
            return (int)(damage * ArmorResist(armor));
        }

        public static float ArmorResist(int armor)
        {
            return 1 - (Constants.ARMORFACTOR * armor) / (1 + Constants.ARMORFACTOR * Mathf.Abs(armor));
        }
    }
}