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
    [Range(1, 100)]
    public float playerBoostEffectiveness = 100;
    [Range(1, 100)]
    public float playerInfluence = 100f;

    private float startPos, endPos, velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform == player)
        { 
            rb.AddForce(transform.forward * speed / (100 / playerBoostEffectiveness));
            rb.AddForce(new Vector3(other.gameObject.GetComponent<PlayerMovement>().velocity * speed / (100 / playerInfluence), 0f, 0f));
        }

        if (other.gameObject.CompareTag("Brick"))
        {
            other.gameObject.GetComponent<Brick>().RemoveLife();
            windowShake.Shake();
        }
    }
}
