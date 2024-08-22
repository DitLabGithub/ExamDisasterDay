using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public Transform newParent;  // Assign this in the inspector to specify where the dropped items should move

    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null && !draggable.CompareTag("static"))
        {
            // Change the parent of the draggable object to 'newParent'
            eventData.pointerDrag.transform.SetParent(newParent, false);

            // Re-enable interactions
            CanvasGroup canvasGroup = eventData.pointerDrag.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.blocksRaycasts = true; // Ensure that raycasts are blocked again
            }
            //eventData.pointerDrag.GetComponent<Draggable>().enabled = false;
            Debug.Log("Dropped item on " + gameObject.name + " and moved to new parent.");
        }
    }

}
