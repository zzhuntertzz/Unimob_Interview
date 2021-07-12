using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using UnityEngine;

namespace Interview
{
    [RequireComponent(typeof(LeanToggle))]
    public abstract class Popup : MonoBehaviour
    {
        private LeanToggle _w;
        private LeanToggle _window
        {
            get
            {
                if (_w == null)
                    _w = GetComponent<LeanToggle>();
                return _w;
            }
        }

        public void Show()
        {
            _window.TurnOn();
        }

        protected abstract void OnShow();

        public void Hide()
        {
            _window.TurnOff();
        }
        
        protected abstract void OnHide();
    }
}