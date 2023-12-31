using UnityEngine;

public class GameEnd : IState
{
    GameStateManager _stateManager;

    public GameEnd(GameStateManager stateManager)
    {
        this._stateManager = stateManager;
    }
    public void Enter()
    {
        // 最初に状態に入ったときに実行されるコード
        Debug.Log("Game End");
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
