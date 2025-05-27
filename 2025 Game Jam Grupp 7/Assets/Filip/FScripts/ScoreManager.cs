using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private float?[] finalScore = new float?[2];
    private bool gameEnded = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ReportScore(int playerNumber, float score)
    {
        finalScore[playerNumber-1] = score;
        Debug.Log($"Player {playerNumber} finished with score {score}");

        if (finalScore[0].HasValue && finalScore[1].HasValue && !gameEnded)
        {
            gameEnded = true;
            DetermineScore();
        }
    }

    private void DetermineScore()
    {
        float score1 = finalScore[0].Value;
        float score2 = finalScore[1].Value;

        bool p1valid = score1 <= 100;
        bool p2valid = score2 <= 100;

        if (!p1valid && !p2valid)
        {
            Debug.Log("Both players went over 100. Nobody Wins");
        }
        else if (p1valid && (!p2valid || score1 > score2))
        {
            Debug.Log("Player 1 wins!");
        }
        else if (p2valid && (!p1valid || score2 > score1))
        {
            Debug.Log("Player 2 wins!");
        }
        else
        {
            Debug.Log("It's a tie!");
        }
    }
}