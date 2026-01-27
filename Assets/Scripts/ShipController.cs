using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    Vector2 Velocity;
    float Speed = 3;

    void Update()
    {
        // Reset velocity each frame
        Velocity = new Vector2(0, 0);

        // Check right arrow
        if(Keyboard.current.rightArrowKey.isPressed)
        {
            Velocity.x = 1;
        }
        
        // Check left arrow
        if(Keyboard.current.leftArrowKey.isPressed)
        {
            Velocity.x = -1;
        }
        
        // Check up arrow
        if(Keyboard.current.upArrowKey.isPressed)
        {
            Velocity.y = 1;
        }
        
        // Check down arrow
        if(Keyboard.current.downArrowKey.isPressed)
        {
            Velocity.y = -1;
        }
        
        // Move the ship using the normalized vector multiplied by a Speed scalar
        transform.Translate(Velocity.normalized * Speed * Time.deltaTime);
    }
}