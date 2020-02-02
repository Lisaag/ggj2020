using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowedScreenShake : MonoBehaviour
{
    private Vector3 originPosition;
    private Quaternion originRotation;
    public float shake_decay = 0.002f;
    public float shake_intensity = .3f;

    private float temp_shake_intensity = 0;

    private void Start()
    {
        originPosition = transform.position;
        originPosition = transform.position;
        originRotation = transform.rotation;
    }

    void Update()
    {
        if (temp_shake_intensity > 0)
        {
            transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
            transform.rotation = new Quaternion(
                originRotation.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.y,
                originRotation.z,
                originRotation.w);
            temp_shake_intensity -= shake_decay;
        }
    }

    public void Shake()
    {
        temp_shake_intensity = shake_intensity;
    }
}
