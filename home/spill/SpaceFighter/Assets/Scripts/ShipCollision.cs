using UnityEngine;
using System.Collections;

public class ShipCollision : MonoBehaviour
{
    PhysicsVariables phys;
    CircleCollider2D mycollider;
    float e = 1;

    GlobalGameControl Control;
    // Use this for initialization
    void Start()
    {
        mycollider = GetComponent<CircleCollider2D>();
        phys = GetComponent<PhysicsVariables>();
        Control = GameObject.Find("ControlObject").GetComponent<GlobalGameControl>();
     }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CollideCheck()
    {
        
        if (phys.state[1].magnitude == 0f) return false;

        RaycastHit2D[] hit = new RaycastHit2D[50];

        if (mycollider.Cast(phys.state[1], hit, phys.state[1].magnitude * Time.deltaTime, false) > 0)
        {
            
            foreach (RaycastHit2D item in hit)
            {
                collide(item);
            }
            return true;

        }
        return false;
    }

    public void collide(RaycastHit2D hit)
    {
        PhysicsVariables theirPhys = hit.collider.GetComponent<PhysicsVariables>();


        float tmp = 1f / (phys.m + theirPhys.m);

        Vector3 newV1 = (((phys.m - (e *theirPhys.m)) * phys.state[1] * tmp) +
                            ((1 + e)* theirPhys.m * theirPhys.state[1] * tmp));

        Vector3 newV2 = (((theirPhys.m - (e* phys.m)) * theirPhys.state[1] * tmp) +
                            ((1 + e)* phys.m * phys.state[1] * tmp));

        phys.state[1] = newV1;
        theirPhys.state[1] = newV2;
        

        if (gameObject.name == "Earth" || theirPhys.gameObject.name == "Earth")
        {
            Control.points -= 10;
        }
    }
}
