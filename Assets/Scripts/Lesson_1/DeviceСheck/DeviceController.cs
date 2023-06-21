using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lesson_1.DeviceСheck
{
    public class DeviceController : MonoBehaviour
    {
        [SerializeField] private string _sceneLeft;
        [SerializeField] private string _sceneRight;
        [SerializeField] private string _backSceneOnAndroid;

        private float swipeThreshold = 100f;
        private Vector2 _swipeStartPosition;


        private void Update()
        {
            CheckedPlatform();
        }

        private void CheckedPlatform()
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        _swipeStartPosition = touch.position;
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        Vector2 swipeDelta = touch.position - _swipeStartPosition;

                        if (swipeDelta.magnitude > swipeThreshold)
                        {
                            if (swipeDelta.x > 0)
                            {
                                LoadScene(_sceneRight);
                            }
                            else if (swipeDelta.x < 0)
                            {
                                LoadScene(_sceneLeft);
                            }
                        }
                    }
                }
            }
            else if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))

            {
                LoadScene(_backSceneOnAndroid);
            }
        }


        private void LoadScene(string sceneName)
        {
            SceneTransition.SceneTransition.SwitchToScene(sceneName);
        }
    }
}