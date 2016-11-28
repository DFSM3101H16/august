using UnityEngine;
using System.Collections;

public class RungeKuttaPhys : MonoBehaviour {
    float m = 100f;
    float g = 9.81f;
    private float C = 0.5f;
    private float p = 1.2f;
    public float diameter = 0.5f;
    private float A;

    public float[] state;
    // Use this for initialization
    void Start () {

        state = new float[]{transform.position.y, 0f};
}
	
	// Update is called once per frame
	void Update () {
        CheckInput();
        A = Mathf.PI * (diameter / 2) * (diameter / 2);
        state = Rungekutta4(state[0], state[1], Time.deltaTime);
        transform.position = new Vector3(0f, state[0],0f) ;
    }
    private float[] Rungekutta4(float s, float v, float dt)
    {
        float s1 = s;
        float v1 = v;
        float a1 = Formel(s1,v1,0);

        float s2 = (s + 0.5f*v1*dt);
        float v2 = (v + 0.5f*a1*dt);
        float a2 = Formel(s2, v2, dt/2);

        float s3 = (s + 0.5f * v2 * dt);
        float v3 = (v + 0.5f * a2 * dt);
        float a3 = Formel(s3, v3, dt / 2);

        float s4 = (s + v3 * dt);
        float v4 = (v + a3 * dt);
        float a4 = Formel(s4, v4, dt);

        float xf = s + (dt / 6.0f) * (v1 + 2 * v2 + 2 * v3 + v4);
        float vf = v + (dt / 6.0f) * (a1 + 2 * a2 + 2 * a3 + a4);

        return new float[] {xf,vf};
    }
    private float Formel(float s, float v, float dt)
    {
        return ((p * v * v * C * A * 0.5f)/m) - g;
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown("space"))
        {
            diameter = 5f;
            C = 1.4f;
        }
    }
}
