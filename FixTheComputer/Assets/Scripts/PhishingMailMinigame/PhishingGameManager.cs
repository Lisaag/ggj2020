using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhishingGameManager : MonoBehaviour
{
    [SerializeField]
    int mailAmount;

    [SerializeField]
    GameObject mailObject;

    [SerializeField]
    MailTrashbin mailTrashbin;

    public int points = 0;

    [HideInInspector]
    public GameObject[] deleteMails;

    void Start()
    {
        deleteMails = new GameObject[mailAmount];
        CreateMails();

        this.points = 0;
    }

    void CreateMails()
    {
        for(int i = 0; i < mailAmount; i++)
        {
            GameObject mO = Instantiate(mailObject, this.transform);
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
