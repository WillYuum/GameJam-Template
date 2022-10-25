using System.Collections.Generic;
using UnityEngine;

public static class UtilityHelper
{
    public static T SelectRandomFromArray<T>(T[] array)
    {
        int index = UnityEngine.Random.Range(0, array.Length);
        T selectedElem = array[index];
        return selectedElem;
    }

    public static void ShuffleList<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            T tmp = list[i];
            int randIndex = Random.Range(i, list.Count);  //By replacing 'i' with 0, you might get a more randomized array.
            list[i] = list[randIndex];
            list[randIndex] = tmp;
        }
    }

    public static void ShuffleArray<T>(T[] array)
    {

        for (int i = array.Length - 1; i > 0; i--)
        {
            T tmp = array[i];
            int randIndex = Random.Range(i, array.Length);  //By replacing 'i' with 0, you might get a more randomized array.
            array[i] = array[randIndex];
            array[randIndex] = tmp;
        }
    }

    public static GameObject[] GetChildren(GameObject parent)
    {
        GameObject[] children = new GameObject[parent.transform.childCount];
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            children[i] = parent.transform.GetChild(i).gameObject;
        }

        return children;
    }
}
