using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GlobalGameControl : MonoBehaviour {
    public float introTime = 5;
    public float spaceTime = 50;
    public float transissionTime = 5;
    public float sceneTime = 0;
    public float points = 100;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        sceneTime += Time.deltaTime;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                if (sceneTime > introTime)
                {
                    loadNewScene(1);
                }
                break;
            case 1:
                if (sceneTime > spaceTime)
                {
                    loadNewScene(2);
                }
                break;
            case 2:
                if (sceneTime > transissionTime)
                {
                    loadNewScene(3);
                }
                break;
            default:
                break;
        }
        
	}

    private void loadNewScene(int index)
    {
        sceneTime = 0f;
        SceneManager.LoadScene(index);
    }
}
