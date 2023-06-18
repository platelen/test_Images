using UnityEngine;

namespace Lesson_2.Car
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _rotationSpeed = 100f;
        [SerializeField] private Joystick _joystick;

        private void Update()
        {
            float moveInput = _joystick.Vertical;
            float rotationInput = _joystick.Horizontal;

            MoveCar(moveInput);
            RotateCar(rotationInput);
        }

        private void MoveCar(float moveInput)
        {
            Vector3 movement = transform.forward * moveInput * _speed * Time.deltaTime;
            transform.position += movement;
        }

        private void RotateCar(float rotationInput)
        {
            float rotation = rotationInput * _rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotation);
        }
    }
}