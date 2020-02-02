using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float movement, velocity;
    public Transform windowLeftBorder, windowRightBorder;
    public float minRotation, maxRotation;
    Vector3 screenPoint;

    private void Start()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float startPos = transform.position.x;

        Vector3 newScreenPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(newScreenPoint);

        if (newPosition.x < windowLeftBorder.position.x)
        {
            transform.position = new Vector3(windowLeftBorder.position.x, transform.position.y, transform.position.z);
        }

        else if (newPosition.x > windowRightBorder.position.x)
        {
            transform.position = new Vector3(windowRightBorder.position.x, transform.position.y, transform.position.z);
        }

        else
        {
            transform.position = newPosition;
        }

        float endPos = transform.position.x;

        velocity = (endPos - startPos) * 10;

        //Quaternion newRot = new Quaternion(Mathf.Clamp(velocity, minRotation, maxRotation), transform.rotation.y, transform.rotation.z, transform.rotation.w);
        //transform.rotation = Quaternion.Lerp(transform.rotation, newRot, 1);

        //Vector3 direction = new Vector3(Input.mousePosition.x - transform.position.x, Input.mousePosition.y - transform.position.y, Input.mousePosition.z - transform.position.z);
        //transform.forward = direction;
    }

}
