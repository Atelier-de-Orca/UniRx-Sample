using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class GetSprite : MonoBehaviour {

    [SerializeField]
    private Button button;

    [SerializeField]
    private Image[] image = new Image[3];

    [SerializeField]
    private Slider[] slider = new Slider[3];

    void Start () {

        ScheduledNotifier<float> progress0 = new ScheduledNotifier<float>();
        ScheduledNotifier<float> progress1 = new ScheduledNotifier<float>();
        ScheduledNotifier<float> progress2 = new ScheduledNotifier<float>();

        progress0.Subscribe(prog => slider[0].value = prog);
        progress1.Subscribe(prog => slider[1].value = prog);
        progress2.Subscribe(prog => slider[2].value = prog);

        button.OnClickAsObservable()
            .First()
            .SelectMany(ObservableWWW.GetWWW("http://t1.daumcdn.net/liveboard/newsade/e91ec5e3f766486191dee5010e8c27cd.jpg", null, progress0))
            .Select(www => Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero))
            .Subscribe(sprite => {
                image[0].sprite = sprite;
                button.interactable = false;
            }, Debug.LogError);


        button.OnClickAsObservable()
            .First()
            .SelectMany(ObservableWWW.GetWWW("https://pbs.twimg.com/media/DDUkR_4UwAAiVyf.jpg", null, progress1))
            .Select(www => Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero))
            .Subscribe(sprite => {
                image[1].sprite = sprite;
                button.interactable = false;
            }, Debug.LogError);


        button.OnClickAsObservable()
            .First()
            .SelectMany(ObservableWWW.GetWWW("http://cfile4.uf.tistory.com/image/2566C73F5951EE972AA220", null, progress2))
            .Select(www => Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero))
            .Subscribe(sprite => {
                image[2].sprite = sprite;
                button.interactable = false;
            }, Debug.LogError);
        
    }
	
}
