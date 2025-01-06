using R3;

namespace Samples.Timer.Script
{
    public class TimerModel
    {
        public static TimerModel I { get { return _instance ??= new TimerModel(); } }
        private static TimerModel _instance = null;
        
        public readonly ReactiveProperty<float> TimerReactiveProperty;

        private TimerModel()
        {
            this.TimerReactiveProperty = new ReactiveProperty<float>(TimerConfig.MAX_TIME);

            _instance ??= this;
        }
    }
}
