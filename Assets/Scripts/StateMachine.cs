using System;

[Serializable]
public class StateMachine
{
    public IState CurrentState { get; private set; }

}
