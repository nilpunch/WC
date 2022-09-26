using UnityEngine;

namespace WC
{
    public class PointerEnterGroup : MonoBehaviour
    {
        public bool IsGroupActive { get; private set; }

        public void ActivateGroup()
        {
            IsGroupActive = true;
        }

        public void DeactivateGroup()
        {
            IsGroupActive = false;
        }
    }
}
