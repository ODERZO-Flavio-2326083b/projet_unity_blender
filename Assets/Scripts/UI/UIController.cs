using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI scoreText;

    [SerializeField]
    public TextMeshProUGUI keyText;

    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        SetScoreText();
        keyText.text = "Clé non obtenue :(";
    }

    public void SetScoreText()
    {
        scoreText.text = "Score: " + player.score;
    }

    public void SetKeyText()
    {
        keyText.text = "Clé obtenue! :)";
    }
}
