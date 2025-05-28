using UnityEngine;
using UnityEngine.UI;
using System.Text;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private CarnivalHammer[] players;

    void Start()
    {
        players = FindObjectsOfType<CarnivalHammer>();
    }

    void Update()
    {
        if (players == null || players.Length == 0 || scoreText == null) return;

        StringBuilder stringBuilder = new StringBuilder();

        foreach (CarnivalHammer player in players)
        {
            stringBuilder.AppendLine($"Player {player.playerNumber}: {player.score:F1}");
        }

        scoreText.text = stringBuilder.ToString();
    }
}
