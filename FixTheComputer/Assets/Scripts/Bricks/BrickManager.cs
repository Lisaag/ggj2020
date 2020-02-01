using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public List<GameObject> Bricks = new List<GameObject>();

    public static BrickManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Bricks.Count <= 0)
        {
            Debug.Log("Done playing");
        }

        for (int i = 0; i < Bricks.Count; i++)
        {
            if (Bricks[i] == null)
                Bricks.RemoveAt(i);
        }
    }
}
