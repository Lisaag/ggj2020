using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TugofwarButton : MonoBehaviour
{
    public GameObject rope;
    public float ropeSpeed;
    public float pullSpeed;
    public GameObject player;
    public GameObject virus;
    public GameObject stickers;
    GameObject activeSticker;
    List<GameObject> stickerList = new List<GameObject>();
    Vector3 startPos;
    public float speed;
    public ScriptableManager scriptM;

    void Start()
    {
        SetDifficulty();
        foreach(Transform t in stickers.transform)
        {
            stickerList.Add(t.gameObject);
        }
        startPos = transform.position;
    }

    void SetDifficulty()
    {
        if (scriptM.difficulty == ScriptableManager.Difficulty.Easy)
        {
            ropeSpeed = 100;
            pullSpeed = 50;
        }
        if (scriptM.difficulty == ScriptableManager.Difficulty.Medium)
        {
            ropeSpeed = 150;
            pullSpeed = 40;
        }
        if (scriptM.difficulty == ScriptableManager.Difficulty.Hard)
        {
            ropeSpeed = 150;
            pullSpeed = 30;
        }
    }

    void Update()
    {
        rope.transform.position += new Vector3(ropeSpeed, 0f, 0f) * Time.deltaTime;
        if(rope.transform.position.x < player.transform.position.x)
        {   //TODO: Insert win action besides scene transition
            scriptM.win = true;
            SceneManager.LoadScene("InBetween");
        }
        else if (rope.transform.position.x > virus.transform.position.x)
        {
            scriptM.win = false;
            scriptM.lives--;
            SceneManager.LoadScene("InBetween");
        }
        this.transform.position += new Vector3(Mathf.Sin(1f * Time.time * speed), 0, 0);
    }

    public void PullToPlayer()
    {
        rope.transform.position -= new Vector3(pullSpeed, 0f, 0f);
        ActivateRandomSticker();
        StopAllCoroutines();
        StartCoroutine(DeactivateSticker());
    }

    public void ActivateRandomSticker()
    {
        if (activeSticker != null)
        {
            activeSticker.SetActive(false);
        }
        activeSticker = stickerList[Random.Range(0, stickerList.Count)];
        activeSticker.SetActive(true);
    }

    IEnumerator DeactivateSticker()
    {
        yield return new WaitForSeconds(1f);
        activeSticker.SetActive(false);
    }
}
