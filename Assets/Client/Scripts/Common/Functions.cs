using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public static class Functions
    {
        public static long Clamp(long value, long min, long max)
        {
            if (value > max)
                return max;
            if (value < min)
                return min;
            return value;
        }
    }
}