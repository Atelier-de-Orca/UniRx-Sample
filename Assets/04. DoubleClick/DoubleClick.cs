using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class DoubleClick : MonoBehaviour {

    [SerializeField]
    private Button button;

    [SerializeField]
    private Text text;

	// Use this for initialization
	void Start () {
        button.onClick.AsObservable()
            .Buffer(button.onClick.AsObservable().Throttle(TimeSpan.FromMilliseconds(200)))
            .Where(x => x.Count >= 2 )
            .Subscribe(_ => {
                text.text = "Double Clicked";
            });
	}
}
