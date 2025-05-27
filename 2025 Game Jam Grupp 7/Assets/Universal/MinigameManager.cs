using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
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

    public static void changeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public static void PlayerLose( int LostPlayer)
    {
        Debug.Log(LostPlayer);
        PlayerHealth[LostPlayer-1]--; //Why does everything start with 0
        MinigameManager.changeScene("TransitionScene");
    }

    private void GameOver()
    {

    }
}
