using FSM.States;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LevelPrepareStartUI : MonoBehaviour, IElementUI
    {
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
    }
}