using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Lesson_1.Connection
{
    public class ConnectToServer : MonoBehaviour
    {
        public Image imageComponent;
        public string imageUrl = "http://data.ikppbb.com/test-task-unity-data/pics/33.jpg";

        void Start()
        {
            StartCoroutine(LoadImage());
        }

        IEnumerator LoadImage()
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error while downloading image: " + www.error);
            }
            else
            {
                if (www.isDone)
                {
                    Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

                    // Присваивание спрайта к компоненту Image
                    imageComponent.sprite = sprite;
                }
            }
        }
    }
}