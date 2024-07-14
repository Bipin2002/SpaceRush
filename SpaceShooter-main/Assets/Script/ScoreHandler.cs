using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler instance;
    [SerializeField] private int score;

    public TextMeshProUGUI scoreTextHolder;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void IncreaseScore(int toIncrease)
    {
        score += toIncrease;
        scoreTextHolder.text = $"{score}";
    }


    public float FinalScore()
    {
        return score;
    }

}

