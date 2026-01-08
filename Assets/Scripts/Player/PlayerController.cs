using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Renderer targetRenderer;

    public int score;
    public UnityEvent OnChangedScore;

    public bool hasKey;
    public UnityEvent OnKeyPickedUp;

    public bool hasStar;
    public UnityEvent OnStarPickedUp;

    

    Material mat;

    void Start()
    {
        mat = targetRenderer.material;
        score = 0;
        hasKey = false;
        OnChangedScore?.Invoke();
    }

    private void Update()
    {
        changeColorOvertime();
    }

    public void getKey()
    {
        hasKey = true;
        OnKeyPickedUp?.Invoke();
    }

    public void getStar()
    {
        hasStar = true;
        OnStarPickedUp?.Invoke();
    }

    public void addScore(int score)
    { 
        this.score += score;
        OnChangedScore?.Invoke();
    }

    public IEnumerator changeColorOvertime()
    {
        while (true)
        {
            float t = Mathf.PingPong(Time.time * 1f, 1f);
            mat.color = Color.HSVToRGB(t, 1f, 1f);
            yield return null;
        }
    }

    public void startColorChange()
    {
        StartCoroutine(changeColorOvertime());
    }

    public void death()
    {
        SceneManager.LoadScene("DeathUIScene");
    }

    public void win()
    {
        SceneManager.LoadScene("WinUIScene");
    }

}
