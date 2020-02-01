using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public Transform destination;
    public float fishSpeed;
    public float yeah;
    public ScriptableManager scriptM;
    bool wobbly;
    void Start()
    {
        if (scriptM.difficulty ==  ScriptableManager.Difficulty.Medium || scriptM.difficulty == ScriptableManager.Difficulty.Hard)
        {
            wobbly = true;
        }
        yeah = this.transform.position.y;
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            destination = leftPoint;
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (i == 1)
        {
            destination = rightPoint;
            this.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    }

    void Update()
    {
        if (wobbly)
        {
            this.transform.position += new Vector3(0, Mathf.Sin(yeah * Time.time) * 0.1f, 0);
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, destination.position, fishSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (this.transform.position.z == destination.position.z)
        {
            if (leftPoint.transform.position != destination.position)
            {
                destination = leftPoint;
                this.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            else 
            {
                destination = rightPoint;
                this.transform.localEulerAngles = new Vector3(0, 180, 0);
            }
        }
    }

    public void Stop()
    {
        fishSpeed = 0f;
    }
}
