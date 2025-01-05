// using System.Collections;
// using System.Collections.Generic;
// using System.Globalization;
// using UnityEngine;
// using UnityEngine.UI;
// using UniRx;
//
// public enum smoothType {
//
// }
//
// public class BarAndTextView : MonoBehaviour {
//
//     // Member for View and Animating HP Bar
//     public Text Text;
//     public Slider Slider;
//     public Animator Animator;
//     public ParticleSystem ParticleSystem;
//
//     private float _timeRate = 1.0f;
//     public float TimeRate {
//         get { return _timeRate; }
//         set { _timeRate = Mathf.Clamp(value, 0, Mathf.Infinity); }
//     }
//
//     // Private Member For animting
//     private float _maxValue = 0.0f;
//     private FloatReactiveProperty _targetPoint;
//     private float _currentPoint = 0.0f;
//     private float _startPoint = 0.0f;
//     private float _time = 0.0f;
//
//
//     private Coroutine _myRoutine;
//
//     public void UpdateViewInfo(float maxValue) {
//         _maxValue = maxValue;
//         Slider.maxValue = _maxValue;
//     }
//
//     // Update Function Call by Presenter
//     public void UpdateTargetPoint(float value) {
//         _targetPoint.Value = value;
//     }
//
//     private void Start() {
//
//         // Hp up!
//         _targetPoint.AsObservable()
//             .Where(target => !Mathf.Approximately(target, _currentPoint))
//             .Subscribe(targetPoint => {
//                 _time = Time.deltaTime;
//                 _currentPoint = Mathf.SmoothStep(_startPoint, targetPoint, 0.4f);
//             });
//
//         // cunsom Hp!
//     }
//
//
//
// }
