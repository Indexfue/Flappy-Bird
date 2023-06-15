using System;
using FSM.States;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Scores
{
    enum Medal
    {
        BronzeMedal,
        IronMedal,
        GoldMedal,
        PlatinumMedal
    }
    
    public class Score : MonoBehaviour
    {
        [SerializeField] private int _maxScore;
        [SerializeField] private int _currentScore;
        [SerializeField] private Sprite[] _medalSprites;

        public static event UnityAction<int> ScoreChanged;
        
        public int MaxScore { get => _maxScore; }

        public int CurrentScore
        {
            get => _currentScore;
            set
            {
                _currentScore = value;
                ScoreChanged?.Invoke(_currentScore);
            }
        }

        public Sprite GetSpriteByScore()
        {
            if (_currentScore <= 10)
                return _medalSprites[0];
            if (_currentScore <= 30)
                return _medalSprites[1];
            if (_currentScore <= 50)
                return _medalSprites[2];

            return _medalSprites[3];
        }

        private void OnEnable()
        {
            ScoreTrigger.Triggered += OnScoreTriggered;
            StartLevelState.Entered += OnStartLevelEnter;
            StartLevelState.Exited += OnStartLevelExited;
        }

        private void OnDisable()
        {
            ScoreTrigger.Triggered -= OnScoreTriggered;
            StartLevelState.Entered -= OnStartLevelEnter;
            StartLevelState.Exited -= OnStartLevelExited;
        }

        private void OnStartLevelEnter() => CurrentScore = 0;

        private void OnStartLevelExited() => _maxScore = Mathf.Max(_currentScore, _maxScore);
        
        private void OnScoreTriggered() => CurrentScore = ++_currentScore;
    }
}

