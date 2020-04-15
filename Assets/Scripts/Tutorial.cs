using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameObject tutorialMainNode;
    List<GameObject> tutorials = new List<GameObject>();
    private int currentTutorialToShow = 0;

    void Start()
    {
        PrepareTutorials();
    }

    public void SwitchToNextTutorial()
    {
        //Handles deactivating last tutorial
        if (currentTutorialToShow == tutorials.Count - 1)
        {
            HideTutorial();
            Debug.LogWarning("The amount of tutorials are finished");
            return;
        }
        HideTutorial();
        currentTutorialToShow += 1;
        ShowTutorial();
    }

    public void ShowFirstTutorial()
    {
        tutorials[0].SetActive(true);
    }

    private void ShowTutorial()
    {
        tutorials[currentTutorialToShow].SetActive(true);
    }

    private void HideTutorial()
    {
        tutorials[currentTutorialToShow].SetActive(false);
    }

    private void PrepareTutorials()
    {
        if(tutorialMainNode.transform.childCount <= 0) return;
        foreach (Transform tutorialNode in tutorialMainNode.transform)
        {
            tutorials.Add(tutorialNode.GetComponent<GameObject>());
        }
        foreach (var tutorial in tutorials)
        {
            tutorial.SetActive(false);
        }
        ShowFirstTutorial();
    }
}
