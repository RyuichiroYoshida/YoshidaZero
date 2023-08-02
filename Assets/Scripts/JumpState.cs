public class JumpState : IState
{
    private PlayerController player;

    public JumpState (PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        // 最初に状態に入ったときに実行されるコード
    }

    public void Update()
    {
        // ここに、別の状態に遷移するための条件が成立しているかどうかを
        // 検出するためのロジックを追加する
    }

    public void Exit()
    {
        // 状態を抜けるときに実行されるコード
    }
}
