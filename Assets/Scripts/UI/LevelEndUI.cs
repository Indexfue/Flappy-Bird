using FSM.States;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LevelEndUI : MonoBehaviour, IElementUI
    {
        public static event UnityAction OnOkClicked;
        public static event UnityAction OnShareClicked;

        private void OnEnable()
        {
            EndLevelState.Entered += ShowView;
            EndLevelState.Exited += HideView;
        }

        private void OnDisable()
        {
            EndLevelState.Entered -= ShowView;
            EndLevelState.Exited -= HideView;
        }
        
        public void ShowView()
        {
            Debug.Log("ShowView");
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