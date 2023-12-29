using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f; // Adjust the speed as needed

    void Update()
    {
        // Get WASD input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Move the object based on input
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
