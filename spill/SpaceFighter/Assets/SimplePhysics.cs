using UnityEngine;
using System.Collections;

public class SimplePhysics : MonoBehaviour {

    PhysicsVariables phys;
    ShipCollision collision;

    // Use this for initialization
    void Start () {
        phys = GetComponent<PhysicsVariables>();
        collision = GetComponent<ShipCollision>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        collision.CollideCheck();

        phys.state[0] += (phys.state[1] * Time.deltaTime);
        //collision.CollideCheck();
        transform.position = phys.state[0];
	}
}
