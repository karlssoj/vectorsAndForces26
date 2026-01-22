using UnityEngine;
using UnityEngine.InputSystem;

public class MyRigidbody2 : MonoBehaviour
{
    Vector2 Velocity;
    public float Mass = 20;
    public float StaticFrictionCoefficient = 0.15f;
    public float KineticFrictionCoefficient = 0.10f;
    public float PushForceMagnitude = 35f; 
    Vector2 KineticFriction;
    Vector2 MaxStaticFriction;
    float GravitationalAcceleration = 9.81f;

    bool Pushing;

    void Start()
    {
        Velocity = new Vector2(0, 0);
        Pushing = false;
        KineticFriction = new Vector2(KineticFrictionCoefficient * Mass * GravitationalAcceleration, 0);
        MaxStaticFriction = new Vector2(StaticFrictionCoefficient * Mass * GravitationalAcceleration, 0);
    }
    
    void AddForce(Vector2 Force)
    {
        Vector2 Acceleration = Force/Mass;
        Velocity += Acceleration * Time.deltaTime;
        transform.Translate(Velocity * Time.deltaTime);
    }

    void AddFrictionForce()
    {
        if(Velocity.magnitude > 0) 
            AddForce(-KineticFriction);

        else if(Pushing == true)
        {
            if(PushForceMagnitude <= MaxStaticFriction.magnitude)
                AddForce(new Vector2(-PushForceMagnitude, 0));
            else
                AddForce(-MaxStaticFriction);
        }

        if(Velocity.magnitude <= 0.01f)
            Velocity = new Vector2(0, 0);
    }

    void Update()
    {        
        AddFrictionForce();

        if(Keyboard.current.rightArrowKey.isPressed)
        {
            AddForce(new Vector2(PushForceMagnitude, 0));
            Pushing = true;
        }
        else
            Pushing = false;
    }
}
