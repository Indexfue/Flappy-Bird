using FSM.States;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LevelBeginningUI : MonoBehaviour, IElementUI
    {
        public static event UnityAction OnPlayClicked;
        public static event UnityAction OnLeaderboardClicked;

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

        public void OnPlayButtonClick() => OnPlayClicked?.Invoke();

        public void OnLeaderboardButtonClick() => OnLeaderboardClicked?.Invoke();
    }
}
