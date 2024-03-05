using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZongGameTest
{
    public class BoxTrigger : MonoBehaviour
    {
        [SerializeField] private BoxesController _boxesController;
        [SerializeField] private LayerMask _sphereLayerMask;

        [SerializeField] private string _boxName;

        //A trigger inside the boxes responsible for sending the signal if there is any contact with the sphere.
        private void OnTriggerEnter(Collider other)
        {
            if (_sphereLayerMask == (_sphereLayerMask | 1 << other.gameObject.layer))
            {
                _boxesController.OnBoxTrigger(_boxName);
            }
        }
    }
}

