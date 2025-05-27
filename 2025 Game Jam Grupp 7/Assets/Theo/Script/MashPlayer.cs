using System.Collections;
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
            Debug.Log(name + " wins");
        }
        else if (presses == otherMashPlayerScript.GetPresses())
        {
            Debug.Log("draw");
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
