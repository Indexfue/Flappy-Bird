using FSM.States;
using Microsoft.Unity.VisualStudio.Editor;
using Scores;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Image = UnityEngine.UI.Image;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LevelEndUI : MonoBehaviour, IElementUI
    {
        [SerializeField] private Image _medalImage;
        [SerializeField] private TMP_Text _currentScore;
        [SerializeField] private TMP_Text _maxScore;
        
        public static event UnityAction OnOkClicked;
        public static event UnityAction OnShareClicked;

        private void OnEnable()
        {
            EndLevelState.Entered += ShowView;
            EndLevelState.Entered += SetData;
            EndLevelState.Exited += HideView;
        }

        private void OnDisable()
        {
            EndLevelState.Entered -= ShowView;
            EndLevelState.Entered -= SetData;
            EndLevelState.Exited -= HideView;
        }

        private void SetData()
        {
            Score score = FindObjectOfType<Score>();

            _medalImage.sprite = score.GetSpriteByScore();
            _maxScore.text = score.MaxScore.ToString();
            _currentScore.text = score.CurrentScore.ToString();
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

        public void OnOkButtonClick() => OnOkClicked?.Invoke();

        public void OnShareButtonClick() => OnShareClicked?.Invoke();
    }
}