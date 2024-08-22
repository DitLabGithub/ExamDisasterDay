using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserInterface;

public class EnvironmentButton : MonoBehaviour
{

    private View ui;
    private DialogueManager dialogueManager;
    private ActiveSceneManager sceneManager;

    public Dialogue dialogueSO;
    private GameObject nextScene;

    [SerializeField] private GameObject particles;

    private void Start() {
        var gm = GameObject.FindGameObjectWithTag("GameManager");
        dialogueManager = gm.GetComponent<DialogueManager>();
        sceneManager = gm.GetComponent<ActiveSceneManager>();
        ui = dialogueManager.ui;

        if(particles != null)
            Instantiate(particles, transform);

        EventManager.OnHelpEvent += PlayHelpVFX;
    }

    public void SetupDialogueManager() {
        dialogueManager.StartDialogue(dialogueSO);
    }
    public void SetUIDialogue() {
        ui.dialogueSO = dialogueSO;
        ui.SetDialogue();
    }

    private void PlayHelpVFX() {
        if (transform.childCount > 0)
            transform.GetChild(0).gameObject.GetComponent<ParticleSystem>()?.Play();
    }
    private void OnDisable() {
        EventManager.OnHelpEvent -= PlayHelpVFX;
    }
}
