using System;

[Serializable]
public class StateMachine
{
    public IState CurrentState { get; private set; }

    //public WalkState walkState;
    //public JumpState jumpState;
    //public IdleState idleState;
    //public AttackState attackState;

    public event Action<IState> StateChanged;

    public StateMachine(GameStateManager gameState)
    {
        //this.walkState = new WalkState(player);
        //this.jumpState = new JumpState(player);
        //this.idleState = new IdleState(player);
        //this.attackState = new AttackState(player);
    }

    public void Initialize(IState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();

        StateChanged?.Invoke(nextState);
    }

    public void Update()
    {
        CurrentState?.Update();
    }

}
