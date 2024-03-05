using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ZongGameTest
{
    public class NotificationController : MonoBehaviour
    {
        //Message notification system that appears at the top of the screen using DOTween.

        [SerializeField] private RectTransform _notificationUI;
        [SerializeField] private TextMeshProUGUI _notificationText;

        private void Awake()
        {
            EventController.ShowNotification += OnShowNotification;
        }

        private void OnShowNotification(string text)
        {
            _notificationText.text = text;

            _notificationUI.DOKill(true);
            _notificationUI.DOAnchorPosY(-100, 1).SetEase(Ease.InOutBack).OnComplete(() => _notificationUI.DOAnchorPosY(0, 0.5f).SetEase(Ease.InOutBack).SetDelay(3));
        }
    }
}

