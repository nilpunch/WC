using TMPro;
using UnityEngine;

namespace WC
{
    public class GoalAnnouncer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goalText;

        public void Show()
        {
            _goalText.enabled = true;
        }

        public void Hide()
        {
            _goalText.enabled = false;
        }
    }
}
