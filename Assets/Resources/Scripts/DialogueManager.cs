using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UserInterface;

public class DialogueManager : MonoBehaviour
{
    [ReadOnly]
    public View ui;
    [ReadOnly]
    private Dialogue dialogueSO;
    private ActiveSceneManager _sceneManager;
    public bool _hasStarted = false;

    private void Start() {
        _sceneManager = GetComponent<ActiveSceneManager>();
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<View>();
    }

    public void StartDialogue(Dialogue dialSO) {
        // Block so that first line doesnt get skipped
        StartCoroutine(BlockStart());
        EventManager.StartToggleDialogue();
        dialogueSO = dialSO;
        SetUI();
    }
    public void SetDialogueSO(Dialogue dialSO) {
        dialogueSO = dialSO;
    }

    private void SetUI() {
        if (dialogueSO == null) return;
        if (dialogueSO.isEndOfDialogue) {
            ui.EndDialogue();
            EventManager.StartToggleDialogue();
            if (dialogueSO.goNextScene) {
                _sceneManager.NextScene(dialogueSO.nextScenePrefab);
            }
            dialogueSO = null;
            return;
        }
        ui.dialogueSO = dialogueSO;
        ui.SetDialogue();
    }

    private void ProgressDialogue() {
        if (dialogueSO == null) return;
        SetDialogueSO(dialogueSO.nextDialogue);
        SetUI();
    }
    private IEnumerator BlockStart() {
        _hasStarted = false;
        yield return new WaitForSeconds(.1f);
        _hasStarted = true;
    }
    private void Update() {
        if (Input.GetMouseButtonUp(0)) {
            if (!_hasStarted) return; // Only progress if dialogue has started. prevents skipping first line
            ProgressDialogue();
        }
    }
}
