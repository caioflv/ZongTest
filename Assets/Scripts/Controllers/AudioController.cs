using UnityEngine;

namespace ZongGameTest
{
    public enum AudioType { Submit_UI, Back_UI, TakeObject, SphereHit, BoxA, BoxB }

    public class AudioController : MonoBehaviour
    {
        public static AudioController Instance;

        [SerializeField] private AudioSource _aSource;
        [SerializeField] private AudioClip _submitClip;
        [SerializeField] private AudioClip _backClip;

        [Header("Player")]
        [SerializeField] private AudioClip _takeObjectClip;
        [SerializeField] private AudioClip _dropObjectClip;

        [Header("Sphere")]
        [SerializeField] private AudioClip _sphereHitObjectsClip;

        [Header("Boxed")]
        [SerializeField] private AudioClip _boxAClip;
        [SerializeField] private AudioClip _boxBClip;

        private void Awake()
        {
            Instance = this;
        }

        //All audio is controlled from here. Even objects that have their own AudioSource execute audio by sending their ASources here.
        //In this example, the audios have already been predefined by an Enum.
        //Any object can call this function passing its respective Enum.Value and Audio Source as parameters if it is 3D audio.
        public void PlayAudio(AudioType type, float volume, AudioSource audioSource = null)
        {
            AudioClip clip = null;

            switch (type)
            {

                case AudioType.Submit_UI:
                    clip = _submitClip;
                break;

                case AudioType.Back_UI:
                    clip = _backClip;
                    break;

                case AudioType.TakeObject:
                    clip = _takeObjectClip;
                    break;

                case AudioType.SphereHit:
                    clip = _sphereHitObjectsClip;
                    break;

                case AudioType.BoxA:
                    clip = _boxAClip;
                    break;

                case AudioType.BoxB:
                    clip = _boxBClip;
                    break;
            }

            PlayOneShot(clip, volume, audioSource);

        }

        private void PlayOneShot(AudioClip clip, float volume, AudioSource audioSource)
        {
            if (audioSource)
            {
                audioSource.PlayOneShot(clip, volume);
            }
            else
            {
                _aSource.PlayOneShot(clip, volume);
            }
        }
    }

}

