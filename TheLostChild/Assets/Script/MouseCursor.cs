using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D DefaultCursor;
    public Texture2D DefaultCursorOnPress;
    public Texture2D HoverItemCursor;
    public Texture2D HoverItemCursorOnPress;
    public Texture2D CursorEyes;
    public Texture2D CursorEyesOnpress;
    public Texture2D StairUp;
    public Texture2D StairUpOnpress;
    public Texture2D StairDown;
    public Texture2D StairDownOnpress;
    public Texture2D RoomLeft;
    public Texture2D RoomLeftOnpress;
    public Texture2D RoomRight;
    public Texture2D RoomRightOnpress;
    public Texture2D RoomUp;
    public Texture2D RoomUpOnpress;
    public Texture2D RoomDown;
    public Texture2D RoomDownOnpress;

    void Start()
    {
        setToDefaultCursor("Hover");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setToDefaultCursor(string s)
    {
        if (s == "Press")
        {
            Cursor.SetCursor(DefaultCursorOnPress, Vector2.zero, CursorMode.ForceSoftware);
        }
        else if (s == "Hover")
        {
            Cursor.SetCursor(DefaultCursor, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    public void setToHoverCursor(string s)
    {
        if (s == "Press")
        {
            Cursor.SetCursor(HoverItemCursorOnPress, Vector2.zero, CursorMode.ForceSoftware);
        }
        else if (s == "Hover")
        {
            Cursor.SetCursor(HoverItemCursor, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    public void setToCursorEyes(string s)
    {
        if (s == "Press")
        {
            Cursor.SetCursor(CursorEyesOnpress, Vector2.zero, CursorMode.ForceSoftware);
        }
        else if (s == "Hover")
        {
            Cursor.SetCursor(CursorEyes, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    public void setToCursorStair(string direaction, string s)
    {
        if (direaction == "Up")
        {
            if (s == "Press")
            {
                Cursor.SetCursor(StairUpOnpress, Vector2.zero, CursorMode.ForceSoftware);
            }
            else if (s == "Hover")
            {
                Cursor.SetCursor(StairUp, Vector2.zero, CursorMode.ForceSoftware);
            }
        }
        else if (direaction == "Down")
        {
            if (s == "Press")
            {
                Cursor.SetCursor(StairDownOnpress, Vector2.zero, CursorMode.ForceSoftware);
            }
            else if (s == "Hover")
            {
                Cursor.SetCursor(StairDown, Vector2.zero, CursorMode.ForceSoftware);
            }
        }
    }

    public void setToCursorRoom(string direaction, string s)
    {
        if (direaction == "Up")
        {
            if (s == "Press")
            {
                Cursor.SetCursor(RoomUpOnpress, Vector2.zero, CursorMode.ForceSoftware);
            }
            else if (s == "Hover")
            {
                Cursor.SetCursor(RoomUp, Vector2.zero, CursorMode.ForceSoftware);
            }
        }
        else if (direaction == "Down")
        {
            if (s == "Press")
            {
                Cursor.SetCursor(RoomDownOnpress, Vector2.zero, CursorMode.ForceSoftware);
            }
            else if (s == "Hover")
            {
                Cursor.SetCursor(RoomDown, Vector2.zero, CursorMode.ForceSoftware);
            }
        }
        else if (direaction == "Left")
        {
            if (s == "Press")
            {
                Cursor.SetCursor(RoomLeftOnpress, Vector2.zero, CursorMode.ForceSoftware);
            }
            else if (s == "Hover")
            {
                Cursor.SetCursor(RoomLeft, Vector2.zero, CursorMode.ForceSoftware);
            }
        }
        else if (direaction == "Right")
        {
            if (s == "Press")
            {
                Cursor.SetCursor(RoomRightOnpress, Vector2.zero, CursorMode.ForceSoftware);
            }
            else if (s == "Hover")
            {
                Cursor.SetCursor(RoomRight, Vector2.zero, CursorMode.ForceSoftware);
            }
        }
    }
}
