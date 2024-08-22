using UnityEngine;
using UnityEngine.UI;

public class HelpButton : MonoBehaviour
{

    private Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        EventManager.ToggleDialogue += ToggleButton;
    }

    private void ToggleButton() {
        btn.interactable = !btn.interactable;
    }

    private void OnDisable() {
        EventManager.ToggleDialogue -= ToggleButton;
    }


}
