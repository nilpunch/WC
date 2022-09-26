using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WC
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _remainingTimeText;

        public void ShowTimeLeft(float left)
        {
            if (left <= 0f)
            {
                _remainingTimeText.text = "Overtime!";
            }
            else
            {
                _remainingTimeText.text = Mathf.CeilToInt(left).ToString();
            }
        }
    }
}
