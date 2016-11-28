using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    ShipPhysics physics;
    PhysicsVariables phys;
    RockShooting shooting;
    public KeyCode up = KeyCode.W;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode shoot = KeyCode.E;

    // Use this for initialization
    void Start () {

        shooting = GetComponent<RockShooting>();
        physics = GetComponent<ShipPhysics>();
        phys = GetComponent<PhysicsVariables>();

    }
	
	// Update is called once per frame
	void Update () {
        checkInputs();
	}

    void checkInputs()
    {
        if (Input.GetKeyDown(up))
        {
            physics.engineStatus = true;
        }

        if (Input.GetKeyUp(up))
        {
            physics.engineStatus = false;
        }
        if (Input.GetKey(left))
        {
            phys.direction += 3;
        }

        if (Input.GetKey(right))
        {
            phys.direction -= 3;
        }
        if (Input.GetKeyDown(shoot))
        {
            shooting.shootInput = true;
        }
        if (Input.GetKeyUp(shoot))
        {
            shooting.shootInput = false;
        }
    }
}
