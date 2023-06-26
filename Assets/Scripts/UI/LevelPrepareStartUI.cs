using System;
using FSM.States;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LevelPrepareStartUI : MonoBehaviour, IElementUI
    {
        private CanvasGroup _canvasGroup;

        private void Start() => _canvasGroup = GetComponent<CanvasGroup>();

        private void OnEnable()
        {
            PrepareStartLevelState.Entered += ShowView;
            PrepareStartLevelState.Exited += HideView;
        }

        private void OnDisable()
        {
            PrepareStartLevelState.Entered -= ShowView;
            PrepareStartLevelState.Exited -= HideView;
        }
        
        private void CanvasViewModify(bool state)
        {
            _canvasGroup.alpha = state ? 1 : 0;
            _canvasGroup.interactable = state;
        }

        public void ShowView() => CanvasViewModify(true);

        public void HideView() => CanvasViewModify(false);
    }
}