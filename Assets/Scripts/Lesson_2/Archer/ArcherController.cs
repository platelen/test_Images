using System.Collections;
using UnityEngine;

namespace Lesson_2.Archer
{
    public class ArcherController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private Transform _startSpawnParticle;
        [SerializeField] private GameObject _particleCrack;


        private readonly float _waitCoroutine = 0.5f;
        private float _gravityForce;
        private Vector3 _moveVector;
        private bool _isAnimationPlaying;
        private bool _particleCrackSpawned = false;

        private CharacterController _characterController;
        private Animator _animator;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _animator.SetBool("IsShoot", true);
            }

            MovedCharacter();
            GravityGame();
        }

        public void ShootFinished()
        {
            _animator.SetBool("IsShoot", false);
        }


        // TODO Изменить, чтобы спавнился один за раз.
        private IEnumerator SpawnedParticlesCrack()
        {
            if (_particleCrackSpawned)
            {
                Instantiate(_particleCrack, _startSpawnParticle.position, _startSpawnParticle.rotation);
                yield return new WaitForSeconds(_waitCoroutine);
            }
        }

        private void MovedCharacter()
        {
            if (_characterController.isGrounded)
            {
                _animator.SetBool("IsJumpRun", false);
                _moveVector = Vector3.zero;
                _moveVector.x = Input.GetAxis("Horizontal") * _speed;
                _moveVector.z = Input.GetAxis("Vertical") * _speed;

                if (_moveVector.x != 0 || _moveVector.z != 0)
                {
                    _particleCrackSpawned = true;
                    _animator.SetBool("IsRun", true);
                    StartCoroutine(SpawnedParticlesCrack());
                }
                else
                {
                    _animator.SetBool("IsRun", false);
                    _particleCrackSpawned = false;
                }

                RotatedCharacter();
            }

            _moveVector.y = _gravityForce;
            _characterController.Move(_moveVector * Time.deltaTime);
        }

        private void RotatedCharacter()
        {
            if (Vector3.Angle(Vector3.forward, _moveVector) > 1f || Vector3.Angle(Vector3.forward, _moveVector) == 0)
            {
                Vector3 direct = Vector3.RotateTowards(transform.forward, _moveVector, _speed, 0.0f);
                transform.rotation = Quaternion.LookRotation(direct);
            }
        }

        private void GravityGame()
        {
            if (!_characterController.isGrounded)
                _gravityForce -= 20f * Time.deltaTime;
            else
                _gravityForce = -1f;
            if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
            {
                _gravityForce = _jumpForce;
                _animator.SetBool("IsJumpRun", true);
            }
        }
    }
}