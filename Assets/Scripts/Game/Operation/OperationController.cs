using Game.Operation.Interfaces;
using TMPro;
using UnityEngine;

namespace Game.Operation
{
    public class OperationController : MonoBehaviour
    {
        public GameObject collectOperationEffectPrefab;
        public TextMeshPro text;
        public SpriteRenderer textBackground;
        
        private readonly float _speed = -2.0f;

        private Rigidbody2D _rb;
        private SpriteRenderer _sr;

        // TODO: Private?
        public IOperation Operation;

        public void SetOperationText(string newText)
        {
            text.SetText(newText);
            SetTextBackgroundScale();
        }

        private void SetTextBackgroundScale()
        {
            var textWidth = text.preferredWidth;
            var width = textWidth / 2.5 > textBackground.transform.localScale.x ? textWidth / 2.5 : textBackground.transform.localScale.x;
            
            textBackground.transform.localScale = new Vector3((float)width, textBackground.transform.localScale.y, 1);
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            text = GetComponent<TextMeshPro>();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void FixedUpdate()
        {
            _rb.linearVelocityY = _speed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var contact = other.GetContact(0);
            var prefab = Instantiate(collectOperationEffectPrefab, contact.point, Quaternion.identity);
            var ps = prefab.GetComponent<ParticleSystem>();

            if (Operation.Evaluate(0) < 0 && ps != null)
            {
                var main = ps.main;
                main.startColor = Color.red;
            }
            
            Destroy(gameObject);
        }
    }
}