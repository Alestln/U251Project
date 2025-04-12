using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HorizontalMovementHandler : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;

    private Rigidbody2D _rigidBody;
    private float _currentDirection = 0f;
    private float _currentSpeed = 0f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidBody.velocity = new Vector2(_currentSpeed * _currentDirection, _rigidBody.velocity.y);
    }

    public void ApplyMove(float direction, bool isRunning)
    {
        _currentDirection = direction;
        _currentSpeed = isRunning ? _runSpeed : _walkSpeed;
    }

    public void StopMovement()
    {
        _currentDirection = 0f;
        _currentSpeed = 0f;
    }
}