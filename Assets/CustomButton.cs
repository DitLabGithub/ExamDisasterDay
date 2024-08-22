using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UserInterface {
    public class CustomButton : CustomUIComponent {
        public ThemeSO theme;
        public Style style;
        public UnityEvent onClick;      // Adding UnityEvent to button to call other functions when button is clicked

        private Button button;
        private TextMeshProUGUI buttonText;

        public override void Setup() {
            button  =GetComponentInChildren<Button>();
            buttonText = GetComponentInChildren<TextMeshProUGUI>();
        }
        // Changing the color of the button. Can't modify it directly.
        //
        //  Requires a bit more hassle with the following code:
        public override void Configure() {
            ColorBlock cb = button.colors;
            cb.normalColor = theme.GetBackgroundColor(style);
            button.colors = cb;

            buttonText.color = theme.GetTextColor(style);
        }

        public void OnClick() {
            onClick.Invoke();
        }
    }
}