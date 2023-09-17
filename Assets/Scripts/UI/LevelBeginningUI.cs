using System;
using FSM.States;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LevelBeginningUI : MonoBehaviour, IElementUI
    {
        private CanvasGroup _canvasGroup;
        
        public static event UnityAction OnPlayClicked;
        public static event UnityAction OnLeaderboardClicked;

        private void Start() => _canvasGroup = GetComponent<CanvasGroup>();

        private void OnEnable()
        {
            BeginningScreenLevelState.Entered += ShowView;
            BeginningScreenLevelState.Exited += HideView;
        }

        private void OnDisable()
        {
            BeginningScreenLevelState.Entered -= ShowView;
            BeginningScreenLevelState.Exited -= HideView;
        }

        private void CanvasViewModify(bool state)
        {
            _canvasGroup.alpha = state ? 1 : 0;
            _canvasGroup.interactable = state;
        }

        public void ShowView() => CanvasViewModify(true);

        public void HideView() => CanvasViewModify(false);

        public void OnPlayButtonClick() => OnPlayClicked?.Invoke();

        public void OnLeaderboardButtonClick() => OnLeaderboardClicked?.Invoke();
    }
}
