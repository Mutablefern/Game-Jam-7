using UnityEngine;
using UnityEngine.InputSystem;

public class StartGame : MonoBehaviour
{

    void onButtonOne(InputValue Value)
    {
        MinigameManager.Instance.LoadRandomMicroGame(0);
    }
}
