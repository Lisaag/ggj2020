using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePlane : MonoBehaviour
{
    public float distance = 100f;
    void Awake()
    {
        Vector3 screen2World = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, distance));
        transform.localScale = new Vector3(screen2World.x, 1.0f, screen2World.y);
        print(screen2World);
    }
}
