using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private SpriteRenderer sprite;

    private Vector2 direction;

    private float walkSpeed = 10f;

    [SerializeField]
    private float rayDistance = 1f;

    [SerializeField]
    private LayerMask layerMask;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        //Debug.Log($"Update time: {Time.time}");
        GetMoveInput();

        if (Physics2D.Raycast(transform.position, -transform.up, rayDistance, layerMask))
        {
            sprite.color = Color.red;
        }
        else
        {
            sprite.color = Color.blue;
        }
    }

    private void FixedUpdate()
    {
        // Debug.Log($"FixedUpdate time: {Time.time}");
        Move();
    }

    private void GetMoveInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
    }

    private void Move()
    {
        rigidBody.velocity = new Vector2(direction.x * walkSpeed, rigidBody.velocity.y);
        //rigidBody.AddForce(direction * 30f);
    }
}
