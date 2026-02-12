using UnityEngine;

public class SquareController : MonoBehaviour
{
    public GameObject Triangle;
    public float t;

    // Update is called once per frame
    void Update()
    {
        //Using own Lerp function
        transform.position = Lerp(transform.position, Triangle.transform.position, t);
        
        //Using Unity's Lerp fucntion
        //transform.position = Vector2.Lerp(transform.position, Triangle.transform.position, t);
    }

    Vector2 Lerp(Vector2 a, Vector2 b, float t) 
    {
        return a+(b-a)*t;
    }
}