using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class InfoP : MonoBehaviour {

    [SerializeField]
    private CameraRayCaster cameraRayCaster;

    [SerializeField]
    private Text infoText; 

    private void Start() {
        cameraRayCaster.OnSelectObjectAsObservable
            .Subscribe(x => {
                infoText.text = x.ToString();
                Debug.Log(x);
            });
    }

}
