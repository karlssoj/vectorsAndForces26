using UnityEngine; // Import Unity's core functionality
using UnityEngine.InputSystem; // Import Unity's new Input System (not currently used in this script)

public class ElevatorController : MonoBehaviour // Define a public class that inherits from MonoBehaviour
{
    Rigidbody2D physics; // Declare a variable to store reference to the 2D physics component
    public float Speed = 1; // Public variable to set movement speed, default value is 1

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() // Start method runs once when the game object is initialized
    {
        physics = GetComponent<Rigidbody2D>(); // Get and store the Rigidbody2D component attached to this game object
    }

    // Update is called once per frame
    void Update() // Update method runs every frame
    {
        physics.MovePosition(physics.position + Vector2.right * Speed * Time.deltaTime); // Move the rigidbody to the right smoothly using MovePosition (proper for kinematic rigidbodies)
        // Vector2.right * Speed creates rightward movement, Time.deltaTime makes it frame-rate independent
    }

    void OnCollisionEnter2D(Collision2D collision) // Called when this object collides with another non-trigger collider
    {
        if(collision.gameObject.name == "Platform") // Check if the collided object's name is "Platform"
            Speed = 0; // Set speed to zero to stop the elevator's movement
    }
}