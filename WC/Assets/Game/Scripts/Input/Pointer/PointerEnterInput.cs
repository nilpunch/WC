using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WC
{
    public class PointerEnterInput : PointerInput, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private PointerEnterGroup _sharedGroup;

        private void Update()
        {
            if (!_sharedGroup.IsGroupActive)
                IsPressed = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _sharedGroup.ActivateGroup();

            IsPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _sharedGroup.DeactivateGroup();

            IsPressed = false;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsPressed = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_sharedGroup.IsGroupActive)
                IsPressed = true;
        }
    }
}
