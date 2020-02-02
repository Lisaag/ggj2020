using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailSprite : MonoBehaviour
{
    public Vector2 mailRectSize;

    [SerializeField]
    Color hoverColor;

    [SerializeField]
    GameObject mailImage;

    [SerializeField]
    GameObject mailText;

    [SerializeField]
    Color clickedColor;

    [SerializeField]
    Color defaultColor = new Color(0, 0, 0);

    [HideInInspector]
    public int mailIndex;

    private Color currentColor;
    private int isPressed = 1;
    private PhishingGameManager phishingGameManager = null;

    SpriteRenderer spriteRenderer = null;
    BoxCollider2D boxCollider2D = null;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        SetupSprite();
        phishingGameManager = GetComponentInParent<PhishingGameManager>();
    }

    void OnMouseDown()
    {
        if (isPressed == 1)
        {
            currentColor = clickedColor;
            phishingGameManager.points++;
            phishingGameManager.deleteMails[this.mailIndex] = this.gameObject;
        }
        else
        {
            currentColor = defaultColor;
            phishingGameManager.points--;
            phishingGameManager.deleteMails[this.mailIndex] = null;
        }
        isPressed *= -1;
        spriteRenderer.color = currentColor;
        phishingGameManager.CheckWin();
    }

    void SetupSprite()
    {
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.size = mailRectSize;
        boxCollider2D.size = mailRectSize;
        spriteRenderer.color = defaultColor;
    }

    void OnMouseOver()
    {
        if (isPressed == 1) spriteRenderer.color = hoverColor;
    }

    void OnMouseExit()
    {
        if (isPressed == 1) spriteRenderer.color = defaultColor;
        else spriteRenderer.color = clickedColor;
    }

    public void SetPosition(int index)
    {
        Vector3 currentPosition = this.transform.position;
        Vector3 newPosition = new Vector3(currentPosition.x + (70 - this.mailRectSize.x) / 2, -index * mailRectSize.y, currentPosition.z);
        this.transform.position = newPosition;

        Instantiate(mailImage, new Vector3(newPosition.x - ((this.mailRectSize.x / 2) - (mailImage.GetComponent<SpriteRenderer>().size.x / 2)), newPosition.y, newPosition.z), Quaternion.identity, this.transform);
        Instantiate(mailText, new Vector3(newPosition.x - ((this.mailRectSize.x / 2) - (mailImage.GetComponent<SpriteRenderer>().size.x)), newPosition.y, newPosition.z), Quaternion.identity, this.transform);

    }
}
