using UnityEngine;
using UnityEngine.InputSystem;

public class StartGame : MonoBehaviour
{

    void OnButtonOne(InputValue Value)
    {
        if (Value.isPressed)
        {
            Debug.Log("input");
            MinigameManager.Instance.LoadRandomMicroGame(0);
        }
    }
}
