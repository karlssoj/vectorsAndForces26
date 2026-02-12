using UnityEngine;

public class Gravitation : MonoBehaviour
{
    public float G;
    public GameObject Moon;

    Rigidbody2D EarthPhysics;
    Rigidbody2D MoonPhysics;

    float m_earth, m_moon;

    //use with gravitational force: 6.7346e-05
    //mass of moon: 1
    //mass of earth: 100000

    void Start()
    {
        EarthPhysics = GetComponent<Rigidbody2D>();
        MoonPhysics = Moon.GetComponent<Rigidbody2D>();

        m_earth = EarthPhysics.mass;
        m_moon = MoonPhysics.mass;

        MoonPhysics.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
    }


    // Update is called once per frame
    void Update()
    {
        float r = Vector2.Distance(transform.position, Moon.transform.position);
        float forceMagnitude = G*((m_earth*m_moon)/(r*r));

        Vector2 Direction = transform.position - Moon.transform.position;
        Vector2 GravForce = Direction * forceMagnitude;

        MoonPhysics.AddForce(GravForce);
    }
}
