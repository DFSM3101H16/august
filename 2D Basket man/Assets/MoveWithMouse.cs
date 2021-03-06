﻿using UnityEngine;
using System.Collections;

public class MoveWithMouse : MonoBehaviour {
    public Vector3 deltaVector;
    public float offset;

    public Vector3 mousePosition;
    public float angle;
	// Use this for initialization
	void Start () {
        deltaVector = new Vector3(0,0);
        mousePosition = new Vector3(0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition);
        deltaVector = transform.position - mousePosition;
        angle = ((Mathf.Atan2(deltaVector.y,deltaVector.x)*180)/Mathf.PI) + 180;
        transform.rotation = Quaternion.AngleAxis(angle - offset, new Vector3(0, 0, 1));

    }

    Vector2 V3toV2(Vector3 vect3)
    {
        return new Vector2(vect3.x, vect3.y);
    }
}
