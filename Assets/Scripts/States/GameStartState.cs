using UnityEngine;

public class GameStartState : IState
{
    GameStateManager stateManager;

    public GameStartState(GameStateManager stateManager)
    {
        this.stateManager = stateManager;
    }
    public void Enter()
    {
        // 最初に状態に入ったときに実行されるコード
        Debug.Log("Game Start");
    }
    public void Update()
    {
        // フレーム単位のロジックで、新しい状態に移行するための条件を含む
        stateManager.GameState.TransitionTo(stateManager.GameState.gamePrepare);
    }
    public void Exit()
    {
        // 状態を抜けるときに実行されるコード
    }
}
