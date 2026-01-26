using UnityEngine; // Import Unity's core functionality
using UnityEngine.InputSystem; // Import Unity's new Input System for keyboard/controller input
using UnityEngine.SceneManagement; // Import scene management functionality for loading scenes

public class PlayerController : MonoBehaviour // Define a public class that inherits from MonoBehaviour
{
    Rigidbody2D physics; // Declare a variable to store reference to the 2D physics component
    public float JumpForce; // Public variable to set jump strength in the Inspector
    public float MoveForce; // Public variable to set movement strength in the Inspector

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() // Start method runs once when the game object is initialized
    {
        physics = GetComponent<Rigidbody2D>(); // Get and store the Rigidbody2D component attached to this game object
    }

    // Update is called once per frame
    void Update() // Update method runs every frame
    {
        if(Keyboard.current.upArrowKey.wasPressedThisFrame) // Check if the up arrow key was pressed this frame (not held)
        {
            physics.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse); // Apply an instant upward force for jumping
        }   

        if(Keyboard.current.rightArrowKey.isPressed == true) // Check if the right arrow key is currently being held down
        {
            physics.AddForce(Vector2.right * MoveForce); // Apply a continuous rightward force for movement
        }   

        if(Keyboard.current.leftArrowKey.isPressed == true) // Check if the left arrow key is currently being held down
        {
            physics.AddForce(Vector2.left * MoveForce); // Apply a continuous leftward force for movement
        }  
    }

    void OnTriggerEnter2D(Collider2D collision) // Called when this object enters a trigger collider (collider with isTrigger = true)
    {
        if(collision.gameObject.name == "Checkpoint") // Check if the collided object's name is "Checkpoint"
            Debug.Log("Good job, you made it to the other platform!"); // Print success message to the console
    }

    void OnCollisionEnter2D(Collision2D collision) // Called when this object collides with another non-trigger collider
    {
        if(collision.gameObject.tag == "ground") // Check if the collided object has the tag "ground"
            Debug.Log("Player hit the ground"); // Print message to console when landing
        
        if(collision.gameObject.name == "FinishLine") // Check if the collided object's name is "FinishLine"
            SceneManager.LoadScene("Level2"); // Load the scene named "Level2"
    }

    void OnCollisionExit2D(Collision2D collision) // Called when this object stops colliding with another collider
    {
         if(collision.gameObject.tag == "ground") // Check if the object we stopped colliding with has the tag "ground"
            Debug.Log("Player left the ground"); // Print message to console when leaving the ground (jumping/falling)
    }
}