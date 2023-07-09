using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.GenericSingletons;

public class GameManager : MonoBehaviourSingleton<GameManager>
{

    void Awake()
    {
        AudioManager.instance.Load();
    }


    void Start()
    {
        print("GameManager Start");

        GameFlowManager.instance.SwitchToScene<GameScene>();
    }


    public void ForceRestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
