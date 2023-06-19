using UnityEngine;

namespace Lesson_1.Button
{
    public class TestButtonClick : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(TestedClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(TestedClick);
        }

        private void TestedClick()
        {
            Debug.Log("Click on me");
        }
    }
}