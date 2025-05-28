using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private float?[] finalScore = new float?[2];
    private bool gameEnded = false;
    [SerializeField] float EndingTime;

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

        bool p1valid = score1 <= 10000;
        bool p2valid = score2 <= 10000;

        if (!p1valid && !p2valid)
        {
            MinigameManager.Instance.PlayerLose(1, EndingTime);
            MinigameManager.Instance.PlayerLose(2, EndingTime);
        }
        else if (p1valid && (!p2valid || score1 > score2))
        {
            MinigameManager.Instance.PlayerLose(2, EndingTime);
        }
        else if (p2valid && (!p1valid || score2 > score1))
        {
            MinigameManager.Instance.PlayerLose(1, EndingTime);
        }
        else
        {
            MinigameManager.Instance.LoadRandomMicroGame(EndingTime);
        }
    }
}