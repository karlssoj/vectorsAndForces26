using UnityEngine;
using UnityEngine.SceneManagement;

public class MeteorController : MonoBehaviour
{
    Vector2 Velocity;
    public GameObject Planet1, Planet2, Ship;
    float Speed = 2;

    void Start()
    {
        SetDirection();
    }

    void SetDirection()
    {
        // Calculate distances to both planets
        float DistanceToPlanet1 = Vector3.Distance(transform.position, Planet1.transform.position);
        float DistanceToPlanet2 = Vector3.Distance(transform.position, Planet2.transform.position);

        Vector2 Direction = new Vector2(0, 0);

        // Head toward the farther planet
        if(DistanceToPlanet1 > DistanceToPlanet2)
            Direction = Planet1.transform.position - transform.position;
        else 
            Direction = Planet2.transform.position - transform.position;

        // Set velocity with normalized direction
        Velocity = Direction.normalized * Speed;       
    }

    void Update()
    {
        // Check distances to both planets
        float DistanceToPlanet1 = Vector3.Distance(transform.position, Planet1.transform.position);
        float DistanceToPlanet2 = Vector3.Distance(transform.position, Planet2.transform.position);

        // Switch direction if too close to a planet
        if(DistanceToPlanet1 < 2 || DistanceToPlanet2 < 2)
            SetDirection();

        // Move the meteor
        transform.Translate(Velocity * Time.deltaTime);

        // Check for collision with ship
        if(Vector2.Distance(transform.position, Ship.transform.position) < 1)
        {
            // Restart the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}