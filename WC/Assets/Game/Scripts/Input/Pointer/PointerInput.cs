using UnityEngine;

namespace WC
{
    public abstract class PointerInput : MonoBehaviour
    {
        public bool IsPressed { get; protected set; }
    }
}