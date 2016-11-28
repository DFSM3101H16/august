using UnityEngine;
using System.Collections;

public class PhysicsVariables : MonoBehaviour {
    
    public float A = 0.5f;
    public float m = 30f;
    public float direction = 0f;
    public float r = 0.5f;

    public Vector3 startSpeed;



    public Vector3[] state;

    public float mass = 10f;

    // Use this for initialization
    void Start () {
        state = new Vector3[2] { transform.position, startSpeed == null ? new Vector3(0f, 0f, 0f) : startSpeed };
    }
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(r*2f,r*2f,1);
	    
	}
}
