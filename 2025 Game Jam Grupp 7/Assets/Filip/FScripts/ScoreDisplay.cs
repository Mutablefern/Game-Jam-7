using UnityEngine;
using UnityEngine.UI;
using System.Text;
using TMPro;
using System.Linq;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private CarnivalHammer[] players;

    void Start()
    {
        players = FindObjectsByType<CarnivalHammer>(FindObjectsSortMode.InstanceID);
    }

    void Update()
    {
        if (players == null || players.Length == 0 || scoreText == null) return;

        StringBuilder stringBuilder = new StringBuilder();

        foreach (CarnivalHammer player in players.OrderBy(p => p.playerNumber))
        {
            stringBuilder.AppendLine($"Player {player.playerNumber}: {(int)player.score}");
        }

        scoreText.text = stringBuilder.ToString();
    }
}
