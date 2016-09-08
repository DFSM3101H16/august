using UnityEngine;
using System.Collections;

public class charPhys : MonoBehaviour {

    Collider2D myCollider;
    gameControl control;

    public Vector3 acceleration;
    public Vector3 velocity;
    public Vector3 gravity;
    public Vector3 force;
    public Vector3 totalForce;
    public float mass = 2f;
    public  Vector3 drag;

    // Use this for initialization
    void Start()
    {
        control = GameObject.Find("GameControl").GetComponent<gameControl>();
        
        
        myCollider = GetComponent<Collider2D>();
        acceleration = new Vector3(0,0,0);
        velocity = new Vector3(0,0,0);
        gravity = new Vector3(0,-9.81f,0);
        force = new Vector3(0,0,0);
        totalForce = new Vector3(0, 0, 0);
        drag = new Vector3(0,0,0);



    }

    // Update is called once per frame
    void Update()
    {
        updateForce();
        updateAcceleration();
        updateVelocity();
        updatePosition();
        updateCollision();
        updateDrag();


        checkInput();
        


    }

    void checkInput()
    {
        if (Input.GetKeyDown("space"))
        {
            gravity *= -1;
        }

        if (Input.GetKeyDown("up"))
        {
            control.wind = new Vector2(control.wind.x, control.wind.y + 2);
        }
        if (Input.GetKeyDown("down"))
        {
            control.wind = new Vector2(control.wind.x, control.wind.y - 2);
        }
        if (Input.GetKeyDown("left"))
        {
            control.wind = new Vector2(control.wind.x - 2, control.wind.y);
        }
        if (Input.GetKeyDown("right"))
        {
            control.wind = new Vector2(control.wind.x + 2, control.wind.y);
        }

        if (Input.GetKey("a"))
        {
            force = new Vector3(-10, force.y, force.z);
        }
        if (Input.GetKey("d"))
        {
            force = new Vector3(10, force.y, force.z);
        }
    }

    void updateCollision()
    {
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(0, 0, 0);
            velocity = velocity * 0;
        }
    }

    void updateDrag()
    {

        float deltaVx = velocity.x - control.wind.x;
        float deltaVy = velocity.y - control.wind.y;
        drag = new Vector3(-(Mathf.Sign(deltaVx))*((1.2f * 1.05f * Mathf.Pow(deltaVx, 2)) / 2), -(Mathf.Sign(deltaVy))*(1.2f *1.05f * Mathf.Pow(deltaVy, 2) / 2), 0);
    }

    void updateForce()
    {

        totalForce = (gravity*mass) + drag + force;
        force *= 0;
    }

    void updateAcceleration()
    {
        acceleration = (totalForce/mass);
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
