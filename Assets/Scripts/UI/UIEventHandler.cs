using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIEventHandler : MonoBehaviour
    {
        [SerializeField] private List<Canvas> _canvases = new List<Canvas>();

        public void Initialize()
        {
            foreach (var canvas in _canvases)
            {
                canvas.GetComponent<CanvasGroup>().alpha = 0;
            }
        }
    }
}
