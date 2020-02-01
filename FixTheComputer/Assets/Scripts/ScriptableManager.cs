﻿using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class ScriptableManager : ScriptableObject
{
    public int lives;
    public Difficulty difficulty;

    public enum Difficulty{
        Easy,
        Medium,
        Hard
    }

    private void Awake()
    {
        lives = 3;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
