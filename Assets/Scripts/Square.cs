using UnityEngine;

public class Square : MonoBehaviour
{
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("It is Player!!!");
        }

        InputHandler inputHandler = collision.gameObject.GetComponent<InputHandler>();

        if (inputHandler is null)
        {
            Debug.LogError($"{collision.gameObject.name} doesn't have {nameof(InputHandler)}");
            return;
        }

        Debug.Log($"IsRunHold: {inputHandler.CurrentInput.IsRunHold}");
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Show UI message
        Debug.Log("OnTriggerEnter2D");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Hide UI message
        Debug.Log("OnTriggerExit2D");

        Destroy(gameObject);
    }
}
