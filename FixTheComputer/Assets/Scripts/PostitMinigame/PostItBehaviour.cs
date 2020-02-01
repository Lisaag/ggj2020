using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostItBehaviour : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(HidePostit());
    }

    IEnumerator HidePostit()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }
}
