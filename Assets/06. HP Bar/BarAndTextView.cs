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

    public float MaxTime;

    // Private Member For animting
    private float _targetPoint = 0.0f;
    private float _currentPoint = 0.0f;
    private float _startPoint = 0.0f;
    private float _time = 0.0f;
    private Coroutine _myRoutine;

    // Update Function Call by Presenter
    public void UpdateView(float hp) {
        if (Text != null) {
            Text.text = hp.ToString(CultureInfo.CurrentCulture);
        }

        _startPoint = _currentPoint;
        _targetPoint = hp;
        _time = 0.0f;

        if (_myRoutine == null) {
            _myRoutine = StartCoroutine(BarChasingCoroutine());
        }
    }

    public IEnumerator BarChasingCoroutine() {

        while (_currentPoint >= _targetPoint) {
            _currentPoint = Mathf.Lerp(_startPoint, _targetPoint, _time);
            Slider.value = _currentPoint;
            _time += Time.deltaTime;
        }

        _myRoutine = null;
        yield return null;
    }
}
