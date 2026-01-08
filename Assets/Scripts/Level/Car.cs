using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float smoothFollowValue;
    [SerializeField]
    AnimationCurve animCurve;

    [SerializeField]
    public TextMeshPro infoText;

    private float timer;
    private bool keyEventTriggered;

    private void LateUpdate()
    {
        if (!(target && keyEventTriggered)) return;

        timer += Time.deltaTime;
        float t = Mathf.Clamp(timer / 5f, 0, 1);
        float curvedT = animCurve.Evaluate(t);

        transform.position = Vector3.Lerp(
            transform.position, target.position, curvedT);
    }

    public void TriggerKeyEvent()
    {
        infoText.text = "Bien joué!!!";
        keyEventTriggered = true;
    }
}
