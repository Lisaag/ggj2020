using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailHeader : MonoBehaviour
{
    [SerializeField]
    Vector2 spriteSize;

    [SerializeField]
    Color headerColor;

    [SerializeField]
    GameObject matrixIcon;

    [SerializeField]
    GameObject headerText;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.size = spriteSize;
        spriteRenderer.color = headerColor;

        Instantiate(matrixIcon, new Vector3((transform.position.x - ( (spriteRenderer.size.x / 2) - matrixIcon.GetComponent<SpriteRenderer>().size.x / 2)), transform.position.y, transform.position.z), Quaternion.identity);
        Instantiate(headerText, new Vector3((transform.position.x - ((spriteRenderer.size.x / 2) - matrixIcon.GetComponent<SpriteRenderer>().size.x * 2)), transform.position.y, transform.position.z), Quaternion.identity);
    }
}
