using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardManager : MonoBehaviour
{
    [SerializeField] private ScriptableManager manager;
    [SerializeField] private List<KeyboardKey> keys;

    private void Start()
    {
        foreach (KeyboardKey key in keys)
        {
            key.OnPositionedRight += CheckWin;
        }   
    }

    private void CheckWin()
    {
        foreach (KeyboardKey key in keys)
        {
            if (!key.PositionedRight)
            {
                return;
            }
        }

        manager.win = true;
        SceneManager.LoadScene("InBetween");
    }
}
