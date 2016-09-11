using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameControl : MonoBehaviour {

    public Vector2 wind = new Vector2(0,0);
    public float simulation = 0;
    public Vector3 mousePosition;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public InputField inputWindx;
    public InputField inputWindy;

    // Use this for initialization
    void Start () {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        inputWindx.text = "0";
        inputWindy.text = "0";
        inputWindx = GameObject.Find("InputFieldVindx").GetComponent<InputField>();
        inputWindy = GameObject.Find("InputFieldWindy").GetComponent<InputField>();
    }
	
	// Update is called once per frame
	void Update () {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ChangeWind();
   }

    void ChangeWind()
    {
        float x = float.TryParse(inputWindx.text, out x) ? float.Parse(inputWindx.text) : 0f;
        float y = float.TryParse(inputWindy.text, out y) ? float.Parse(inputWindy.text) : 0f;
        wind = new Vector2(x, y);
        
    }
}

