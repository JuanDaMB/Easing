using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public enum EasingTypes
{
    EaseInSine,
    EaseOutSine,
    EaseInOutSine,
    EaseInBounce,
    EaseOutBounce,
    EaseInOutBounce,
    EaseInBack,
    EaseOutBack,
    EaseInOutBack,
    EaseInExpo,
    EaseOutExpo,
    EaseInOutExpo,
    EaseInQuart,
    EaseOutQuart,
    EaseInOutQuart,
    EaseInQuad,
    EaseOutQuad,
    EaseInOutQuad,
    EaseInElastic,
    EaseOutElastic,
    EaseInOutElastic,
    EaseInCirc,
    EaseOutCirc,
    EaseInOutCirc,
    EaseInQuint,
    EaseOutQuint,
    EaseInOutQuint,
    EaseInCubic,
    EaseOutCubic,
    EaseInOutCubic
}

public class Easing : MonoBehaviour
{
    public Vector3 a, b;
    public Transform ball;

    public EasingTypes easingTypes;
    
    public float time;
    private float _t;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Ease();
        }
    }

    [ContextMenu("Ease")]
    public void Ease()
    {
        StopCoroutine(RunAnimation());
        StartCoroutine(RunAnimation());
    }

    IEnumerator RunAnimation()
    {
        _t = 0;

        while (_t <= time)
        {
            ball.position = Vector3.LerpUnclamped(a, b, EasingSwitcher(_t / time));
            yield return null;
            _t += Time.deltaTime;
        }

        yield return null;
        ball.position = Vector3.LerpUnclamped(a, b, EasingSwitcher(1f));
    }

    private float EasingSwitcher(float t)
    {
        return easingTypes switch
        {
            EasingTypes.EaseInSine => EaseInSine(t),
            EasingTypes.EaseInOutBounce => (float) EaseInOutBounce(t),
            EasingTypes.EaseOutBounce => (float) EaseOutBounce(t),
            EasingTypes.EaseInBounce => (float) EaseInBounce(t),
            EasingTypes.EaseInBack => (float) EaseInBack(t),
            EasingTypes.EaseOutBack => (float) EaseOutBack(t),
            EasingTypes.EaseInOutBack => (float) EaseInOutBack(t),
            EasingTypes.EaseInExpo => EaseInExpo(t),
            EasingTypes.EaseOutExpo => EaseOutExpo(t),
            EasingTypes.EaseInOutExpo => EaseInOutExpo(t),
            EasingTypes.EaseOutSine => EaseOutSine(t),
            EasingTypes.EaseInOutSine => EaseInOutSine(t),
            EasingTypes.EaseInQuart => EaseInQuart(t),
            EasingTypes.EaseOutQuart => EaseOutQuart(t),
            EasingTypes.EaseInOutQuart => EaseInOutQuart(t),
            EasingTypes.EaseInQuad => EaseInQuad(t),
            EasingTypes.EaseOutQuad => EaseOutQuad(t),
            EasingTypes.EaseInOutQuad => EaseInOutQuad(t),
            EasingTypes.EaseInElastic => EaseInElastic(t),
            EasingTypes.EaseOutElastic => EaseOutElastic(t),
            EasingTypes.EaseInOutElastic => EaseInOutElastic(t),
            EasingTypes.EaseInCirc => EaseInCirc(t),
            EasingTypes.EaseOutCirc => EaseOutCirc(t),
            EasingTypes.EaseInOutCirc => EaseInOutCirc(t),
            EasingTypes.EaseInQuint => EaseInQuint(t),
            EasingTypes.EaseOutQuint => EaseOutQuint(t),
            EasingTypes.EaseInOutQuint => EaseInOutQuint(t),
            EasingTypes.EaseInCubic => EaseInCubic(t),
            EasingTypes.EaseOutCubic => EaseOutCubic(t),
            EasingTypes.EaseInOutCubic => EaseInOutCubic(t),
            _ => t
        };
    }
    
    float EaseInSine(float t){
        return 1 - Mathf.Cos((t * Mathf.PI) / 2);
    }
    float EaseOutSine(float x){
        return Mathf.Sin((x * Mathf.PI) / 2);
    }
    float EaseInOutSine(float x){
        return -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
    }
    float EaseInCubic(float x){
        return x * x * x;
    }float EaseOutCubic(float x){
        return 1 - Mathf.Pow(1 - x, 3);
    }
    float EaseInOutCubic(float x){
        return x < 0.5 ? 4 * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;
    }
    float EaseInQuint(float x){
        return x * x * x * x * x;
    }
    float EaseOutQuint(float x){
        return 1 - Mathf.Pow(1 - x, 5);
    }
    float EaseInOutQuint(float x){
        return x < 0.5 ? 16 * x * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 5) / 2;
    }
    float EaseInCirc(float x){
        return 1 - Mathf.Sqrt(1 - Mathf.Pow(x, 2));
    }
    float EaseOutCirc(float x){
        return Mathf.Sqrt(1 - Mathf.Pow(x - 1, 2));
    }
    float EaseInOutCirc(float x){
        return x < 0.5
            ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * x, 2))) / 2
            : (Mathf.Sqrt(1 - Mathf.Pow(-2 * x + 2, 2)) + 1) / 2;
    }
    float EaseInElastic(float x){
        double c4 = (2 * Math.PI) / 3;

        return x <= 0
            ? 0
            : x >= 1
                ? 1
                : -Mathf.Pow(2, 10 * x - 10) * Mathf.Sin((float)((x * 10 - 10.75) * c4));
    }
    float EaseOutElastic(float x){
        double c4 = (2 * Math.PI) / 3;

        return x <= 0
            ? 0
            : x >= 1
                ? 1
                : Mathf.Pow(2, -10 * x) * Mathf.Sin((float)((x * 10 - 0.75) * c4)) + 1;
    }
    float EaseInOutElastic(float x){
        double c5 = (2 * Math.PI) / 4.5;

        return x <= 0
            ? 0
            : x >= 1
                ? 1
                : x < 0.5
                    ? -(Mathf.Pow(2, 20 * x - 10) * Mathf.Sin((float)((20 * x - 11.125) * c5))) / 2
                    : (Mathf.Pow(2, -20 * x + 10) * Mathf.Sin((float)((20 * x - 11.125) * c5))) / 2 + 1;
    }
    float EaseInQuad(float x){
        return x * x;
    }
    float EaseOutQuad(float x){
        return 1 - (1 - x) * (1 - x);
    }
    float EaseInOutQuad(float x){
        return x < 0.5 ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;
    }
    float EaseInQuart(float x){
        return x * x * x * x;
    }
    float EaseOutQuart(float x){
        return 1 - Mathf.Pow(1 - x, 4);
    }
    float EaseInOutQuart(float x){
        return x < 0.5 ? 8 * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 4) / 2;
    }
    
    
    double EaseInOutBounce(float t){
        return t < 0.5f
            ? (1 - EaseOutBounce(1 - 2 * t)) / 2
            : (1 + EaseOutBounce(2 * t - 1)) / 2;
    }
    double EaseInBounce(float t){
        return 1 - EaseOutBounce(1 - t);
    }
    double EaseOutBounce(double t) {
        double n1 = 7.5625f;
        double d1 = 2.75f;

        if (t < 1 / d1) {
            return n1 * t * t;
        }

        if (t < 2 / d1) {
            return n1 * (t -= 1.5f / d1) * t + 0.75;
        }
        if (t < 2.5 / d1) {
            return n1 * (t -= 2.25f / d1) * t + 0.9375;
        }
        return n1 * (t -= 2.625f / d1) * t + 0.984375;
    }
    double EaseInBack(float t){
        double c1 = 1.70158;
        double c3 = c1 + 1;

        return c3 * t * t * t - c1 * t * t;
    }
    double EaseOutBack(float x){
        double c1 = 1.70158;
        double c3 = c1 + 1;

        return 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
    }
    
    double EaseInOutBack(float x){
        double c1 = 1.70158;
        double c2 = c1 * 1.525;

        return x < 0.5
            ? (Mathf.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2
            : (Mathf.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
    }
    
    float EaseInExpo(float x){
        return x <= 0f ? 0f : Mathf.Pow(2, 10 * x - 10);
    }
    float EaseOutExpo(float x){
        return x >= 1f ? 1f : 1f - Mathf.Pow(2, -10 * x);
    }
    float EaseInOutExpo(float x){
        return x <= 0
            ? 0
            : x >= 1f
                ? 1f
                : x < 0.5 ? Mathf.Pow(2, 20 * x - 10) / 2
                    : (2 - Mathf.Pow(2, -20 * x + 10)) / 2;
    }
}
