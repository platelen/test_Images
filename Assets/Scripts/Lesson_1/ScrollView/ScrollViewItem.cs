using UnityEngine;
using UnityEngine.UI;

namespace Lesson_1.ScrollView
{
    public class ScrollViewItem : MonoBehaviour
    {
        [SerializeField] private Image _childImage;

        public void ChangedImage(Sprite image)
        {
            _childImage.sprite = image;
        }
    }
}