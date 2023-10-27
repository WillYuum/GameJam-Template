using GameloopCore;

public class GameScene : GameFlowScene
{
    private GameSceneLoop _gameSceneLoop;

    public override void OnEnter()
    {
        LoadGameUI();
        LoadGameLoop();
    }

    public override void OnExit()
    {
        _gameSceneLoop.End();
    }



    private void LoadGameUI()
    {

    }

    private void LoadGameLoop()
    {
        _gameSceneLoop = GameloopBehavior.Create<GameSceneLoop>("gameSceneLoop");
        _gameSceneLoop.Play();
    }
}