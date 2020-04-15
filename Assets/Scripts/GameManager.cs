using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    Tutorial tutorialSystem;

    [HideInInspector] public bool gameIsOn = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        tutorialSystem = GameManager.instance.GetComponent<Tutorial>();
    }

    public GameObject introBackground;
    public void StartGame()
    {
        introBackground.SetActive(false);
        gameIsOn = true;
    }

    public void WinGame()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseGame()
    {
        gameIsOn = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
