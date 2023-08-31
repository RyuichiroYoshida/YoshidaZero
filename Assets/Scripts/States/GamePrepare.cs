using UnityEngine;

public class GamePrepare : IState
{
    GameStateManager _stateManager;

    public GamePrepare(GameStateManager stateManager)
    {
        this._stateManager = stateManager;
    }
    public void Enter()
    {
        // 最初に状態に入ったときに実行されるコード
        Debug.Log("Game Prepare");
    }
    public void Update()
    {
        // フレーム単位のロジックで、新しい状態に移行するための条件を含む
    }
    public void Exit()
    {
        // 状態を抜けるときに実行されるコード   
    }
}
