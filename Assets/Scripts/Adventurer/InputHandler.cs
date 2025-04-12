using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public InputData CurrentInput { get; private set; }

    private void Update()
    {
        CurrentInput = new InputData
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal"),
            IsRunHold = Input.GetKey(KeyCode.LeftShift),
            IsJumpPressed = Input.GetKeyDown(KeyCode.Space)
        };
    }
}