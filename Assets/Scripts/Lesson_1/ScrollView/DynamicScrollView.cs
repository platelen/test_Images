using System.Collections.Generic;
using UnityEngine;

namespace Lesson_1.ScrollView
{
    public class DynamicScrollView : MonoBehaviour
    {
        [SerializeField] private Transform _scrollViewContent;
        [SerializeField] private GameObject _buttonGallery;
        [SerializeField] private List<Sprite> _spritesInButton;

        public List<Sprite> SpritesInButton
        {
            get => _spritesInButton;
            set => _spritesInButton = value;
        }


        private void Start()
        {
            foreach (Sprite spriteInButton in _spritesInButton)
            {
                GameObject newSpriteInButton = Instantiate(_buttonGallery, _scrollViewContent);
                if (newSpriteInButton.TryGetComponent<ScrollViewItem>(out ScrollViewItem item))
                {
                    item.ChangedImage(spriteInButton);
                }
            }
        }
    }
}