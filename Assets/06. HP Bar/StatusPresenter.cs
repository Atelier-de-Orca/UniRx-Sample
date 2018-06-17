using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StatusPresenter : MonoBehaviour {

    public BarAndTextView HpView;
    public BarAndTextView MpView;

    public CharacterStatusModel StatusModel;

    // Use this for initialization
    void Start() {
        StatusModel.Hp
            .Subscribe(hp => {
                HpView.UpdateView(hp / StatusModel.MaxHp.Value);
            });

        StatusModel.Mp
            .Subscribe(mp => {
                MpView.UpdateView(mp / StatusModel.MaxMp.Value);
            });
    }
}
