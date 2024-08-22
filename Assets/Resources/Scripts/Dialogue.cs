using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject {
    [Title("Main Dialogue")]
    [BoxGroup("MainDialogue", ShowLabel = false)]
    [HideIfGroup("MainDialogue/isEndOfDialogue")]
    public string personName;

    [BoxGroup("MainDialogue")]
    [HideIfGroup("MainDialogue/isEndOfDialogue")]
    public Sprite sprite;

    [BoxGroup("MainDialogue")]
    [HideIfGroup("MainDialogue/isEndOfDialogue")]
    [Multiline(5)]
    public string text;
    [HideIf("isEndOfDialogue")]
    public bool hasDialoguePartner;


    [Title("Dialogue Partner")]
    [DetailedInfoBox("Click for more info...",
        "Toggle this, if there is a dialogue partner. Leaving it empty removes the 2nd portrait and name plate.")]
    [BoxGroup("PartnerDialogue", ShowLabel = false)]
    [ShowIf("hasDialoguePartner")]
    public string partnerName;

    [BoxGroup("PartnerDialogue")]
    [ShowIf("hasDialoguePartner")]
    public Sprite sprite2;

    [Title("Follow-up Dialogue")]
    [BoxGroup("FollowUpDialogue", ShowLabel = false)]
    public bool isEndOfDialogue;
    [DetailedInfoBox("Click for more info...",
        "Assign the follow-up Dialogue object here. Leave empty to end the dialogue instead.")]
    [DisableIf("isEndOfDialogue")]
    [HideIf("isEndOfDialogue")]
    [BoxGroup("FollowUpDialogue")]
    public Dialogue nextDialogue;



    [ShowIf("isEndOfDialogue")]
    [BoxGroup("Scene", ShowLabel = false)]
    [Title("Scene Switching")]
    public bool goNextScene;

    //[DetailedInfoBox("Click for more info...",
    //"Assign the follow-up Scene Prefab Asset here. Leave empty if you wish to stay in this scene instead.")]
    [EnableIf("@this.goNextScene && this.isEndOfDialogue")]
    [ValidateInput("IsNull", "Put follow up Scene Prefab Asset here.")]
    [AssetsOnly]
    [ShowIf("isEndOfDialogue")]
    [BoxGroup("Scene")]
    public GameObject nextScenePrefab;

    private bool IsNull() {
        if (nextScenePrefab == null) {
            return false;
        }
        return true;
    }

}
