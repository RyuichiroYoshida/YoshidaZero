using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private PlayerController player;

    public IdleState (PlayerController player)
    {
        this.player = player;
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
        if (player != null && !player.IsGruound)
        {
            player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.jumpState);
        }
    }

    public void Exit()
    {
        // ��Ԃ𔲂���Ƃ��Ɏ��s�����R�[�h
    }
}
