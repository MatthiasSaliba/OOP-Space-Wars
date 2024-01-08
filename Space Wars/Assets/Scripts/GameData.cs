using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameData : MonoBehaviour
{
    private static Vector3 _mousePosition;
    private static float _padding = 2f;
    
    public static Vector3 MousePosition
    {
        get { return GetMousePos(); }
    }
    
    private static Vector3 GetMousePos()
    {
        Camera myCamera = Camera.main;
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 10f);
        return _mousePosition;
    }
    
    public static float XMin
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + _padding; }
    }

    public static float XMax
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - _padding; }
    }

    public static float YMin
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + _padding; }
    }

    public static float YMax
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - _padding; }
    }
    
}
