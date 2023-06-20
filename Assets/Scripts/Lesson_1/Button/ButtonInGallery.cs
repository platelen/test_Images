using UnityEngine;

namespace Lesson_1.Button
{
    public class ButtonInGallery : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Button _buttonInGallery;

        private void OnEnable()
        {
            _buttonInGallery.onClick.AddListener(InSceneView);
        }

        private void OnDisable()
        {
            _buttonInGallery.onClick.RemoveListener(InSceneView);
        }

        private void InSceneView()
        {
            SceneTransition.SceneTransition.SwitchToScene("Gallery");
        }
    }
}