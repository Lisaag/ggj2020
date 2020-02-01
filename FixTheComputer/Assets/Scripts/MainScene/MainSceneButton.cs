using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButton : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("TugOfWarMinigame");
    }
}
