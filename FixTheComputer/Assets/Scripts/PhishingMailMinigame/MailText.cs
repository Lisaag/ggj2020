using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailText : MonoBehaviour
{
    [SerializeField]
    List<string> phishingText = new List<string>();

    void Start()
    {
        TextMesh textMesh = GetComponent<TextMesh>();
        int textIndex = Random.Range(0, phishingText.Count);
        textMesh.text = phishingText[textIndex];
    }
}
