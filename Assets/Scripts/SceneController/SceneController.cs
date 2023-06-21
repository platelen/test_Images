using Lesson_1.SceneTransition;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneController
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(SwitcherScene);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(SwitcherScene);
        }

        public enum SceneName
        {
            MainMenu,
            MenuGallery,
            Gallery,
            ViewImage,
            Car,
            Coin,
            Character
        }

        public SceneName _enterScene;


        private void SwitcherScene()
        {
            switch (_enterScene)
            {
                case SceneName.MainMenu:
                    SceneManager.LoadScene("MainMenu");
                    break;
                case SceneName.MenuGallery:
                    SceneTransition.SwitchToScene("Menu");
                    break;
                case SceneName.Gallery:
                    SceneManager.LoadScene("Gallery");
                    break;
                case SceneName.ViewImage:
                    SceneManager.LoadScene("ViewImage");
                    break;
                case SceneName.Car:
                    SceneManager.LoadScene("3D_Car");
                    break;
                case SceneName.Coin:
                    SceneManager.LoadScene("3D_Coin");
                    break;
                case SceneName.Character:
                    SceneManager.LoadScene("3DCharacter");
                    break;
            }
        }
    }
}