using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Samples.Timer.Script
{
    public class TimerView : MonoBehaviour
    {
        public TextMeshProUGUI timerText;
        public Slider timerBar;

        public void UpdateView(float time, float maxTime)
        {
            this.timerText.text = $"{time:F1} sec";
            this.timerBar.value = time / maxTime;
        }
    }
}