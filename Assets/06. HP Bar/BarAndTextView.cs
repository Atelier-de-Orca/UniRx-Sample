using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class BarAndTextView : MonoBehaviour {

    // Member for View and Animating HP Bar
    public Text Text;
    public Slider Slider;
    public Animator Animator;
    public ParticleSystem ParticleSystem;

    private float _timeRate = 1.0f;
    public float TimeRate {
        get { return _timeRate; }
        set { _timeRate = Mathf.Clamp(value, 0, Mathf.Infinity); }
    }

    // Private Member For animting
    private float _maxValue = 0.0f;
    private float _targetPoint = 0.0f;
    private float _currentPoint = 0.0f;
    private float _startPoint = 0.0f;
    private float _time = 0.0f;


    private Coroutine _myRoutine;

    public void UpdateViewInfo(float maxValue) {
        _maxValue = maxValue;
        Slider.maxValue = _maxValue;
    }


    // Update Function Call by Presenter
    public void UpdateView(float value) {
        if (Text != null) {
            Text.text = value.ToString(CultureInfo.CurrentCulture);
        }

        _startPoint = _currentPoint;
        _targetPoint = value;
        _time = 0.0f;

        if (_myRoutine == null) {
            _myRoutine = StartCoroutine(BarChasingCoroutine());
        }
    }

    public IEnumerator BarChasingCoroutine() {

        do {
            yield return null;

            _currentPoint = Mathf.SmoothStep(_startPoint, _targetPoint, _time/TimeRate);
            Slider.value = _currentPoint;
            _time += Time.deltaTime;

        } while (!Mathf.Approximately(_currentPoint, _targetPoint));

        _myRoutine = null;
        yield return null;
    }
}
