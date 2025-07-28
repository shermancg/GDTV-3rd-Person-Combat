using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    private float timerValue = 0f;

    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.InputReader.JumpEvent += OnJump;
        Debug.Log("Entering Player Test State");
    }

    public override void Tick(float deltaTime)
    {

        Debug.Log("Timer: " + timerValue);

        timerValue += deltaTime;

    }

    public void OnJump()
    {
        stateMachine.SwitchState(new PlayerTestState(stateMachine));
        Debug.Log("Jump event received in PlayerTestState");
    }

    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent -= OnJump;
        Debug.Log("Exiting Player Test State");
    }


}
