using UnityEngine;
using System.Collections;

public class FlameControl : MonoBehaviour {


    SpriteRenderer render;
    ShipPhysics phys;
	// Use this for initialization
	void Start () {
        phys = GetComponentInParent<ShipPhysics>();
        render = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

            render.enabled = phys.engineStatus;


	}
}