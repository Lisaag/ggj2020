using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailTrashbin : MonoBehaviour
{
    [SerializeField]
    Color defaultColor;

    [SerializeField]
    Color[] rainbowColors;

    [SerializeField]
    float highlightSpeed;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
       // StartCoroutine(Rainbow(0));
    }

    void OnMouseOver()
    {
        spriteRenderer.color = Color.gray;
    }

    void OnMouseExit()
    {
        spriteRenderer.color = defaultColor;
    }

    public IEnumerator Rainbow(int index)
    {
        if (index == rainbowColors.Length) index = 0;
        yield return new WaitForSeconds(highlightSpeed);
        spriteRenderer.color = rainbowColors[index];
        index++;
        StartCoroutine(Rainbow(index));
    }
}
