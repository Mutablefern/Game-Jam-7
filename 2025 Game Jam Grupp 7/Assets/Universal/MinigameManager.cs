using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance;

    public string sceneName;
    public static int[] PlayerHealth = new int[] {3, 3};

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void changeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void PlayerLose( int LostPlayer, float VictoryTime)
    {
        Debug.Log(LostPlayer);
        PlayerHealth[LostPlayer--]--; //Why does everything start with 0
        StartCoroutine(WaitForVictoryGraphics(VictoryTime));
    }
    IEnumerator WaitForVictoryGraphics(float waitingtime)
    {
        yield return new WaitForSeconds(waitingtime);
        if (PlayerHealth[1] == 0)
        {
            GameOver(1);
        }
        else if (PlayerHealth[2] == 0)
        {
            GameOver(2);
        }
        else
        {
            changeScene("TransitionScene");
        }
    }


    private void GameOver(int GameOverPlayer)
    {
        changeScene("Game Over");
    }
}
