using UnityEngine;

public abstract class PlayerBaseState : State
{
    // Protected is like public but only accessible within this class and inhereted classes
    protected PlayerStateMachine playerStateMachine;

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;

    }
}
