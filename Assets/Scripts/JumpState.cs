using UnityEngine;
public class JumpState : IState
{
    private PlayerController player;

    public JumpState (PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        // �ŏ��ɏ�Ԃɓ������Ƃ��Ɏ��s�����R�[�h
        Debug.Log("JumpStart");
    }

    public void Update()
    {
        // �����ɁA�ʂ̏�ԂɑJ�ڂ��邽�߂̏������������Ă��邩�ǂ�����
        // ���o���邽�߂̃��W�b�N��ǉ�����
        if (player.IsGruound)
        {
            if (player.PlayerInput.XInput == 0 && player.PlayerInput.YInput == 0)
            {
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.idleState);
            }
        }
    }

    public void Exit()
    {
        // ��Ԃ𔲂���Ƃ��Ɏ��s�����R�[�h
    }
}
