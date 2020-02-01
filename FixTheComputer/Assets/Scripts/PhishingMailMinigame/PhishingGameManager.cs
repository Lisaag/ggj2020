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

    void Start()
    {
        CreateMails();

        this.points = 0;
    }

    void CreateMails()
    {
        for(int i = 0; i < mailAmount; i++)
        {
            GameObject mO = Instantiate(mailObject, this.transform);
            mO.GetComponent<MailSprite>().SetPosition(i);
        }
    }

    public void CheckWin()
    {
        Debug.Log("pressed!: " + points);

        if (points == mailAmount)
        {
            StartCoroutine(mailTrashbin.Rainbow(0));
            Debug.Log("Wajoooo gewonnen!!11");
        }
    }
}
