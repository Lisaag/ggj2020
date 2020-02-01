using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortnitPopupButton : MonoBehaviour
{
    [SerializeField]
    bool isCorrectButton = false;

    [SerializeField]
    FortniteUninstallButton fub = null;

    private int winAmount = 3;

    void OnMouseDown()
    {
        if (isCorrectButton)
        {
            fub.totalRightAnswers++;

            if (fub.totalRightAnswers == winAmount)
            {
                //WIN CODE HERE
                Debug.Log("You won this micro game!!");
                this.transform.parent.gameObject.SetActive(false);
                return;
            }
            fub.SpawnPopUpWindow();
        }
        else
        {
            //LOSING CODE HERE
            this.transform.parent.gameObject.SetActive(false);
            Debug.Log("You lost this micro game");
        }
    }
}
