using UnityEngine;

public class DraggableContainer : MonoBehaviour
{
    private BoxCollider boxCollider;

    private Vector3 screenPoint;
    private Vector3 offset;

    private bool isDragging = false;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) &&
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) &&
            hit.collider == boxCollider)
        {
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);

            offset = transform.position -
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
        
        if (isDragging)
        {
            Vector3 newScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(newScreenPoint) + offset;
            transform.position = newPosition;
        }
    }
}
