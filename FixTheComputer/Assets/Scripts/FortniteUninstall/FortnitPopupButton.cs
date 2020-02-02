using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            if (fub.totalRightAnswers == fub.dialogAmount)
            {
                //WIN CODE HERE
                Debug.Log("You won this micro game!!");
                SceneManager.LoadScene("Bricks");
                this.transform.parent.gameObject.SetActive(false);
                return;
            }
            fub.SpawnPopUpWindow();
        }
        else
        {
            //LOSING CODE HERE
            this.transform.parent.gameObject.SetActive(false);
            SceneManager.LoadScene("Bricks");
            Debug.Log("You lost this micro game");
        }
    }
}
