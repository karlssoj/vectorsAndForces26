using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    Rigidbody2D physics;
    public float Speed = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * Time.deltaTime);    
        physics.MovePosition(physics.position + Vector2.right * Speed * Time.deltaTime );
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Something hit me");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("some game object just stopped touching me");
    }
}
