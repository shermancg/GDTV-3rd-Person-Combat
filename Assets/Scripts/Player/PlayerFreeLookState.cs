using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{



    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    readonly int FreeLookMovementSpeedHash = Animator.StringToHash("FreeLookSpeed");
    const float AnimatorDampTime = 0.1f;

    public override void Enter()
    {

    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();

        stateMachine.CharacterController.Move(movement * stateMachine.FreeLookMovementSpeed * deltaTime);

        // This says if the player is not moving, set the speed to 0
        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            // Parameters are (Animation Parameter, Value 0 or 1, Damp Time, Delta Time)
            stateMachine.Animator.SetFloat(FreeLookMovementSpeedHash, 0f, AnimatorDampTime, deltaTime);
            return;
        }

        // If the player is moving, set the speed to 1
        stateMachine.Animator.SetFloat(FreeLookMovementSpeedHash, 1f, AnimatorDampTime, deltaTime);

        FaceMovementDirection(movement, deltaTime);

    }

    public override void Exit()
    {

    }

    private Vector3 CalculateMovement()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        return (forward * stateMachine.InputReader.MovementValue.y) + (right * stateMachine.InputReader.MovementValue.x);
        
    }

    /// <summary>
    /// Smoothly rotates the player to face the direction of movement using linear interpolation.
    /// </summary>
    /// <param name="movement">The movement direction vector to face.</param>
    /// <param name="deltaTime">The time elapsed since the last frame, used to control rotation speed.</param>
    /// <remarks>
    /// This method interpolates the player's rotation from its current orientation to the target orientation
    /// based on the movement direction, providing smooth turning. The rotation speed is controlled by
    /// <c>stateMachine.RotationDamping</c>.
    /// 
    /// <c>stateMachine.transform.rotation = Quaternion.Lerp(...)</c>:
    ///     Interpolates the player's rotation towards the movement direction for smooth facing.
    /// </remarks>
    private void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        // This lerps from the current rotation to the target rotation based on the movement direction
        stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation, // Current rotation
            Quaternion.LookRotation(movement), // Target rotation
            deltaTime * stateMachine.RotationDamping); // 
    }
    

}
