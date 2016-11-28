using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {
    PuckPhysics myPhys;
    PuckPhysics[] otherPhys;
    Transform[] otherTransforms;
    public GameObject[] otherObjects;


	// Use this for initialization
	void Start () {
        myPhys = GetComponent<PuckPhysics>();

        otherPhys = new PuckPhysics[otherObjects.Length];
        for (int i = 0; i < otherObjects.Length-1; i++)
        {
            otherPhys[i] = otherObjects[i].GetComponent<PuckPhysics>();
        }

        otherTransforms = new Transform[otherObjects.Length];
        for (int i = 0; i < otherObjects.Length - 1; i++)
        {
            otherTransforms[i] = otherObjects[i].GetComponent<Transform>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        //CheckAll();
	}

    public void CheckAll(Vector3[] myState)
    {
        for (int i = 0; i < otherObjects.Length - 1; i++)
        {
            if (DoesItCollide(myState[0], otherTransforms[i].position, otherPhys[i].r))
            {
                collide(otherPhys[i]);
                
            }
        }
    }

    public void collide(PuckPhysics theirPhys)
    {
        float tmp = 1f / (myPhys.m + theirPhys.m);
        Vector3 newV1 = (((myPhys.m - theirPhys.m)*myPhys.state[1] * tmp) +
                            (theirPhys.m*theirPhys.state[1]*tmp));

        Vector3 newV2 = (((theirPhys.m - myPhys.m) * theirPhys.state[1] * tmp) +
                            (myPhys.m * myPhys.state[1] * tmp));

        myPhys.state[1] = newV1;
        theirPhys.state[1] = newV2;
    }

    public bool DoesItCollide(Vector3 myPosition,Vector3 otherPosition, float otherDiameter)
    {
        float distance = (myPosition - otherPosition).magnitude;
        if (distance<(myPhys.scale*(otherDiameter + myPhys.r)))
        {
            return true;
        }
        return false;
    }
}
