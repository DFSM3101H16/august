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
	
	}

    private void CheckAll()
    {
        for (int i = 0; i < otherObjects.Length - 1; i++)
        {
            if (DoesItCollide(otherTransforms[i].position, otherPhys[i].r))
            {
                gameObject.SetActive(false);
            }
        }
    }

    public bool DoesItCollide(Vector3 position, float diameter)
    {
        //float distance = ;
        ;
        return true;
    }
}
