using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }

    void Awake()
    {
        SwitchState(new PlayerTestState(this));
    }

}
