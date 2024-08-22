using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SSIDropZone : MonoBehaviour, IDropHandler
{
    public Transform newParent;  // Assign this in the inspector to specify where the dropped items should move
    public GameObject confirmationPopup;  // Assign this popup in the inspector
    public Button confirmationButton;
    public Button cancelButton;

    private GameObject currentDraggedObject;  // To keep track of the current dragged object

    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null)
        {
            currentDraggedObject = eventData.pointerDrag;  // Store reference to the currently dragged object
            confirmationPopup.SetActive(true);

            // Setup the buttons
            confirmationButton.onClick.RemoveAllListeners();
            confirmationButton.onClick.AddListener(ConfirmDrop); // Simplify the listener
            cancelButton.onClick.RemoveAllListeners();
            cancelButton.onClick.AddListener(CancelDrop);
        }
    }

    private void ConfirmDrop()
    {
        if (currentDraggedObject != null)  // Check if the object is still valid
        {
            // Change the parent of the draggable object to 'newParent'
            currentDraggedObject.transform.SetParent(newParent, false);
            CanvasGroup canvasGroup = currentDraggedObject.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.blocksRaycasts = true; // Ensure that raycasts are blocked again
            }
            confirmationPopup.SetActive(false); // Hide the popup
            Debug.Log("Confirmed and moved to new parent.");
            currentDraggedObject = null;  // Clear the reference
        }
    }

    private void CancelDrop()
    {
        confirmationPopup.SetActive(false); // Hide the popup
        currentDraggedObject = null;  // Clear the reference
        Debug.Log("Drop canceled.");
    }
}
