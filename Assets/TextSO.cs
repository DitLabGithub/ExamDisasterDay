using TMPro;
using UnityEngine;

namespace UserInterface {
    [CreateAssetMenu(menuName = "CustomUI/TextSO", fileName = "Text")]
    public class TextSO : ScriptableObject {
        public ThemeSO theme;

        public TMP_FontAsset font;
        public float size;

        // Expand this area if you want to cofigure the text in more detail
    }
}