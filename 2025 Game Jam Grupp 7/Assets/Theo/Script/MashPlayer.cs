using System.Collections;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MashPlayer : MonoBehaviour
{
    [SerializeField] GameObject otherMashPlayer;

    int presses;
    bool canPress = true;

    MashPlayer otherMashPlayerScript;


    private void Awake()
    {
        otherMashPlayerScript = otherMashPlayer.GetComponent<MashPlayer>();
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        canPress = false;
        Debug.Log(name + " Score: " +  presses);
        if (presses > otherMashPlayerScript.GetPresses())
        {
            int PlayerNumber;
            string PlayerNumberString = Regex.Replace(otherMashPlayer.name, "[^0-9]", " ");
            int.TryParse(PlayerNumberString, out PlayerNumber);
            MinigameManager.Instance.PlayerLose(PlayerNumber , 0);
        }
        else if (presses == otherMashPlayerScript.GetPresses())
        {
            MinigameManager.Instance.LoadRandomMicroGame(0);
        }
    }

    void OnButtonOne(InputValue value)
    {
        if (value.isPressed && canPress)
        {
            presses++;
        }
    }

    public int GetPresses()
    {
        return presses;
    }
}
