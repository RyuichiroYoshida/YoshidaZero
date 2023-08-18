using UnityEngine;

public class IdleState : IState
{
    private PlayerController _player;

    public IdleState (PlayerController player)
    {
        this._player = player;
    }
    public void Enter()
    {
        // 最初に状態に入ったときに実行されるコード
        Debug.Log("IdleStart");
    }

    public void Update()
    {
        // ここに、別の状態に遷移するための条件が成立しているかどうかを
        // 検出するためのロジックを追加する
        if (_player != null)
        {
            if (!_player.IsGruound)
            {
                _player.PlayerStateMachine.TransitionTo(_player.PlayerStateMachine.jumpState);
                _player.PlayerAnimController.PlayerJumpAnim(true);
            }

            if (_player.IsGruound && _player.PlayerInput.XInput != 0)
            {
                _player.PlayerStateMachine.TransitionTo(_player.PlayerStateMachine.walkState);
                _player.PlayerAnimController.PlayerMoveAnim(true);
            }

            if (_player.IsAttacking)
            {
                _player.PlayerStateMachine.TransitionTo (_player.PlayerStateMachine.attackState);
                _player.PlayerAnimController.PlayerAttackAnim(true);
            }
        }
    }

    public void Exit()
    {
        // 状態を抜けるときに実行されるコード
    }
}
