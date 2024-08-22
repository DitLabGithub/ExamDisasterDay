using Sirenix.OdinInspector;
using UnityEngine;

namespace UserInterface {
    [CreateAssetMenu(menuName = "CustomUI/ThemeSO", fileName = "Theme")]
    public class ThemeSO : ScriptableObject {
        [Title("Primary")]
        public Color primary_bg;
        public Color primary_text;

        [Title("Secondary")]
        public Color secondary_bg;
        public Color secondary_text;

        [Title("Tertiary")]
        public Color tertiary_bg;
        public Color tertiary_text;

        [Title("Other")]
        public Color disable;

        public Color GetBackgroundColor(Style style) {
            if (style == Style.Primary) return primary_bg;
            if (style == Style.Secondary) return secondary_bg;
            if (style == Style.Tertiary) return tertiary_bg;

            return disable;
        }
        public Color GetTextColor(Style style) {
            if (style == Style.Primary) return primary_text;
            if (style == Style.Secondary) return secondary_text;
            if (style == Style.Tertiary) return tertiary_text;

            return disable;
        }
    }
}
