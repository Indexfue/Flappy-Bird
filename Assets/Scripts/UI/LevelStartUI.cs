using System;
using FSM.States;
using Scores;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LevelStartUI : MonoBehaviour, IElementUI
    {
        [SerializeField] private TMP_Text _scoreText;

        private CanvasGroup _canvasGroup;

        public static event UnityAction OnPauseClicked;

        private void Start() => _canvasGroup = GetComponent<CanvasGroup>();

        private void OnEnable()
        {
            StartLevelState.Entered += ShowView;
            StartLevelState.Exited += HideView;
            Score.ScoreChanged += OnScoreChange;
        }

        private void OnDisable()
        {
            StartLevelState.Entered -= ShowView;
            StartLevelState.Exited -= HideView;
            Score.ScoreChanged -= OnScoreChange;
        }

        private void CanvasViewModify(bool state)
        {
            _canvasGroup.alpha = state ? 1 : 0;
            _canvasGroup.interactable = state;
        }

        public void ShowView() => CanvasViewModify(true);

        public void HideView() => CanvasViewModify(false);

        public void OnScoreChange(int value) => _scoreText.text = value.ToString();
        
        public void OnPauseButtonClick() => OnPauseClicked?.Invoke();
    }
}