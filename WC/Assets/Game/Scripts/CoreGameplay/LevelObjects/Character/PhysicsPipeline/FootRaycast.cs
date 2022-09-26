using UnityEngine;

namespace WC
{
    public abstract class FootRaycast : MonoBehaviour
    {
        public FootHit FootHit { get; protected set; }

        public abstract void UpdateFootHit();
    }
}