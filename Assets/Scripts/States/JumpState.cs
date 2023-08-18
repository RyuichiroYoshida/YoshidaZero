using UnityEngine;
public class JumpState : IState
{
    private PlayerController _player;

    public JumpState (PlayerController player)
    {
        this._player = player;
    }

    public void Enter()
    {
        // 最初に状態に入ったときに実行されるコード
        Debug.Log("JumpStart");
    }

    public void Update()
    {
        // ここに、別の状態に遷移するための条件が成立しているかどうかを
        // 検出するためのロジックを追加する
        if (_player != null)
        {
            if (_player.IsGruound)
            {
                if (_player.PlayerInput.XInput == 0)
                {
                    _player.PlayerStateMachine.TransitionTo(_player.PlayerStateMachine.idleState);
                }
                else
                {
                    _player.PlayerStateMachine.TransitionTo(_player.PlayerStateMachine.walkState);
                }
            }
        }
    }

    public void Exit()
    {
        // 状態を抜けるときに実行されるコード
        _player.PlayerAnimController.PlayerJumpAnim(false);
    }
}
