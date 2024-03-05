using UnityEngine;

namespace ZongGameTest
{
    public class CheckPointController : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        private Vector3 _playerPosition;

        [SerializeField] private Collider _objectCollider;

        [SerializeField] private Instruments _instruments;

        private void Awake()
        {
            EventController.ObjectTaken += OnObjectTaken;
            EventController.LoadCheckpoint += OnLoadCheckpoint;
        }

        //When capturing the sphere for the first time, the function stops listening to the capture event,
        //recording the data of the player and the captured object.
        public void OnObjectTaken(Collider collider, Vector3 position)
        {
            EventController.ObjectTaken -= OnObjectTaken;

            _objectCollider = collider;
            _playerPosition = position;

            EventController.ToggleMenu(true);
        }

        //Upon loading the checkpoint, the instrument UI is deactivated and the player holds the sphere in their hands again.
        public void OnLoadCheckpoint()
        {
            _instruments.enabled = false;

            _playerController.transform.position = _playerPosition;
            _playerController.GetComponent<InteractionController>().TakeObject(_objectCollider);

            EventController.ToggleMenu(true);
        }
    }

}
