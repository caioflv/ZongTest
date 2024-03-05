using DG.Tweening;
using UnityEngine;

namespace ZongGameTest
{
    public class ExecuteUIEffectOnEnable : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        [SerializeField] private enum Actions { FadeIn, PunchScale }
        [SerializeField] private Actions _Action;

        //For UI. When the object is enabled, we can add some immediate effect.
        private void OnEnable()
        {
            switch (_Action)
            {
                case Actions.FadeIn:
                    if (_canvasGroup == null)
                    {
                        Debug.LogError("CanvasGroup is NULL");
                        return;
                    }
                    _canvasGroup.DOKill(false);
                    _canvasGroup.alpha = 0;
                    _canvasGroup.DOFade(1, 2);

                    break;

                case Actions.PunchScale:
                    transform.DOKill(true);
                    transform.DOPunchScale(Vector3.one, 0.5f, vibrato:3);

                    break;

                default:
                    break;
            }
        }
    }
}
