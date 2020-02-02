using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortniteUninstallButton : MonoBehaviour
{
    [SerializeField]
    Color hoverColor;

    [SerializeField]
    Color defaultColor;

    [SerializeField]
    GameObject[] popUpWindows = null;

    [SerializeField]
    ScriptableManager scriptableManager;

    [HideInInspector]
    public int dialogAmount = 0;

    SpriteRenderer spriteRenderer = null;

    private bool hasClicked = false;

    private int index = -1;

    [HideInInspector]
    public int totalRightAnswers = 0;

    void Start()
    {
        if (scriptableManager.difficulty == ScriptableManager.Difficulty.Easy) dialogAmount = 3;
        else if (scriptableManager.difficulty == ScriptableManager.Difficulty.Medium) dialogAmount = 5;
        else dialogAmount = 8;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        if(!hasClicked) spriteRenderer.color = hoverColor;
    }

    void OnMouseExit()
    {
        spriteRenderer.color = defaultColor;
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
