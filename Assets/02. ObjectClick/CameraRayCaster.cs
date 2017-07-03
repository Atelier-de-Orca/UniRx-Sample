using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CameraRayCaster : MonoBehaviour {
    
    // Make Stream (send gameObject when select object) 
    public Subject<GameObject> onSelectObjectStream = new Subject<GameObject>();
    public IObservable<GameObject> OnSelectObjectAsObservable {
        get {
            return onSelectObjectStream.AsObservable();
        }
    }

    private void Start() {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Select(_ => true)
            .Subscribe(_ => {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit)) {
                    GameObject ClickedObject = hit.collider.gameObject;
                    onSelectObjectStream.OnNext(ClickedObject);
                }
            });
    }
}
