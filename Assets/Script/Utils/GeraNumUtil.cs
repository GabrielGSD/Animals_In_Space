using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.utils
{
    public static class GeraNumUtil
    {
        public static List<int> getUniqueRandomArray(int min, int max, int count) {
            int[] result = new int[count];
            List<int> numbersInOrder = new List<int>();
            for (var x = min; x < max; x++) {
                numbersInOrder.Add(x);
            }
            for (var x = 0; x < count; x++) {
                var randomIndex = Random.Range(0, numbersInOrder.Count);
                result[x] = numbersInOrder[randomIndex];
                numbersInOrder.RemoveAt(randomIndex);
            }
            return new List<int>(result);
        }

    }
}