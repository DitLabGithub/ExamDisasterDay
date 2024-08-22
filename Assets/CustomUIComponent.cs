using Sirenix.OdinInspector;
using UnityEngine;

namespace UserInterface {
    public abstract class CustomUIComponent : MonoBehaviour {
        private void Awake() {
            Init();
        }

        public abstract void Setup();
        public abstract void Configure();

        [Button("Reconfigure Now")]
        private void Init() {
            Setup();
            Configure();
        }

        // Updates all UI elements marked as "dirty" (the ones you want updated) (EDITOR only)
        private void OnValidate() {
            Init();
        }
    }
}
