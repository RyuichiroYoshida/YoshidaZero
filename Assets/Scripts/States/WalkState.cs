using UnityEngine;

public class WalkState : IState
{
    private PlayerController _player;

    public WalkState (PlayerController player)
    {
        this._player = player;
    }

    public void Enter()
    {
        // �ŏ��ɏ�Ԃɓ������Ƃ��Ɏ��s�����R�[�h
        Debug.Log("WalkStart");
    }

    public void Update()
    {
        // �����ɁA�ʂ̏�ԂɑJ�ڂ��邽�߂̏������������Ă��邩�ǂ�����
        // ���o���邽�߂̃��W�b�N��ǉ�����
        
        if (_player != null)
        {
            if (!_player.IsGruound)
            {
                _player.PlayerStateMachine.TransitionTo(_player.PlayerStateMachine.jumpState);
                _player.PlayerAnimController.PlayerJumpAnim(true);
            }

            if (_player.PlayerInput.XInput == 0)
            {
                _player.PlayerStateMachine.TransitionTo(_player.PlayerStateMachine.idleState);
            }
        }
    }

    public void Exit()
    {
        // ��Ԃ𔲂���Ƃ��Ɏ��s�����R�[�h
        _player.PlayerAnimController.PlayerMoveAnim(false);
    }
}