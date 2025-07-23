using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    private float timerValue = 0f;

    public PlayerTestState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering Player Test State");
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("Timer: " + timerValue);

        timerValue += deltaTime;
        if (timerValue >= 5f)
        {
            Debug.Log("Test value exceeded 5 seconds, switching state...");
            playerStateMachine.SwitchState(new PlayerTestState(playerStateMachine)); // Example of switching to the same state
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Player Test State");
    }

}
