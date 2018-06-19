using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StatusPresenter : MonoBehaviour {

    public BarAndTextView HpView;
    public BarAndTextView MpView;

    public CharacterStatusModel StatusModel;

    // Use this for initialization
    private void Start() {

        // Setup and Update Max Value
        HpView.UpdateViewInfo(StatusModel.MaxHp.Value);
        StatusModel.MaxHp
            .Subscribe(max => {
                HpView.UpdateViewInfo(max);
            });

        // Update Hp
        StatusModel.Hp
            .Subscribe(hp => {
                //
            });

        Observable.EveryUpdate()
            .Subscribe(_ => { StatusModel.Hp.Value -= StatusModel.ConsumHpRate.Value * Time.deltaTime; });
    }
}
