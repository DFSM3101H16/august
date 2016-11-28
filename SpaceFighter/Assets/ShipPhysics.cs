using UnityEngine;
using System.Collections;

public class ShipPhysics : MonoBehaviour {

    public float C = 1f;
    public float A = 0.5f;
    public float p = 1f;

    public float m = 30f;
    public float enginePower = 30f;
    public bool engineStatus = false;
    public float direction = 0f;

    private Vector3[] state;



	// Use this for initialization
	void Start () {

        state = new Vector3[2] { transform.position, new Vector3(0f, 0f, 0f) };
        

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.rotation = Quaternion.AngleAxis(direction, new Vector3(0, 0, 1));

        state = Rungekutta4(state[0], state[1], Time.deltaTime );
        transform.position = state[0];


	}

    private Vector3[] Rungekutta4(Vector3 s, Vector3 v, float dt)
    {
        Vector3 s1 = s;
        Vector3 v1 = v;
        Vector3 a1 = Formel(s1, v1, 0);

        Vector3 s2 = (s + 0.5f * v1 * dt);
        Vector3 v2 = (v + 0.5f * a1 * dt);
        Vector3 a2 = Formel(s2, v2, dt / 2);

        Vector3 s3 = (s + 0.5f * v2 * dt);
        Vector3 v3 = (v + 0.5f * a2 * dt);
        Vector3 a3 = Formel(s3, v3, dt / 2);

        Vector3 s4 = (s + v3 * dt);
        Vector3 v4 = (v + a3 * dt);
        Vector3 a4 = Formel(s4, v4, dt);

        Vector3 sf = s + (dt / 6.0f) * (v1 + 2 * v2 + 2 * v3 + v4);
        Vector3 vf = v + (dt / 6.0f) * (a1 + 2 * a2 + 2 * a3 + a4);

        return new Vector3[] { sf, vf};
    }

    private Vector3 Formel(Vector3 s, Vector3 v, float dt)
    {
        float rad = direction * Mathf.Deg2Rad;
        
        Vector3 Force = new Vector3(0f,0f,0f);
        Vector3 enhetsVektor = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f);
        if (engineStatus)
        {
            Force = enhetsVektor * enginePower;
        }


        Force /= m;
        return Force;

    }

}
