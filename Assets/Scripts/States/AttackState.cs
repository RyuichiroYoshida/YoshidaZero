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
        // �ŏ��ɏ�Ԃɓ������Ƃ��Ɏ��s�����R�[�h
        Debug.Log("AttackStart");
        _player.IsAttacking = false;
    }
    public void Update()
    {
        // �t���[���P�ʂ̃��W�b�N�ŁA�V������ԂɈڍs���邽�߂̏������܂�
        if (_player.PlayerAttack.AttackEnd() == false)
        {
            _player.PlayerStateMachine.TransitionTo(_player.PlayerStateMachine.idleState);
        }
    }
    public void Exit()
    {
        // ��Ԃ𔲂���Ƃ��Ɏ��s�����R�[�h   
        _player.PlayerAnimController.PlayerAttackAnim(false);
    }
}
