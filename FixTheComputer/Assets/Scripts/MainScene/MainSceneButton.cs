using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButton : MonoBehaviour
{
    Scenemanagement scene; 
    MusicPlayer music;

    private void Start()
    {
        scene = GameObject.Find("SceneManagement").GetComponent<Scenemanagement>();
        music = GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>();
    }
    public void SwitchScene()
    {        
        music.lockSongs();
        scene.pickScene();
    }
}
