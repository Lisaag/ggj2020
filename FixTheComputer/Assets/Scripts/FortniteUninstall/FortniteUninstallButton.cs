using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortniteUninstallButton : MonoBehaviour
{
    [SerializeField]
    Color hoverColor;

    [SerializeField]
    GameObject[] popUpWindows = null;

    SpriteRenderer spriteRenderer = null;

    private bool hasClicked = false;

    private int index = -1;

    [HideInInspector]
    public int totalRightAnswers = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        if(!hasClicked) spriteRenderer.color = hoverColor;
    }

    void OnMouseExit()
    {
        spriteRenderer.color = Color.white;
    }

    void OnMouseDown()
    {
        if(!hasClicked) SpawnPopUpWindow();
    }

    public void SpawnPopUpWindow()
    {
        hasClicked = true;

        if (index != -1) popUpWindows[index].gameObject.SetActive(false);

        int currentIndex = index;
        while(currentIndex == index)
        {
            if (currentIndex != index) break;
            index = Random.Range(0, popUpWindows.Length);
        }
        Debug.Log(currentIndex + " - " + index);

        popUpWindows[index].gameObject.SetActive(true);
    }


}
