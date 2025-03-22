using UnityEngine;

public class Square : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // rigidBody.AddTorque(15f);
    }
}
