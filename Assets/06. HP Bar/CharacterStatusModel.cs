using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CharacterStatusModel {
    public ReactiveProperty<float> Hp;
    public ReactiveProperty<float> MaxHp;
    public ReactiveProperty<float> Mp;
    public ReactiveProperty<float> MaxMp;

    public ReactiveProperty<float> ConsumHpRate;
}
