using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
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

        //if you made it here you win smile 🤠
    }
}
