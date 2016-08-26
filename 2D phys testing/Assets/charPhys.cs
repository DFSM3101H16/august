using UnityEngine;
using System.Collections;

public class charPhys : MonoBehaviour {
    float x;
    float y;
    float hSpeed;
    float vSpeed;
    //[SerializeField]
    private float gravity = -9.81f;

    // Use this for initialization
    void Start()
    {
        hSpeed = 0;
        vSpeed = 0;
        x = transform.position.x;
        y = transform.position.y;

        transform.Rotate(0, 0, 45f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateVelocity();
        updatePosition();
        //vSpeed -= gravity*Time.deltaTime;
        //x += hSpeed;
        //y += vSpeed;
        //x = Mathf.Sin(y);
        
        //transform.Rotate(0, 0, 3f);
        //transform.position = new Vector3(x,y,0);
    }

    void updateVelocity()
    {
        vSpeed += gravity * Time.deltaTime;
    }

    void updatePosition()
    {
        transform.position += (new Vector3(hSpeed, vSpeed, 0) * Time.deltaTime);
    }
}
