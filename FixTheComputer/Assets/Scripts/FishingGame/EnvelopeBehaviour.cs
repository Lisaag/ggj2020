using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvelopeBehaviour : MonoBehaviour
{
    public ScriptableManager scriptM;
    public bool move;
    Vector3 startPos;
    float speed;
    void Start()
    {
        startPos = this.transform.position;
        speed = Random.Range(0.5f, 2f);
        if (scriptM.difficulty == ScriptableManager.Difficulty.Hard)
        {
            move = true;
        }
    }

    void Update()
    {
        if (move)
        {
            this.transform.position = new Vector3(startPos.x, startPos.y + Mathf.Lerp(-1, 1, Mathf.Sin(Time.time * speed)), startPos.z);
        }
    }
}
