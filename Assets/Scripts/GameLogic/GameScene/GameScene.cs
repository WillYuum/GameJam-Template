using GameloopCore;

public class GameScene : GameFlowScene
{
    public override void OnEnterScene()
    {
        LoadGameUI();
        LoadGameLoop();
    }

    public override void OnExitScene()
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