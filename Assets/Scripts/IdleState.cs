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
        // 最初に状態に入ったときに実行されるコード
        Debug.Log("IdleStart");
    }

    public void Update()
    {
        // ここに、別の状態に遷移するための条件が成立しているかどうかを
        // 検出するためのロジックを追加する
        if (player != null && !player.IsGruound)
        {
            player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.jumpState);
        }
    }

    public void Exit()
    {
        // 状態を抜けるときに実行されるコード
    }
}
