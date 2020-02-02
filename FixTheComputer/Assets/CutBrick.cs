using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutBrick : MonoBehaviour
{
    public MeshRenderer renderer;
    bool startDecay = false;
    public Color alphaColor;
    public float timeToFade = 1.0f;

    private void Start()
    {
        GetComponent<Rigidbody>().AddExplosionForce(100, transform.position, 100);
        StartCoroutine(Lerp_MeshRenderer_Color(renderer, 0.3f, renderer.material.color, alphaColor));
    }

    void Swap()
    {
        startDecay = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (startDecay)
        {

        }
    }

    private IEnumerator Lerp_MeshRenderer_Color(MeshRenderer target_MeshRender, float lerpDuration, Color startLerp, Color targetLerp)
    {
        float lerpStart_Time = Time.time;
        float lerpProgress;
        bool lerping = true;
        while (lerping)
        {
            yield return new WaitForEndOfFrame();
            lerpProgress = Time.time - lerpStart_Time;
            if (target_MeshRender != null)
            {
                // You can re-use this block between calls rather than constructing a new one each time.
                var block = new MaterialPropertyBlock();

                block.SetColor("_BaseColor", Color.Lerp(startLerp, targetLerp, lerpProgress / lerpDuration)); 

                // You can cache a reference to the renderer to avoid searching for it.
                renderer.SetPropertyBlock(block);
            }
            else
            {
                lerping = false;
            }


            if (lerpProgress >= lerpDuration)
            {
                lerping = false;
            }
        }
        yield break;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bottom"))
        {
            //Destroy(gameObject);
        }
    }
}
