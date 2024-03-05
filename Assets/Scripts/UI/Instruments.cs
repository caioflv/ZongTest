using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZongGameTest
{
    public class Instruments : MonoBehaviour
    {
        [SerializeField] private RectTransform _instrumentsUI;
        [SerializeField] private RectTransform _miniMap;
        [SerializeField] private RectTransform _spherePin;
        private Vector3 _spherePinPosition;

        [SerializeField] private Transform _sphere;
        [SerializeField] private Transform _player;

        //Minimap on and off. I adopted enabling and disabling the component due to practicality.
        private void OnEnable()
        {
            _instrumentsUI.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            if (_instrumentsUI)
            {
                _instrumentsUI.gameObject.SetActive(false);
            }
        }

        void Update()
        {
            //Sphere positioning on the minimap. x10 as scale adjustment.
            _spherePinPosition = (_sphere.position - _player.position) * 10;
            _spherePinPosition.y = _spherePinPosition.z;
            _spherePinPosition.z = 0;

            _spherePin.anchoredPosition = _spherePinPosition;

            //Rotation of the minimap with the objective of keeping the player's arrow always rotated upwards.
            _miniMap.rotation = Quaternion.Euler(0,0,_player.eulerAngles.y);
        }
    }
}
