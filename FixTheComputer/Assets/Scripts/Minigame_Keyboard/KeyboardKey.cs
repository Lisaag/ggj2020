using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DraggableContainer))]
public class KeyboardKey : MonoBehaviour
{
    [SerializeField] private Collider area;
    [SerializeField] private float resetSpeed = 1000;
    [SerializeField] private float moveToCenterSpeed = 200;

    private DraggableContainer draggableContainer;
    private Vector3 originalPosition;
    private Collider areaCollider = null;
    private bool routineActive = false;

    public bool PositionedRight { get; private set; } = false;

    public UnityAction OnPositionedRight;

    private void Start()
    {
        draggableContainer = GetComponent<DraggableContainer>();
        draggableContainer.OnMouseUp += CheckForRightArea;

        originalPosition = transform.position;
    }

    private void CheckForRightArea(GameObject gameObject)
    {
        if (gameObject != this.gameObject)
        {
            return;
        }

        if (area == areaCollider)
        {
            PositionedRight = true;        
        }

        if (PositionedRight)
        {
            if (!routineActive)
            {
                StartCoroutine(MoveToCenter());
            }
        }
        else
        {
            if (!routineActive)
            {
                StartCoroutine(ResetPosition());
            }
        }
    }

    private IEnumerator MoveToCenter()
    {
        if (area == null)
            yield break;

        routineActive = true;
        draggableContainer.enabled = false;
        
        Vector3 curPos = transform.position;
        float d = 0;
        float dist = Vector3.Distance(area.transform.position, curPos);
        float fraction = d / dist;

        while (fraction < 1)
        {
            yield return new WaitForEndOfFrame();
            d += moveToCenterSpeed * Time.deltaTime;
            fraction = d / dist;
            transform.position = Vector3.Lerp(curPos, area.transform.position, fraction);
        }

        OnPositionedRight?.Invoke();
    }

    private IEnumerator ResetPosition()
    {
        routineActive = true;
        draggableContainer.enabled = false;

        Vector3 curPos = transform.position;
        float d = 0;
        float dist = Vector3.Distance(originalPosition, curPos); 
        float fraction = d / dist;

        while (fraction < 1)
        {
            yield return new WaitForEndOfFrame();
            d += resetSpeed * Time.deltaTime;
            fraction = d / dist;
            transform.position = Vector3.Lerp(curPos, originalPosition, fraction);
        }

        draggableContainer.enabled = true;
        routineActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        areaCollider = other;

        if (other.CompareTag("IWANTDIE"))
        {
            Debug.Log("DIE");
            draggableContainer.IsDragging = false;
            CheckForRightArea(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        areaCollider = null;
    }
}
