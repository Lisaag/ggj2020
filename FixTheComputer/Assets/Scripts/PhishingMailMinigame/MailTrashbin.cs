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

    [SerializeField]
    PhishingGameManager phishingGameManager;

    [SerializeField]
    Timer timer;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
    }

    void OnMouseOver()
    {
        spriteRenderer.color = Color.gray;
    }

    void OnMouseExit()
    {
        spriteRenderer.color = defaultColor;
    }

    void OnMouseDown()
    {
        GameObject[] o = phishingGameManager.deleteMails;
        int amountRemoved = 0;
        for(int i = 0; i < o.Length; i++)
        {
            if (o[i] == null)
            {
                continue;
            }
            else
            {
                amountRemoved++;
            }
            o[i].SetActive(false);
        }
        Debug.Log(amountRemoved + " + " + phishingGameManager.deleteMails.Length);
        if (amountRemoved == phishingGameManager.mailAmount)
        {
            timer.CompleteObjective();
        }
        phishingGameManager.points = 0;
        resetBin();
    }

    public void resetBin()
    {
        StopAllCoroutines();
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
