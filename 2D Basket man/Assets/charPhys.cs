using UnityEngine;
using System.Collections;

public class charPhys : MonoBehaviour {

    Collider2D myCollider;
    gameControl control;
    Transform arm;
    MoveWithMouse armScript;
    public Vector3 acceleration;
    public Vector3 velocity;
    public Vector3 gravity;
    public Vector3 force;
    public Vector3 totalForce;
    public float mass;
    public  Vector3 drag;
    public float dragC;
    public int behavorType = 0;
    public float areal;

    // Use this for initialization
    void Start()
    {
        control = GameObject.Find("GameControl").GetComponent<gameControl>();
        arm = GameObject.Find("arm").transform;
        armScript = GameObject.Find("arm").GetComponent<MoveWithMouse>();

        myCollider = GetComponent<Collider2D>();
        acceleration = new Vector3(0,0,0);
        velocity = new Vector3(0,0,0);
        gravity = new Vector3(0,-9.81f,0);
        //force = new Vector3(0,0,0);
        totalForce = new Vector3(0, 0, 0);
        drag = new Vector3(0,0,0);
        areal = 1 * 1 * Mathf.PI;
        mass = 10.4f;


    }

    // Update is called once per frame
    void Update()
    {

        checkInput();
        if (behavorType == 0) FollowHand();
        else if (behavorType == 1)
        {
            updateForce();
            updateAcceleration();
            updateVelocity();
            updateDrag();
            updatePosition();
            updateCollision();

        }
        


    }
    void FollowHand()
    {
        transform.position = arm.position;
        transform.position += new Vector3(2.5f*Mathf.Cos(armScript.angle * Mathf.PI/180), 2.5f*Mathf.Sin(armScript.angle * Mathf.PI / 180), 0);
        GetComponent<TrailRenderer>().enabled = false;
        velocity = new Vector3((control.mousePosition.x - arm.position.x), (control.mousePosition.y - arm.position.y), 0)*2;
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
        if (Input.GetMouseButtonDown(1))
        {


            if (behavorType == 0)
            {
                behavorType = 1;
                GetComponent<TrailRenderer>().enabled = true;
                GetComponent<TrailRenderer>().Clear();
            }
            else
            {
                behavorType = 0;
            }
        }
    }

    void updateCollision()
    {
        
        if (transform.position.x > 11)
        {
            behavorType = 2;
        }
        
        if (myCollider.IsTouching(GameObject.Find("wall").GetComponent<Collider2D>()))
        {
            behavorType = 2;
        }
    }


    void updateDrag()
    {

        float deltaVx = velocity.x - control.wind.x;
        float deltaVy = velocity.y - control.wind.y;
        drag = new Vector3(-(Mathf.Sign(deltaVx))*((Mathf.Pow(deltaVx, 2)) / 2), -(Mathf.Sign(deltaVy))*(Mathf.Pow(deltaVy, 2) / 2), 0)*0.5f *dragC * 1.2f * areal;
    }

    void updateForce()
    {

        totalForce = ((gravity*mass) + drag + force)*control.simulation;
        force *= 0;
    }

    void updateAcceleration()
    {
        acceleration = (totalForce/mass);
    }

    void updateVelocity()
    {
        velocity += (acceleration) * Time.deltaTime * control.simulation;
    }

    void updatePosition()
    {
        transform.position += (velocity * Time.deltaTime) * control.simulation;
    }

}
