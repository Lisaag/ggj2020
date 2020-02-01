using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostItBehaviour : MonoBehaviour
{
    public float time;
    void Start()
    {
        StartCoroutine(HidePostit());
    }

    IEnumerator HidePostit()
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
    }
}
