using UnityEngine;
using UnityEngine.EventSystems;

public class ElectionTrigger : MonoBehaviour, IDropHandler
{
    public GameObject ElectionPanel;
    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null)
        {
            // Optionally do something here, but do not change the parent or position
            Debug.Log("Dropped item on " + gameObject.name);
        }
        ElectionPanel.SetActive(true);
    }
}
