using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;  // Include UI namespace for UI components.

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform rectTransform;
    public Canvas canvas;
    public CanvasGroup canvasGroup;
    private Vector3 startPosition;
    private Transform originalParent;
    public GameObject panel;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = rectTransform.anchoredPosition;
        originalParent = transform.parent;
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(canvas.transform);  // Move to canvas for higher draw order.
        if (panel != null) panel.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;  // Adjust position.
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent);  // Move back to original parent.
        rectTransform.anchoredPosition = startPosition;  // Reset to initial position.
        canvasGroup.blocksRaycasts = true;
        //if (panel != null) panel.SetActive(true);
        // Force update of the grid layout to ensure proper positioning.
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)originalParent);
    }
}
