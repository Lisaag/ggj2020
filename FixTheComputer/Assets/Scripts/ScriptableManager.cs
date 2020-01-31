using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
