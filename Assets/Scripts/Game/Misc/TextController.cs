using System;
using Game.Player;
using TMPro;
using UnityEngine;

namespace Game.Misc
{
    // TODO: Rename to ScoreTextController?
    public class TextController : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            
            PlayerController.OnScoreChange += UpdateScore;
        }

        private void OnDestroy()
        {
            PlayerController.OnScoreChange -= UpdateScore;
        }

        private void UpdateScore(double score)
        {
            // TODO: Round to .5?
            _text.SetText(score.ToString("F1"));        
        }
    }
}
