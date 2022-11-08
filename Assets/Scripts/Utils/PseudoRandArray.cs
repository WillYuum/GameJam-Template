using System.Collections.Generic;
using UnityEngine;


namespace Utils.ArrayUtils
{
    public static class ArrayTools
    {
        public static void ShuffleList<T>(List<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                T tmp = list[i];
                int randIndex = Random.Range(0, list.Count);  //By replacing 'i' with 0, you might get a more randomized array.
                list[i] = list[randIndex];
                list[randIndex] = tmp;
            }
        }

        public static void ShuffleArray<T>(T[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                T tmp = array[i];
                int randIndex = Random.Range(0, array.Length);  //By replacing 'i' with 0, you might get a more randomized array.
                array[i] = array[randIndex];
                array[randIndex] = tmp;
            }
        }
    }


    [System.Serializable]
    public class PseudoRandArray<T>
    {
        public T[] items;
        private int _currentIndex = 0;
        public PseudoRandArray(params T[] _items)
        {
            if (_items == null)
            {
                _items = new T[] { };
            }
            else
            {
                items = _items;
            }
        }

        public T PickNext()
        {
            T selectedItem = items[_currentIndex];

            _currentIndex += 1;
            if (_currentIndex >= items.Length)
            {
                ArrayTools.ShuffleArray(items);
                _currentIndex = 0;
            }

            return selectedItem;
        }

        public void ShuffleArray()
        {
#if UNITY_EDITOR
            if (items == null)
            {
                Debug.LogError("Array is null in pseudo random array of TYPE: " + typeof(T).ToString());
            }
#endif

            ArrayTools.ShuffleArray(items);
        }
    }
}