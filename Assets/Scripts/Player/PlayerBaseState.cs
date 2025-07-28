using UnityEngine;

public abstract class PlayerBaseState : State
{
    // Protected is like public but only accessible within this class and inhereted classes
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;

    }
}
