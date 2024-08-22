using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public static event Action OnHelpEvent;
    public static void StartHelpEvent() {
        OnHelpEvent?.Invoke();
    }

    public static event Action ToggleDialogue;
    public static void StartToggleDialogue() {
        ToggleDialogue?.Invoke();
    }
}
