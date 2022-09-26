using TMPro;
using UnityEngine;

namespace WC
{
    public class GoalCounterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countText;
        [SerializeField] private string _spacer = "  :  ";

        public void ShowCount(int left, int right)
        {
            _countText.text = left + _spacer + right;
        }
    }
}
