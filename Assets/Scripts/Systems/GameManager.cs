using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.GenericSingletons;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public void StartGame()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
