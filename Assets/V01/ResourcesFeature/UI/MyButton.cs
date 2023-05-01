using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.V01.UI
{
    [RequireComponent(typeof(Button))]
    public class MyButton : MonoBehaviour, IPointerDownHandler
    {
        public event Action ButtonClicked;

        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            ButtonClicked?.Invoke();
        }

        public bool IsEnabled
        {
            get => _button.interactable;
            set => _button.interactable = value;
        }
    }
}
