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
        // �ŏ��ɏ�Ԃɓ������Ƃ��Ɏ��s�����R�[�h
        Debug.Log("IdleStart");
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
            }

            if (_player.IsGruound && _player.PlayerInput.XInput != 0)
            {
                _player.PlayerStateMachine.TransitionTo(_player.PlayerStateMachine.walkState);
            }
        }
    }

    public void Exit()
    {
        // ��Ԃ𔲂���Ƃ��Ɏ��s�����R�[�h
    }
}
