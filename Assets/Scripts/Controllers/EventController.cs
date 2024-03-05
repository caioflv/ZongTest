using System;
using UnityEngine;

namespace ZongGameTest
{
    public class EventController : MonoBehaviour
    {
        //To avoid creating variables that store other classes, an event class is used to communicate between codes.

        public static Action<Collider, Vector3> ObjectTaken;
        public static Action<bool> ToggleMenu;
        public static Action<string> ShowNotification;
        public static Action LoadCheckpoint;
    }
}
