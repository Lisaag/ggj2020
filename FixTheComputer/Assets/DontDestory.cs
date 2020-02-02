using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestory : MonoBehaviour
{
    Canvas canvas;

    public MusicPlayer player;
    public ScriptableManager manager;
    public GameObject win, lose;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += UpdateThings;
        canvas = GetComponent<Canvas>();
    }

    void UpdateThings(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "InBetween")
        {
            canvas.enabled = true;
            player.ActivateSongs();
            if (manager.win)
            {
                player.unlockSong();
            }
        }
        else
        {
            canvas.enabled = false;
        }
    }

}
