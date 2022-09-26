using UnityEngine;

namespace WC
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public Vector2 Position => transform.position;
        public Vector2 Velocity => _rigidbody2D.velocity;

        public void Teleport(Vector2 position)
        {
            transform.position = position;
        }

        public void Hide()
        {
            _rigidbody2D.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Punch(Vector2 force)
        {
            _rigidbody2D.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
