using UnityEngine;

namespace ZongGameTest
{
    public class BoxesController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleBoxA;
        [SerializeField] private ParticleSystem _particleBoxB;

        //Receives information from the boxes if the sphere has been released inside it.
        public void OnBoxTrigger(string boxName)
        {
            EventController.ShowNotification?.Invoke("Dropped in box " + boxName);

            if (boxName.Equals("A"))
            {
                _particleBoxA.gameObject.SetActive(true);

                AudioController.Instance.PlayAudio(AudioType.BoxA, 0.6f);
            }

            if (boxName.Equals("B"))
            {
                _particleBoxB.gameObject.SetActive(true);

                AudioController.Instance.PlayAudio(AudioType.BoxB, 0.6f);
            }

            if (boxName.Equals("C"))
            {
                EventController.LoadCheckpoint?.Invoke();
            }
        }
    }
}


