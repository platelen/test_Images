using UnityEngine;
using Random = UnityEngine.Random;

namespace Lesson_2.Coin
{
    public class CoinController : MonoBehaviour
    {
        [SerializeField] private float _speedRotate;
        [SerializeField] private Renderer _materialCoin;

        private void Update()
        {
            RotatingCoin();
        }

        private void OnMouseDown()
        {
            SwapColor();
        }

        private void RotatingCoin()
        {
            transform.Rotate(Vector3.forward * _speedRotate * Time.deltaTime);
        }

        private void SwapColor()
        {
            _materialCoin.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}