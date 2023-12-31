using UnityEngine;

public class GamePlaying : IState
{
    GameStateManager _stateManager;

    public GamePlaying(GameStateManager stateManager)
    {
        this._stateManager = stateManager;
    }
    public void Enter()
    {
        // 最初に状態に入ったときに実行されるコード
        Debug.Log("Game Playing");
    }
    public void Update()
    {
        // フレーム単位のロジックで、新しい状態に移行するための条件を含む
        if (_stateManager.PlayerInput.IsPause)
            _stateManager.GameState.TransitionTo(_stateManager.GameState.gamePause);

        if (_stateManager.StageManager.StageClear)
            _stateManager.GameState.TransitionTo(_stateManager.GameState.gameEnd);
    }
    public void Exit()
    {
        // 状態を抜けるときに実行されるコード
    }
}
