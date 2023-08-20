using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursors : MonoBehaviour
{
    public Texture2D Hover;
    public Texture2D Grab;
    public Vector2 NormalCursorHotSpot;
    public Vector2 GrabCursorHotSpot;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.SetCursor(Hover, NormalCursorHotSpot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
    }

    private void OnMouseUp()
    {
       Cursor.SetCursor(Grab, GrabCursorHotSpot, CursorMode.Auto);
    }
}
