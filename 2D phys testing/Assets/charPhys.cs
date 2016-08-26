using UnityEngine;
using System.Collections;

public class charPhys : MonoBehaviour {
    //float x;
    //float y;
    //float hSpeed;
    //float vSpeed;
    //Collider2D myCollider;
    //private float gravity = -9.81f;

    public Vector3 acceleration;
    public Vector3 velocity;
    public Vector3 gravity;
    public Vector3 force;
    public float mass = 40f;
    public  Vector3 drag;

    // Use this for initialization
    void Start()
    {
        //myCollider = GetComponent<Collider2D>();
        acceleration = new Vector3(0,0,0);
        velocity = new Vector3(0,0,0);
        gravity = new Vector3(0,-9.81f,0);
        force = new Vector3(0,0,0);
        drag = new Vector3(0,0,0);

        //hSpeed = 0;
        //vSpeed = 0;
        //x = transform.position.x;
        //y = transform.position.y;

        //transform.Rotate(0, 0, 45f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //acceleration = force / mass;
        force = gravity * mass;
        updateDrag();
        updateAcceleration();
        updateVelocity();

        updatePosition();
        //vSpeed -= gravity*Time.deltaTime;
        //x += hSpeed;
        //y += vSpeed;
        //x = Mathf.Sin(y);
        
        //transform.Rotate(0, 0, 3f);
        //transform.position = new Vector3(x,y,0);
        
    }

    void updateDrag()
    {
        drag = new Vector3(0, -Mathf.Sign(velocity.y)*((1.05f * mass * Mathf.Pow(velocity.y, 2)) / 2), 0);
    }

    void updateAcceleration()
    {
        acceleration = ((force + drag)/mass);
    }

    void updateVelocity()
    {
        velocity += (acceleration) * Time.deltaTime;
    }

    void updatePosition()
    {
        transform.position += (velocity * Time.deltaTime);
    }

    void checkCollision()
    {

        //collider.
    }

}
