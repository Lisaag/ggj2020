using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float movement, velocity;
    public Transform windowLeftBorder, windowRightBorder, leftEdge,  rightEdge;

    // Update is called once per frame
    void FixedUpdate()
    {
        float startPos = transform.position.x;

        movement = Input.GetAxis("Horizontal");

        this.transform.Translate(Vector3.right * movement * Time.deltaTime * speed);

        if (leftEdge.position.x < windowLeftBorder.position.x)
        {
            var distanceLeft = transform.position.x - leftEdge.position.x;
            transform.position = new Vector3(windowLeftBorder.position.x + distanceLeft, transform.position.y, transform.position.z);
        }

        if (rightEdge.position.x > windowRightBorder.position.x)
        {
            var distanceRight = transform.position.x - rightEdge.position.x;
            transform.position = new Vector3(windowRightBorder.position.x + distanceRight, transform.position.y, transform.position.z);
        }

        float endPos = transform.position.x;

        velocity = (endPos - startPos) * 10;
    }
}
