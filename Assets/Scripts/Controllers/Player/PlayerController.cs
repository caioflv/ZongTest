using Cinemachine;
using UnityEngine;

namespace ZongGameTest
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private Rigidbody _rb;

        private Vector3 _direction;
        private float rX;
        private float rY;
        [SerializeField] float _cameraSense;

        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce = 5;

        [SerializeField] private LayerMask _groundLayer;

        private void Awake()
        {
            EventController.ToggleMenu += OnToggleMenu;
        }

        //Disabling the component disables the player's basic control functions
        private void OnToggleMenu(bool active)
        {
            this.enabled = !active;
        }

        void Update()
        {
            //Direciton axis
            _direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

            //Horizontal rotation
            rX = Mathf.Lerp(rX, rX + Input.GetAxisRaw("Mouse X") * _cameraSense, 60 * Time.deltaTime);
            //Vertical rotation
            rY = Mathf.Lerp(rY, rY - Input.GetAxisRaw("Mouse Y") * _cameraSense, 60 * Time.deltaTime);
            rY = Mathf.Clamp(rY, -70, 70);

            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.up * -1, 0.3f, _groundLayer))
            {
                _rb.AddForce(_rb.transform.up * _jumpForce, ForceMode.Acceleration);
            }
        }

        private void FixedUpdate()
        {
            //Camera X rotation
            Quaternion aux = Quaternion.Euler(_virtualCamera.transform.localRotation.x + rY, _virtualCamera.transform.localRotation.y, _virtualCamera.transform.localRotation.z);
            _virtualCamera.transform.localRotation = Quaternion.Lerp(_virtualCamera.transform.localRotation, aux, 10 * Time.fixedDeltaTime);

            //Player Y rotation
            Quaternion aux2 = Quaternion.Euler(transform.rotation.x, transform.rotation.y + rX, transform.rotation.z);
            transform.rotation = Quaternion.Lerp(transform.localRotation, aux2, 10 * Time.fixedDeltaTime);

            //Player Movement
            Vector3 vector = _rb.transform.TransformDirection(_direction);
            _rb.MovePosition(_rb.transform.position + vector * _speed * Time.fixedDeltaTime);
        }
    }

}
