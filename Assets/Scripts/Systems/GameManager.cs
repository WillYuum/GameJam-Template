using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.GenericSingletons;

public class GameManager : MonoBehaviourSingleton<GameManager>
{

    private void Start()
    {
    }

    public void StartGame()
    {

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

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
