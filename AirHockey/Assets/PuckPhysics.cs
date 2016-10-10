using UnityEngine;
using System.Collections;

public class PuckPhysics : MonoBehaviour {

    float m = 2f;
    float scale = 0.135f;
    float g = 9.81f;
    float mu = 0.1f;
    public float r = 4f;

    public Vector3[] state;

    // Use this for initialization
    void Start () {
        //transform.position = new Vector3(0f, startHeight, 0f);
        state = new Vector3[] { transform.position, new Vector3(2f, 0f, 0f) };

        
    }

    // Update is called once per frame
    void Update () {
        state = Rungekutta4(state[0], state[1], Time.deltaTime);
        if (state[1].magnitude < 0.3f)
        {
            state[1] = new Vector3(0f,0f,0f);
        }
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

        Vector3 xf = s + ((dt / 6.0f) * (v1 + 2 * v2 + 2 * v3 + v4) * scale);
        Vector3 vf = v + ((dt / 6.0f) * (a1 + 2 * a2 + 2 * a3 + a4) * scale);

        return new Vector3[] { xf, vf };
    }

    private Vector3 Formel(Vector3 s, Vector3 v, float dt)
    {
        float Fmu = (g*m*mu);
        float Fx = 0f;
        float Fy = 0f;
        if (v.magnitude != 0f)
        {
            Fx = -Fmu * (v.x / v.magnitude);
            Fy = -Fmu * (v.y / v.magnitude);
        }

        return new Vector3(Fx,Fy,0f)/m;

    }
}
