using Game.Player;
using TMPro;
using UnityEngine;

namespace Game.Misc
{
    public class LivesTextController : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            
            PlayerController.OnLivesChange += UpdateLives;
        }

        private void OnDestroy()
        {
            PlayerController.OnLivesChange -= UpdateLives;
        }

        private void UpdateLives(int lives)
        {
            _text.SetText(lives.ToString());        
        }
    }
}
