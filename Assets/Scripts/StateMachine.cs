using System;

[Serializable]
public class StateMachine
{
    public IState CurrentState { get; private set; }

    public GameStartState gameStart;
    public GamePrepare gamePrepare;
    public GamePlaying gamePlaying;
    public GamePause gamePause;
    public GameEnd gameEnd;

    public event Action<IState> StateChanged;

    public StateMachine(GameStateManager gameState)
    {
        this.gameStart = new GameStartState(gameState);
        this.gamePrepare = new GamePrepare(gameState);
        this.gamePlaying = new GamePlaying(gameState);
        this.gamePause = new GamePause(gameState);
        this.gameEnd = new GameEnd(gameState);
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
