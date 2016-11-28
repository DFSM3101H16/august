using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    ShipPhysics physics;


	// Use this for initialization
	void Start () {

        physics = GetComponent<ShipPhysics>();

	}
	
	// Update is called once per frame
	void Update () {
        checkInputs();
	}

    void checkInputs()
    {
        if (Input.GetKey(KeyCode.W))
        {
            physics.engineStatus = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            physics.engineStatus = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            physics.direction += 2;
        }

        if (Input.GetKey(KeyCode.D))
        {
            physics.direction -= 2;
        }
    }
}
