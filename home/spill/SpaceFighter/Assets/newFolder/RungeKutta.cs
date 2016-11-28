using UnityEngine;
using System.Collections;

public class RungeKutta : MonoBehaviour {
    public float diameter = 0.5f;
    float mass = 100f;
    float gravity = -9.81f;
    public float simulationTime = 0;
    public  float speed = 0;
    public bool simulation = true;
    public float dragForce = 0;
    private float dragCofficient = 0.5f;
    private float airDensity = 1.2f;
    public  float weight;


	// Use this for initialization
	void Start () {
        weight = mass * gravity;
	}
	
	// Update is called once per frame
	void Update () {
        CheckInput();
        if (simulation == true)
        {
        
            simulationTime += Time.deltaTime;

            dragForce = CalculateDrag(airDensity, dragCofficient,Mathf.PI*(diameter/2)*(diameter/2),speed);

            speed = (runge_kutta4(transform.position.y, simulationTime, Time.deltaTime)/Time.deltaTime);
            
            transform.position = new Vector3(transform.position.x, transform.position.y + (speed*Time.deltaTime), 0);
            
        }
	}

    private float runge_kutta4(float y_n, float t_n, float h)
    {
        float k1 = f(t_n, y_n) * h;
        float k2 = f(t_n + h / 2, y_n + (h / 2) * k1) * h;
        float k3 = f(t_n + h / 2, y_n + (h / 2) * k2) * h;
        float k4 = f(t_n + h,     y_n + h * k3) * h;

        return ((k1/6) + (k2/3) + (k3/3) + (k4/6));
    }
    private float f(float t, float y) {
        return ((dragForce/mass) +gravity)*t;
    }

    private float CalculateDrag(float p, float C, float A, float v)
    {
        return (p*v*v*C*A)/2;
    }
    private void CheckInput()
    {
        if (Input.GetKeyDown("space"))
        {
            diameter = 5f;
            dragCofficient = 1.4f;
        }
    }
}
