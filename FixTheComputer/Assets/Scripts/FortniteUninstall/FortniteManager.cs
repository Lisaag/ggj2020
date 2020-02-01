using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortniteManager : MonoBehaviour
{
    [SerializeField]
    GameObject windowText = null;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void SetNewWindow()
    {
        windowText.GetComponent<TextMesh>().text = "sloepiesloep";
    }
}
