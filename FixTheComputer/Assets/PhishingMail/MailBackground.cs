using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBackground : MonoBehaviour
{
    [SerializeField]
    Vector2 backgroundSize = new Vector2(10, 10);

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.size = backgroundSize;
    }
}
