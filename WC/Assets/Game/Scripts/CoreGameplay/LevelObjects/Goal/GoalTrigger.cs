using UnityEngine;

namespace WC
{
    public class GoalTrigger : MonoBehaviour
    {
        public bool Triggered { get; private set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.attachedRigidbody != null)
            {
                if (other.attachedRigidbody.TryGetComponent<Ball>(out _))
                {
                    Triggered = true;
                }
            }
        }

        public void ResetTrigger()
        {
            Triggered = false;
        }
    }
}
