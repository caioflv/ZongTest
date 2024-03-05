using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZongGameTest
{
    public class SphereCollision : MonoBehaviour
    {
        [SerializeField] private AudioSource _aSource;

        //Added contact audio when sphere collides with any other collider
        private void OnCollisionEnter(Collision collision)
        {
            AudioController.Instance.PlayAudio(AudioType.SphereHit, 0.8f, _aSource);
        }
    }

}

