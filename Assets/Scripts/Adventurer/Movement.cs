using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private Vector2 direction;

    private float walkSpeed = 1f;

    private float rayDistance = 1f;

    public SpriteRenderer sprite;

    public LayerMask layerMask;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetMoveInput();
        if (IsGround() && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetMoveInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
    }

    private void Move()
    {
        rigidBody.velocity = new Vector2(direction.x * walkSpeed, rigidBody.velocity.y);
    }

    private void Jump()
    {
        rigidBody.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
    }

    private bool IsGround()
    {
        return Physics2D.Raycast(transform.position, -transform.up, rayDistance, layerMask);
    }
}
