using UnityEngine;

public class AdventureController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private AnimationHandler _animationHandler;

    [Header("Mechanics")]
    [SerializeField] private HorizontalMovementHandler _horizontalMovementHandler;
    [SerializeField] private JumpHandler _jumpHandler;

    private AdventureState _currentState = AdventureState.Idle;
    private InputData _inputData;
    private CharacterFlipper _characterFlipper;

    private void Awake()
    {
        _characterFlipper = new CharacterFlipper();
    }

    private void Update()
    {
        _animationHandler.SetGroundState(_jumpHandler.IsGround);

        _inputData = _inputHandler.CurrentInput;

        _characterFlipper.UpdateDirection(_inputData.HorizontalInput, transform);

        _currentState = DetermineState(_inputData);

        _animationHandler.UpdateStateAnimator(_currentState);

        UpdateStateAndExecuteCommands();
    } 

    private AdventureState DetermineState(InputData inputData)
    {
        if (inputData.IsJumpPressed)
        {
            inputData.IsJumpPressed = false;
            return AdventureState.Jump;
        }

        if (!Mathf.Approximately(inputData.HorizontalInput, 0f))
        {
            return inputData.IsRunHold ? AdventureState.Running : AdventureState.Walking;
        }
        else
        {
            return AdventureState.Idle;
        }
    }

    private void UpdateStateAndExecuteCommands()
    {
        switch (_currentState)
        {
            case AdventureState.Idle:
                _horizontalMovementHandler.StopMovement();
                break;

            case AdventureState.Walking:
                _horizontalMovementHandler.ApplyMove(_inputData.HorizontalInput, false);
                break;

            case AdventureState.Running:
                _horizontalMovementHandler.ApplyMove(_inputData.HorizontalInput, true);
                break;

            case AdventureState.Jump:
                _jumpHandler.PerformJump();
                _animationHandler.AnimateJump();
                break;
        }
    }
}
