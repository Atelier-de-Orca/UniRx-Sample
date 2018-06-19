using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public static class UniRxTween {

    public static IObservable<float> Lerp<T>(this IObservable<T> observable, float startPoint, float endPoint, float duration) {
        return Observable.Empty<float>()
            .StartWith(() => Time.time)
            .SelectMany(startTime => observable.Select(_ => Time.time - startTime))
            .TakeWhile(currentTime => currentTime <= duration)
            .Select(currentTime => Mathf.Lerp(startPoint, endPoint, currentTime / duration));
    }

    public static IObservable<float> EaseInOutCubic<T>(this IObservable<T> observable, float startPoint, float endPoint, float duration) {
        return Observable.Empty<float>()
            .StartWith(() => Time.time)
            .SelectMany(startTime => observable.Select(_ => Time.time - startTime))
            .TakeWhile(currentTime => currentTime <= duration)
            .Select(currentTime => EaseInOutCubic(startPoint, endPoint, currentTime / duration));
    }

    public static IObservable<float> EaseInCubic<T>(this IObservable<T> observable, float startPoint, float endPoint, float duration) {
        return Observable.Empty<float>()
            .StartWith(() => Time.time)
            .SelectMany(startTime => observable.Select(_ => Time.time - startTime))
            .TakeWhile(currentTime => currentTime <= duration)
            .Select(currentTime => EaseInCubic(startPoint, endPoint, currentTime / duration));
    }

    public static IObservable<float> EaseOutCubic<T>(this IObservable<T> observable, float startPoint, float endPoint, float duration) {
        return Observable.Empty<float>()
            .StartWith(() => Time.time)
            .SelectMany(startTime => observable.Select(_ => Time.time - startTime))
            .TakeWhile(currentTime => currentTime <= duration)
            .Select(currentTime => EaseOutCubic(startPoint, endPoint, currentTime / duration));
    }

    // ============================================================================
    //   Private Utility
    // ============================================================================

    private static float EaseInOutCubic(float start, float end, float value) {
        value /= .5f;
        end -= start;
        if(value < 1) return end * 0.5f * value * value * value + start;
        value -= 2;
        return end * 0.5f * (value * value * value + 2) + start;
    }

    public static float EaseInCubic(float start, float end, float value) {
        end -= start;
        return end * value * value * value + start;
    }

    public static float EaseOutCubic(float start, float end, float value) {
        value--;
        end -= start;
        return end * (value * value * value + 1) + start;
    }

}
