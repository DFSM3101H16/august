using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameControl : MonoBehaviour {
    RungeKutta3 charPhys;
    int gameMode = 0;
    Text buttonText;
    Text heightText;
    Text speedText;
    Text timeText;
    Text pointsText;

    GlobalGameControl Control;

    // Use this for initialization
    void Start () {
        charPhys = GameObject.Find("MannFall").GetComponent<RungeKutta3>();
        buttonText = GameObject.Find("Text").GetComponent<Text>();
        heightText = GameObject.Find("HeightText").GetComponent<Text>();
        speedText = GameObject.Find("SpeedText").GetComponent<Text>();
        timeText = GameObject.Find("TimeText").GetComponent<Text>();
        pointsText = GameObject.Find("PointsText").GetComponent<Text>();

        Control = GameObject.Find("ControlObject").GetComponent<GlobalGameControl>();
    }
	
	// Update is called once per frame
	void Update () {
        if (charPhys.state[0].y < 0f)
        {
            charPhys.Land();
            gameMode = 2;
            GivePoints();
            buttonText.text = "Restart";
        }
        UpdateText();
	}

    private void GivePoints()
    {
        if (charPhys.state[1].y < -14f)
        {
            Control.points -= 60;
        }
        else if (charPhys.state[1].y < -7f)
        {
            Control.points -= 30;
            Control.points += (10 - Mathf.Ceil(charPhys.simulationTime) * 2);
        }
        else
        {
            Control.points += 30;
            Control.points += (50-Mathf.Ceil(charPhys.simulationTime)*10);
        }

    }

    private void ButtonClick()
    {
        switch (gameMode)
        {
            case 0:
                gameMode = 1;
                charPhys.Jump();
                buttonText.text = "Parachute";
                break;
            case 1:
                //charPhys.simulation = charPhys.simulation != true ? true : false;
                //charPhys.paracute.SetActive(false); <- what?
                charPhys.OpenParachute();
                break;
            case 2:
                DestroyObject(Control.gameObject);
                SceneManager.LoadScene(0);
                //gameMode = 0;
                //charPhys.ResetCharacter();
                //buttonText.text = "Jump";
                break;
            default:
                break;
        }
    }

    private void UpdateText()
    {
        heightText.text = "Height: " + charPhys.state[0].y.ToString();
        speedText.text = "Speed: " + charPhys.state[1].y.ToString();
        timeText.text = "Time: " + charPhys.simulationTime.ToString();
        pointsText.text = "Points: " + Control.points.ToString();
    }

}
