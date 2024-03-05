using UnityEngine;


namespace ZongGameTest
{
    public partial class InteractionController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        [SerializeField] private LayerMask _objectLayer;
        [SerializeField] private Collider _objectCollider;
        private bool _objectIsVisible = false;
        private bool isLookingAtTheObject;

        [SerializeField] private RectTransform _floatingUI;
        [SerializeField] private RectTransform _Eicon;
        private Vector3 _floatingUIPosition;

        [SerializeField] private Transform _holdItemPivot;
        [SerializeField] private bool _objectIsSelected;

        private void Awake()
        {
            EventController.ToggleMenu += OnToggleMenu;
        }

        //Disabling the component disables the player's basic interaction functions with objects
        private void OnToggleMenu(bool active)
        {
            _floatingUI.gameObject.SetActive(!active);

            this.enabled = !active;
        }

        void Update()
        {
            DetectObject();
            InteractWithTheObject();
        }

        private void DetectObject()
        {
            //Identifies whether the chosen object is in the player's field of view
            Plane[] frustum = GeometryUtility.CalculateFrustumPlanes(Camera.main);
            bool insideFrustum = !_objectIsSelected && GeometryUtility.TestPlanesAABB(frustum, _objectCollider.bounds);

            float dist = (_objectCollider.transform.position - transform.position).magnitude;

            //Is it in the field of view?   Was it previously selected?   It is close to the player?
            _objectIsVisible = insideFrustum && !_objectIsSelected && dist < 10;

            _floatingUI.gameObject.SetActive(_objectIsVisible);

            if (_objectIsVisible)
            {
                //Phrase and floating point
                _floatingUIPosition = Camera.main.WorldToScreenPoint(_objectCollider.transform.position);
                _floatingUIPosition.z = 0;
                _floatingUI.position = _floatingUIPosition;

                isLookingAtTheObject = Physics.Raycast(_camera.transform.position, _camera.transform.forward, 4, _objectLayer);

                _Eicon.gameObject.SetActive(isLookingAtTheObject);
            }
        }

        private void InteractWithTheObject()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Drop the object
                if (_objectIsSelected)
                {
                    _objectCollider.transform.SetParent(null);
                    _objectCollider.enabled = true;
                    _objectCollider.transform.GetComponent<Rigidbody>().isKinematic = false;

                    _objectIsSelected = false;

                    return;
                }

                //Take the object
                if (_objectIsVisible && isLookingAtTheObject)
                {
                    TakeObject(_objectCollider);
                }
            }
        }

        public void TakeObject(Collider collider)
        {
            AudioController.Instance.PlayAudio(AudioType.TakeObject, 1);

            collider.enabled = false;
            collider.transform.GetComponent<Rigidbody>().isKinematic = true;

            collider.transform.SetParent(_holdItemPivot);
            collider.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

            _objectIsSelected = true;

            //Checkpoint purposes
            EventController.ObjectTaken?.Invoke(collider, transform.position);
        }
    }
}
