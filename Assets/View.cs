using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface {
    public class View : CustomUIComponent {

        public ViewSO viewData;

        public GameObject containerTop;
        public GameObject containerCenter;
        public GameObject containerBottom;

        public GameObject dialogueObj;
        public Dialogue dialogueSO;
        public GameObject portrait;
        public GameObject nameplate;

        private Image imageTop;
        private Image imageCenter;
        private Image imageBottom;

        private VerticalLayoutGroup verticalLayoutGroup;
        private CanvasGroup _canvasGroup;

        public override void Setup() {
            verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
            imageTop = containerTop.GetComponent<Image>();
            imageCenter = containerCenter.GetComponent<Image>();
            imageBottom = containerBottom.GetComponent<Image>();

            // Init by disabling View UI
            _canvasGroup = GetComponent<CanvasGroup>();
            EnableCanvas(false);
        }
        public override void Configure() {
            verticalLayoutGroup.padding = viewData.padding;
            verticalLayoutGroup.spacing = viewData.spacing;

            imageTop.color = viewData.theme.primary_bg;
            imageCenter.color = viewData.theme.secondary_bg;
            imageBottom.color = viewData.theme.tertiary_bg;
        }
        public void SetDialogue() {
            var dial = dialogueObj.GetComponent<Text>(); // shoudl save reference somewhere
            dial.dialogueSO = dialogueSO;
            dial.SetText();
            portrait.GetComponent<Image>().sprite = dialogueSO.sprite;
            portrait.GetComponent<Image>().SetNativeSize();
            //portrait.GetComponent<Image>().SetNativeSize();
            nameplate.GetComponent<TextMeshProUGUI>().text = dialogueSO.personName;

            EnableCanvas(true);
        }
        public void EndDialogue() {
            EnableCanvas(false);
        }
        public void EnableCanvas(bool state) {
            _canvasGroup.alpha = state ? 1 : 0;
            _canvasGroup.interactable = state;
            _canvasGroup.blocksRaycasts = state;
        }
    }
}
