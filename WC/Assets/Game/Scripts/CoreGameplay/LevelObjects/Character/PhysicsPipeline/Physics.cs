using UnityEngine;

namespace WC
{
    public abstract class Physics : MonoBehaviour, IPhysics
    {
        public abstract Vector3 Position { get; }
        public abstract Vector3 Velocity { get; }
        public abstract Vector3 Depenetration { get; }

        public abstract void AddInheritedForce(Vector3 velocity);
        public abstract void AddForce(Vector3 velocity);
        public abstract void ApplyVelocityChanges();
    }
}
