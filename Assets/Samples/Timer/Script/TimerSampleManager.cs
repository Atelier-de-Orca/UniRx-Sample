using UnityEngine;

namespace Samples.Timer.Script
{
    public class TimerSampleManager : MonoBehaviour
    {
        public TimerView timerView;
        
        private TimerPresenter _timerPresenter;
        
        public void Start()
        {
            if (this._timerPresenter == null)
            {
                if (this.timerView == null)
                {
                    Debug.LogError("TimerView is not assigned.");
                    return;
                }
                
                this._timerPresenter = new TimerPresenter(this.timerView);
            }
            else
            {
                this._timerPresenter.ResetTimer();
            }

            this._timerPresenter.StartTimer();
        }

        public void Update()
        {
            if(TimerModel.I.TimerReactiveProperty.Value > 0)
            {
                TimerModel.I.TimerReactiveProperty.Value -= Time.deltaTime;
            }
        }
    }
}