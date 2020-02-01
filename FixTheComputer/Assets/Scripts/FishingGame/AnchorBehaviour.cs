using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorBehaviour : MonoBehaviour
{
    Vector3 leftRotation = new Vector3(0, 0, 80);
    Vector3 rightRotation = new Vector3(0, 0, -80);
    public float speed;
    HookBehaviour hook;
    Transform hookTransform;
    public float rotationValue;
    void Start()
    {
        hook = GetComponentInChildren<HookBehaviour>();
        hookTransform = GetComponentInChildren<HookBehaviour>().gameObject.transform;
    }
    void Update()
    {
        if (!hook.hooking)
        {
            rotationValue += speed;
            transform.localEulerAngles = Vector3.Lerp(leftRotation, rightRotation, Mathf.PingPong(rotationValue, 1.0f));
        }
    }
}
