using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorBehaviour : MonoBehaviour
{
    public Vector3 startpos;
    public float speed;
    public float sinSpeed;
    void Awake()
    {
        startpos = this.transform.localPosition;
    }

    private void Update()
    {
        this.transform.position += new Vector3(Mathf.Sin(startpos.x * Time.time) * Time.deltaTime * sinSpeed, 1f * Time.deltaTime * speed, 0);
    }
    private void OnEnable()
    {
        this.transform.localPosition = startpos;
        StopAllCoroutines();
        StartCoroutine(DisableSelf());
    }

    IEnumerator DisableSelf()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }
}
