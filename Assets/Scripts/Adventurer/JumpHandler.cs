using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpHandler : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _doubleJumpForce;
    [SerializeField] private float _doubleJumpDelay;

    [Header("Ground Check")]
    [SerializeField] private float _groundCheckDistance;
    [SerializeField] private LayerMask _groundMask;

    private Rigidbody2D _rigidBody;
    private bool _canDoubleJump;

    public bool IsGround { get; private set; }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance, _groundMask);
        IsGround = hit.collider is not null;

        Debug.DrawRay(transform.position, Vector2.down * _groundCheckDistance, Color.red);
    }

    public void PerformJump()
    {
        if (IsGround)
        {
            ApplyJump(_jumpForce);

            StartCoroutine(EnableDoubleJump());
        }
        else if (_canDoubleJump)
        {
            ApplyJump(_doubleJumpForce);
            _canDoubleJump = false;
        }
    }

    private void ApplyJump(float jumpForce)
    {
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, jumpForce);
    }

    private IEnumerator EnableDoubleJump()
    {
        yield return new WaitForSeconds(_doubleJumpDelay);

        _canDoubleJump = true;
    }
}