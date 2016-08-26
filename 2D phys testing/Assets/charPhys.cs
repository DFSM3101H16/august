using UnityEngine;
using System.Collections;

public class charPhys : MonoBehaviour {
    float x;
    float hspd;
    float vspd;
    [SerializeField]
    private float gravity = 9.81f;

	// Use this for initialization
	void Start () {
        hspd = 0;
        vspd = 0;
        transform.Rotate(0, 0, 45f);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        vspd += 0.0001f;
        transform.Translate(vspd,hspd,0,Space.Self);
        transform.Rotate(0, 0, 3f);
    }
}
