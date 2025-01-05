// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UniRx;
// using UniRx.Triggers;
//
// public class DragInput : MonoBehaviour {
//
//     public float rotationSpeed = 800.0f;
//
//     private void Start() {
//         Observable.EveryUpdate()
//             .SkipUntil(this.OnMouseDownAsObservable())
//             .Select(_ => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")))
//             .TakeUntil(this.OnMouseUpAsObservable())
//             .Repeat()
//             .Subscribe(move => {
//                 this.transform.rotation = Quaternion.AngleAxis(move.y * rotationSpeed * Time.deltaTime, Vector3.right) * Quaternion.AngleAxis(-move.x * rotationSpeed * Time.deltaTime, Vector3.up) * transform.rotation;
//             });
//
//     }
//
// }
