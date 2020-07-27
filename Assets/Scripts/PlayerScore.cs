using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] int playerScore = 0;
    [SerializeField] int scoreIncrement = 1;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        scoreText.text = playerScore.ToString();
    }

    public void UpdateScore()
    {
        playerScore += scoreIncrement;
    }
}
