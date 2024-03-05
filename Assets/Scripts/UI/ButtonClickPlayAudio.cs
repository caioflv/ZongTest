using UnityEngine;
using UnityEngine.EventSystems;

namespace ZongGameTest
{
    public class ButtonClickPlayAudio : MonoBehaviour, IPointerUpHandler
    {
        [SerializeField] private AudioType type;

        //Component used to trigger the audio event if the button is clicked.
        public void OnPointerUp(PointerEventData eventData)
        {
            AudioController.Instance.PlayAudio(type, 1);
        }
    }
}

