using CustomUnityUtils;
using GameloopCore;

public class GameScene : GameFlowScene
{
    public override void OnEnter()
    {
        UnityUtils.SwitchToScene("GameScene", () =>
        {
            LoadGameUI();
            LoadGameLoop();
        });
    }

    public override void OnExit()
    {
    }



    private void LoadGameUI()
    {

    }

    private void LoadGameLoop()
    {
        GameloopBehavior gameSceneLoop = GameloopBehavior.Create<GameSceneLoop>("gameSceneLoop");
        gameSceneLoop.Play();
    }
}