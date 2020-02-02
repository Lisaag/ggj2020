using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public List<GameObject> Bricks = new List<GameObject>();

    public ScriptableManager gameManager;

    public static BrickManager instance;

    public GameObject easyBricks, mediumBricks, hardBricks;

    public int lives = 10;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        switch (gameManager.difficulty)
        {
            case ScriptableManager.Difficulty.Easy:
                easyBricks.SetActive(true);
                break;
            case ScriptableManager.Difficulty.Medium:
                mediumBricks.SetActive(true);
                break;
            case ScriptableManager.Difficulty.Hard:
                hardBricks.SetActive(true);
                break;
        }
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

        if (lives <= 0)
        {
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_WEBPLAYER
                     Application.OpenURL(webplayerQuitURL);
            #else
                     Application.Quit();
            #endif
        }
    }
}
