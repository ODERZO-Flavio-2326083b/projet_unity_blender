using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public int score;
    public UnityEvent OnChangedScore;

    public bool hasKey;
    public UnityEvent OnKeyPickedUp;

    void Start()
    {
        score = 0;
        hasKey = false;
        OnChangedScore?.Invoke();
    }

    public void getKey()
    {
        hasKey = true;
        OnKeyPickedUp?.Invoke();
    }

    public void addScore(int score)
    { 
        this.score += score;
        OnChangedScore?.Invoke();
    }

    public void removeScore(int score)
    {
        this.score -= score;
        OnChangedScore?.Invoke();
    }

}
