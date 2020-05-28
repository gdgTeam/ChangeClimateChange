using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;



public class MousePointer : MonoBehaviour
{
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(float X, float Y);
    public Texture2D mouse;
    public Texture2D grab;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(mouse, hotspot, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void setMouse()
    {
        Cursor.visible = true;
        Cursor.SetCursor(mouse, hotspot, cursorMode);
    }
     
    public void setGrab()
    {
        Cursor.visible = false;
        //Cursor.SetCursor(grab, hotspot, cursorMode);
    }
}
