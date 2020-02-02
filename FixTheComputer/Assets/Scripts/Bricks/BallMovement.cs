using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform player;
    public WindowedScreenShake windowShake;
    public float speed;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;

        StartCoroutine(ResetBall());
    }

    private void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    IEnumerator ResetBall()
    {
        transform.position = startPos;
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(1);
        rb.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            GameObject temp = new GameObject("temp");
            AudioSource tempS = temp.AddComponent<AudioSource>();
            tempS.volume = other.gameObject.GetComponent<AudioSource>().volume;
            tempS.PlayOneShot(other.gameObject.GetComponent<AudioSource>().clip);
            other.gameObject.GetComponent<Brick>().RemoveLife();
            windowShake.Shake();
        }

        if (other.gameObject.CompareTag("Bottom"))
        {
            BrickManager.instance.lives--;
            StartCoroutine(ResetBall());
        }
    }
}
