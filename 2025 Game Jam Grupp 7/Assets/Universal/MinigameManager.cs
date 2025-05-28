using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance;

    public string sceneName;
    public static int[] PlayerHealth = new int[] {5, 5};
    [SerializeField] GameObject[] P1Hearts;
    [SerializeField] GameObject[] P2Hearts;

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
    private void Start()
    {
        Debug.Log(P1Hearts.Length);
        for (int i = P1Hearts.Length-1; i > 0; i--)
        {
            Debug.Log(i);
            if (i > PlayerHealth[0]-1)
            {
                P1Hearts[i].SetActive(false);
            }
            if (i < PlayerHealth[2])
            Debug.Log(i);
            if (i > PlayerHealth[0]-1)
            {
                P1Hearts[i].SetActive(false);
            }
            if (i > PlayerHealth[1]-1)
            {
                P2Hearts[i].SetActive(false);
            }
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
        Debug.Log(PlayerHealth[0] + ", " + PlayerHealth[1]);
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
            int SceneToChangeTo = Random.Range(2, SceneManager.sceneCountInBuildSettings - 2);
            if (SceneToChangeTo == SceneManager.sceneCountInBuildSettings-3)
            {
                SceneToChangeTo = (Random.Range(1, 3) + SceneManager.sceneCountInBuildSettings - 3);
                Debug.Log(SceneToChangeTo);
            }
            changeScenebyNumber(SceneToChangeTo);
        }
    }

    public void LoadRandomMicroGame(float AnimationTIme) //If no player loses. If you both are frame perfect you deserve to be stuck in this hell
    {
        StartCoroutine(WaitForVictoryGraphics(AnimationTIme));
    }

    private void GameOver(int GameOverPlayer)
    {
        Debug.Log(GameOverPlayer + "loses it all");
        changeScenebyName("VictoryScene");
    }
}