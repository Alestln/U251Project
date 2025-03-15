using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private Vector2 direction;

    private float walkSpeed = 10f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetMoveInput();
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
}
