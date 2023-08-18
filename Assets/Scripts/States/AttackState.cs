using UnityEngine;

public class AttackState : IState
{
    private PlayerController _player;

    public AttackState (PlayerController player)
    {
        this._player = player;
    }

    public void Enter()
    {
        // 最初に状態に入ったときに実行されるコード
        Debug.Log("AttackStart");
        _player.IsAttacking = false;
    }
    public void Update()
    {
        // フレーム単位のロジックで、新しい状態に移行するための条件を含む
        if (_player.PlayerAttack.AttackEnd() == false)
        {
            _player.PlayerStateMachine.TransitionTo(_player.PlayerStateMachine.idleState);
        }
    }
    public void Exit()
    {
        // 状態を抜けるときに実行されるコード   
        _player.PlayerAnimController.PlayerAttackAnim(false);
    }
}
