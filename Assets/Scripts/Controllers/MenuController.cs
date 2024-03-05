using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ZongGameTest
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Transform _menu;

        private void Awake()
        {
            EventController.ToggleMenu += OnToggleMenu;

            EventController.ToggleMenu?.Invoke(false);
        }

        //When clicking on the 'X' button in the UI to close the Menu, the event is sent even though it is within the Menu class.
        //Some other class may be waiting for the open or close event
        public void ToogleMenu(bool active)
        {
            EventController.ToggleMenu?.Invoke(active);
        }

        private void OnToggleMenu(bool active)
        {
            _menu.gameObject.SetActive(active);

            ToggleCursor(active);
        }

        private void ToggleCursor(bool active)
        {
            Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = active;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EventController.ToggleMenu?.Invoke(!_menu.gameObject.activeSelf);
            }
        }
    }
}
