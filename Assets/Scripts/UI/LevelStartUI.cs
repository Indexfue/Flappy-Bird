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

        public static event UnityAction OnPauseClicked;

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

        public void ShowView()
        {
            GetComponent<CanvasGroup>().alpha = 1;
            GetComponent<CanvasGroup>().interactable = true;
        } 

        public void HideView()
        {
            GetComponent<CanvasGroup>().alpha = 0;
            GetComponent<CanvasGroup>().interactable = false;
        }

        public void OnScoreChange(int value) => _scoreText.text = value.ToString();
        
        public void OnPauseButtonClick() => OnPauseClicked?.Invoke();
    }
}