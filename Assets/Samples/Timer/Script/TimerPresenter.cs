using System;
using R3;

namespace Samples.Timer.Script
{
    public class TimerPresenter
    {
        private readonly TimerView _view;

        public TimerPresenter(TimerView view)
        {
            this._view = view;
        }
        
        public void StartTimer()
        {
            TimerModel.I.TimerReactiveProperty
                .Subscribe(time =>
                {
                    this._view.UpdateView(time, TimerConfig.MAX_TIME);
                })
                .AddTo(this._view);
        }
        
        public void ResetTimer()
        {
            TimerModel.I.TimerReactiveProperty.Value = TimerConfig.MAX_TIME;
        }
    }
}
