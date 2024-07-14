using UnityEngine;

public class ScoreGiver : MonoBehaviour
{
    public int toGetScore;

    public void OnDisable()
    {
        ScoreHandler.instance.IncreaseScore(toGetScore);
    }
}