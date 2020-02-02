using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhishingGameManager : MonoBehaviour
{
    [HideInInspector]
    public int mailAmount = 5;

    private int maxMailAmount = 19;

    [SerializeField]
    GameObject mailObject;

    [SerializeField]
    MailTrashbin mailTrashbin;

    [SerializeField]
    public ScriptableManager scriptableManager;

    public int points = 0;

    [HideInInspector]
    public GameObject[] deleteMails;

    void Start()
    {
        deleteMails = new GameObject[maxMailAmount];
        CreateMails();

        this.points = 0;
    }

    void CreateMails()
    {
        if(scriptableManager.difficulty == ScriptableManager.Difficulty.Easy) mailAmount = 10;
        else if (scriptableManager.difficulty == ScriptableManager.Difficulty.Medium) mailAmount = 15;
        else mailAmount = maxMailAmount;

        for (int i = 0; i < mailAmount; i++)
        {
            GameObject mO = Instantiate(mailObject, this.transform);
            if (scriptableManager.difficulty == ScriptableManager.Difficulty.Easy) mO.GetComponent<MailSprite>().mailRectSize = new Vector2(55, 3);
            else if (scriptableManager.difficulty == ScriptableManager.Difficulty.Medium) mO.GetComponent<MailSprite>().mailRectSize = new Vector2(55, 2);
            else if (scriptableManager.difficulty == ScriptableManager.Difficulty.Medium) mO.GetComponent<MailSprite>().mailRectSize = new Vector2(55, 1);
            mO.GetComponent<MailSprite>().SetPosition(i);
            mO.GetComponent<MailSprite>().mailIndex = i;
        }
    }

    public void CheckWin()
    {
        if (points > 0)
        {
            StartCoroutine(mailTrashbin.Rainbow(0));
        }
        else
        {
            mailTrashbin.resetBin();
        }
    }
}
