using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TimerM : MonoBehaviour {

    private static TimerM _instance = null;

    private static int _maxTime = 300;
    public int maxTime;
    public ReactiveProperty<int> timerReactiveProperty;

    private void Awake() {
        maxTime = _maxTime;
        timerReactiveProperty = new IntReactiveProperty(_maxTime);

        if(_instance == null) {
            _instance = this;
        }
        else if(_instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start() {

        Observable.Interval(TimeSpan.FromMilliseconds(1))
            .Subscribe(_ => {
                if(timerReactiveProperty.Value > 0) {
                    timerReactiveProperty.Value--;
                }
            })
            .AddTo(this);
    }

    public static TimerM getInstance() {
        return _instance;
    }
}
