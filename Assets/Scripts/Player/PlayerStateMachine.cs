using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    void Awake()
    {
        SwitchState(new PlayerTestState(this));
    }

}
