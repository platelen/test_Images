using Lesson_1.Button;
using UnityEngine;
using UnityEngine.UI;

namespace Lesson_1.ViewImages
{
    public class AddImage : MonoBehaviour
    {
        [SerializeField] private Image _viewImage;

        private void Start()
        {
            _viewImage.sprite = LoadSceneViewImage.Instance;
        }
    }
}