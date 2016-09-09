using UnityEngine;
using System.Collections;

public class gameControl : MonoBehaviour {

    public Vector2 wind = new Vector2(0,0);
    public float simulation = 0;
    public Vector3 mousePosition;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Use this for initialization
    void Start () {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
	
	// Update is called once per frame
	void Update () {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
