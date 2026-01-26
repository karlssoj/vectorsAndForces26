using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D physics;
    public float JumpForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            //physics.AddForce(Vector2.up * 5);
            physics.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }   

        if(Keyboard.current.rightArrowKey.isPressed == true)
        {
            physics.AddForce(Vector2.right * 30);
        }   
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("The player passed the finish line"!);
        SceneManager.LoadScene("Level2");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            Debug.Log("Player on the ground");
        
        if(collision.gameObject.name == "Elevator")
            Debug.Log("Entered elevator");
    }
}
