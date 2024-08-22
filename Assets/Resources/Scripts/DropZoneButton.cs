using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // Add this for Button component

public class DropZoneButton : MonoBehaviour, IDropHandler
{
    private Button button;
    public GameObject[] inventory;

    private void Awake()
    {
        // Get the Button component on this object
        button = GetComponent<Button>();

        if (button == null)
        {
            Debug.LogWarning("No Button component found on " + gameObject.name);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null && draggable.CompareTag("phone"))
        {
            if (button != null)
            {
                // Trigger the button click on this object
                button.onClick.Invoke();
                Debug.Log("Triggered button on " + gameObject.name);
                inventory = GameObject.FindGameObjectsWithTag("Inventorytag");
                if (inventory != null)
                {
                    foreach (var item in inventory)
                    {
                        item.SetActive(false);
                    }
                }
            }
            else
            {
                Debug.LogWarning("No Button component to trigger on " + gameObject.name);
            }

            Debug.Log("Dropped " + draggable.gameObject.name + " on " + gameObject.name);
        }
    }
}