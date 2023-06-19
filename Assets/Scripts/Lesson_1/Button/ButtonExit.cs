using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lesson_1.Button
{
    public class ButtonExit : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Button _buttonExit;

        private void OnEnable()
        {
            _buttonExit.onClick.AddListener(ExitSceneView);
        }

        private void OnDisable()
        {
            _buttonExit.onClick.RemoveListener(ExitSceneView);
        }

        private void ExitSceneView()
        {
            SceneManager.LoadScene("Gallery");
        }
    }
}