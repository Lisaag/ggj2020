﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToInBetween : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("InBetween");
    }
}
