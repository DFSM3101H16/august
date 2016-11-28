using UnityEngine;
using System.Collections;


public class RockShooting : MonoBehaviour {
    
    private PhysicsVariables physVar;

    public bool shootInput = false;
    public bool shooting = false;
    public GameObject rock;
    public GameObject newRock;
    private PhysicsVariables rockVar;

    private float reloadTimer = 0f;
    

    // Use this for initialization
    void Start () {
        physVar = GetComponent<PhysicsVariables>();
	}
	
	// Update is called once per frame
	void Update () {

        if (shootInput)
        {
            if (!shooting && reloadTimer <= 0f)
            {
                startShooting();
            }
            else if (shooting)
            {
                stillShooting();
            }
        }
        else if (!shootInput)
        {
            if (shooting)
            {
                stopShooting();
            }
        }

        if (!shooting)
        {
            reload();
        }

	}

    private void startShooting()
    {
        shooting = true;
        newRock = (GameObject)Instantiate(rock, new Vector3(100f,100,0) , Quaternion.Euler(0,0,0f));
        rockVar = newRock.GetComponent<PhysicsVariables>();
        newRock.GetComponent<CircleCollider2D>().enabled = false;
        rockVar.r = 0.1f;
        rockVar.m = 20f;
    }

    private void stillShooting()
    {
        rockVar.state[0] = findRockPosition();
        rockVar.state[1] = new Vector3(0, 0, 0);
        if (rockVar.r < 0.5)
        {
            rockVar.r += Time.deltaTime / 5;
            rockVar.m += Time.deltaTime * 10;
        }
    }

    private void stopShooting()
    {
        rockVar.state[1] = findRockSpeed();
        newRock.GetComponent<CircleCollider2D>().enabled = true;
        reloadTimer = 1.5f;
        shooting = false;
    }

    private Vector3 findRockPosition()
    {
        float rad = physVar.direction * Mathf.Deg2Rad;
        Vector3 position = new Vector3(Mathf.Cos(rad) * rockVar.r + (Mathf.Cos(rad)/2), Mathf.Sin(rad) * rockVar.r + (Mathf.Sin(rad)/2), 0f);
        position += physVar.state[0];
        return position;
    }

    private Vector3 findRockSpeed()
    {
        float rad = physVar.direction * Mathf.Deg2Rad;
        Vector3 position = new Vector3(Mathf.Cos(rad) * 2, Mathf.Sin(rad) * 2, 0f);
        position += physVar.state[1];
        return position;
    }

    private void reload()
    {
        if (reloadTimer > 0f)
        {
            reloadTimer -= Time.deltaTime;
        }
    }


}
