using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Lesson_1.Button
{
    public class LoadSceneViewImage : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Button _button;

        public static Sprite Instance;

        private void OnEnable()
        {
            _button.onClick.AddListener(LoadViewScene);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(LoadViewScene);
        }

        private void LoadViewScene()
        {
            GetImage();
            SceneManager.LoadScene("ViewImage");
        }

        private void GetImage()
        {
            Instance = transform.GetChild(1).GetComponent<Image>().sprite;
        }
    }
}