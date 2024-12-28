/*
Simple 2D top-down movement script for a player. Requires Rigidbody2D and a Camera following the player
Created by: Mohamed Brahimi
*/

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body; // The Rigidbody2D of the player
    public Camera cam; // The camera following the player

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f; // Speed of the player
    public float cameraFollowSpeed = 2f; // Speed at which the camera follows the player

    void Start()
    {
        body = GetComponent<Rigidbody2D>(); // Sets the rigidbody to the rigidbody of the player automatically
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        // Takes horizontal and vertical inputs (WASD / Arrows) and places them in these variables

        Vector3 cameraNewPosition = new Vector3(transform.position.x, transform.position.y, -10f);
        // Camera's new position should be right above the player

        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraNewPosition, cameraFollowSpeed * Time.deltaTime);
        // Smoothly moves the camera from its initial position to its new position (over the player) using cameraFollowSpeed
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // If there is movement detected on the horizontal and vertical axes, limit the movement speed diagonally
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 

        body.linearVelocity = new Vector2(horizontal * runSpeed, vertical * runSpeed); // Moves
    }
}
