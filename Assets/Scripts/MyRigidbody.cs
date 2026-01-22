using UnityEngine;

public class MyRigidbody : MonoBehaviour
{    Vector2 Velocity;
    public float Mass = 20;
    public float StaticFrictionCoefficient = 0.15f;
    public float KineticFrictionCoefficient = 0.10f;
    public float PushForceMagnitude = 35f;
    
    void Start()
    {
        Velocity = new Vector2(0, 0);
    }
    
    void AddForce(Vector2 Force)
    {
        Vector2 Acceleration = Force/Mass;
        Velocity += Acceleration * Time.deltaTime;

        transform.Translate(Velocity * Time.deltaTime);
    }
    
    void Update()
    { 
        // TODO: Add push force when right arrow is held down
        
        // TODO: Calculate and apply friction force (both static and kinetic)
    }
}
