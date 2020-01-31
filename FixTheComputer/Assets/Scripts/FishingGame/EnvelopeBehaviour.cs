using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvelopeBehaviour : MonoBehaviour
{
    public ScriptableManager scriptM;
    bool move;
    void Start()
    {
        if (scriptM.difficulty == ScriptableManager.Difficulty.Hard)
        {
            move = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            this.transform.position += new Vector3(Mathf.Lerp(transform.position.x - 1f, transform.position.x + 1f, Mathf.PingPong(Time.time, 1f)), 0, 0);
        }
    }
}
