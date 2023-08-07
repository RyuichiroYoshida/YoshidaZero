using UnityEngine;

public class WalkState : IState
{
    private PlayerController player;

    public WalkState (PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        // 最初に状態に入ったときに実行されるコード
        Debug.Log("walkStart");
    }

    public void Update()
    {
        // ここに、別の状態に遷移するための条件が成立しているかどうかを
        // 検出するためのロジックを追加する
        
        if (player != null)
        {
            if (!player.IsGruound)
            {
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.jumpState);
            }

            if (player.PlayerInput.XInput == 0)
            {
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.idleState);
            }
        }
    }

    public void Exit()
    {
        // 状態を抜けるときに実行されるコード
    }
}
