using System.Collections.Generic;
using UnityEngine;


namespace Utils.ArrayUtils
{
    [System.Serializable]
    public class PseudoRandArray<T>
    {
        [SerializeField] private T[] _array;

        public int Length { get { return _array.Length; } }

        private int _index;

        public PseudoRandArray(T[] array)
        {
            _array = array;
            _index = 0;
        }

        public T PickNext()
        {
            if (_index >= _array.Length)
            {
                _index = 0;
            }
            return _array[_index++];
        }
    }


    public static class ArrayTools
    {
        [System.Serializable]
        public class PsuedoRandArray<T>
        {
            public T[] items;
            private int _currentIndex = 0;
            public PsuedoRandArray(params T[] _items)
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
                    Debug.LogError("Array is null in psuedo random array of TYPE: " + typeof(T).ToString());
                }
#endif

                ArrayTools.ShuffleArray(items);
            }
        }


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
}