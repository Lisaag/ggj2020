using UnityEngine;
using UnityEngine.Events;

public class DraggableContainer : MonoBehaviour
{
    [SerializeField] private bool requireButtonPress;

    private TrailRenderer trailRenderer;
    private AudioSource audioSource;
    private BoxCollider boxCollider;

    private Vector3 screenPoint;
    private Vector3 offset;

    public bool IsDragging { get; set; } = false;

    public bool LockDragging { get; set; } = false;

    public UnityAction<GameObject> OnMouseUp;

    private void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        if (trailRenderer)
        {
            trailRenderer.widthMultiplier = 2.5f;
        }

        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();

        if (!requireButtonPress)
        {
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);

            IsDragging = true;
        }
    }

    private void Update()
    {
        if (!LockDragging)
        {
            if (requireButtonPress)
            {
                RaycastHit hit;
                if (Input.GetMouseButtonDown(0) &&
                    Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) &&
                    hit.collider == boxCollider)
                {
                    screenPoint = Camera.main.WorldToScreenPoint(transform.position);

                    offset = transform.position -
                        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

                    IsDragging = true;

                    audioSource?.Play();
                }

                if (Input.GetMouseButtonUp(0))
                {
                    OnMouseUp?.Invoke(gameObject);
                    IsDragging = false;
                }
            }

            if (IsDragging)
            {
                Vector3 newScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(newScreenPoint);

                transform.position = newPosition;
            }
        }
    }
}
