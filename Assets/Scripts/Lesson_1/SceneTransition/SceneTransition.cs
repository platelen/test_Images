using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Lesson_1.SceneTransition
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textPercentageLoading;
        [SerializeField] private Image _imageLoadingProgressBar;

        private AsyncOperation _loadingSceneOperation;
        private Animator _animatorTransition;

        private static SceneTransition _instance;
        private static bool _shouldPlayOpeningAnimation = false;

        public static void SwitchToScene(string sceneName)
        {
            _instance._animatorTransition.SetTrigger("sceneClosing");
            _instance._loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
            _instance._loadingSceneOperation.allowSceneActivation = false;
        }


        private void Start()
        {
            _instance = this;
            _animatorTransition = GetComponent<Animator>();
            if (_shouldPlayOpeningAnimation)
            {
                _animatorTransition.SetTrigger("sceneOpening");
            }
        }

        private void Update()
        {
            if (_loadingSceneOperation != null)
            {
                _textPercentageLoading.text = Mathf.RoundToInt(_loadingSceneOperation.progress * 100) / 0.9f + "%";
                _imageLoadingProgressBar.fillAmount = _loadingSceneOperation.progress / 0.9f;
            }
        }

        public void OnAnimationOver()
        {
            _shouldPlayOpeningAnimation = true;
            _loadingSceneOperation.allowSceneActivation = true;
        }
    }
}