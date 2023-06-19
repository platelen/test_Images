using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Lesson_1.ScrollView
{
    public class DynamicScrollView : MonoBehaviour
    {
        [SerializeField] private Transform _scrollViewContent;
        [SerializeField] private GameObject _buttonGallery;
        [SerializeField] private List<Sprite> _spritesInButton;

        private string _serverUrl = "http://data.ikppbb.com/test-task-unity-data/pics/";

        public List<Sprite> SpritesInButton
        {
            get => _spritesInButton;
            set => _spritesInButton = value;
        }


        private void Start()
        {
            StartCoroutine(LoadSpritesFromServer());
        }

        private IEnumerator LoadSpritesFromServer()
        {
            for (int i = 0; i < _spritesInButton.Count; i++)
            {
                string imageUrl = _serverUrl + i.ToString() + ".jpg";

                UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl);
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ConnectionError ||
                    www.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogError("Error while downloading image: " + www.error);
                }
                else
                {
                    if (www.isDone)
                    {
                        Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                            Vector2.one * 0.5f);

                        _spritesInButton[i] = sprite;

                        GameObject newSpriteInButton = Instantiate(_buttonGallery, _scrollViewContent);
                        if (newSpriteInButton.TryGetComponent<ScrollViewItem>(out ScrollViewItem item))
                        {
                            item.ChangedImage(sprite);
                        }
                    }
                }
            }
        }
    }
}