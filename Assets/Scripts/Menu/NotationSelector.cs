using System;
using System.Collections.Generic;
using Game.Difficulty;
using Game.Misc;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Menu
{
    public class NotationSelector : MonoBehaviour
    {
        public TMP_Text notationText; 
        private readonly List<string> _notations = new() { "Infix", "Postfix" };
        private int _currentIndex = 0;

        public static string SelectedNotation { get; private set; }

        void Start()
        {
            UpdateNotation();
        }

        public void Next()
        {
            _currentIndex = (_currentIndex + 1) % _notations.Count;
            UpdateNotation();
        }

        public void Previous()
        {
            _currentIndex = (_currentIndex - 1 + _notations.Count) % _notations.Count;
            UpdateNotation();
        }

        private void UpdateNotation()
        {
            SelectedNotation = _notations[_currentIndex];
            notationText.text = SelectedNotation;
            
            // TODO: Don't parse from string!
            SettingsManager.CurrentNotation = Enum.Parse<Notation>(SelectedNotation);
            
            Debug.Log("Notation set to: " + SelectedNotation);
        }
    }
}