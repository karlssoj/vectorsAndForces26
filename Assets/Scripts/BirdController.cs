using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame by the game engine
    void Update()
    {
        //For each frame we define a new Velocity vector and initialize it to zero (bird is standing still)
        Vector2 Velocity = new Vector2(0, 0);  

        //If the right arrow key is pressed we set the x component of the velocity x to 1 => move the bird to the right
        if(Keyboard.current.rightArrowKey.isPressed == true)
        {
            Velocity.x = 1;
        }

        //If the left arrow key is pressed we set the x component of the velocity x to -1 => move the bird to the left
        else if(Keyboard.current.leftArrowKey.isPressed == true)
        {
            Velocity.x = -1;
        }    
        
        //If the up arrow key is pressed we set the y component of the velocity y to 1 => move the bird up
        if(Keyboard.current.upArrowKey.isPressed == true)
        {
            Velocity.y = 1;
        }

        //If the down arrow key is pressed we set the y component of the velocity y to -1 => move the bird down
        else if(Keyboard.current.downArrowKey.isPressed == true)
        {
            Velocity.y = -1;
        }   
        
        //The translte function upates the position Vector of the bird according to the Velocity vector. 
        //Technically the position vector of the bird is added by the Velocity Vector
        //We multiply with Time.deltaTime for converting the speed to
        //units per second (instead of per frame) 
        transform.Translate(Velocity * Time.deltaTime);
    }
}
