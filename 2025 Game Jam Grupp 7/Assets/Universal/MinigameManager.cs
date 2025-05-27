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

    public void changeScenebyName(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void changeScenebyNumber(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
    public void PlayerLose( int LostPlayer, float VictoryTime)
    {
        Debug.Log(LostPlayer);
        PlayerHealth[LostPlayer-1]--; //Why does everything start with 0
        StartCoroutine(WaitForVictoryGraphics(VictoryTime));
    }

    IEnumerator WaitForVictoryGraphics(float waitingtime)
    {
        yield return new WaitForSeconds(waitingtime);
        if (PlayerHealth[0] == 0)
        {
            GameOver(1);
        }
        else if (PlayerHealth[1] == 0)
        {
            GameOver(2);
        }
        else
        {
            int SceneToChangeTo = Random.Range(2, SceneManager.sceneCountInBuildSettings);
            changeScenebyNumber(SceneToChangeTo);
        }
    }

    public void LoadRandomMicroGame(float AnimationTIme) //If no player loses. If you both are frame perfect you deserve to be stuck in this hell
    {
        StartCoroutine(WaitForVictoryGraphics(AnimationTIme));
    }

    private void GameOver(int GameOverPlayer)
    {
        changeScenebyName("VictoryScene");
    }
}