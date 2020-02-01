using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t in stickers.transform)
        {
            stickerList.Add(t.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rope.transform.position += new Vector3(ropeSpeed, 0f, 0f) * Time.deltaTime;
        if(rope.transform.position.x < player.transform.position.x)
        {
            //TODO: win
            Debug.Log("Winner!");
        }
        else if (rope.transform.position.x > virus.transform.position.x)
        {
            //TODO: lose
            Debug.Log("Stop suckin diiiiiiiiiiiiiiiiiiiick");
        }
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
