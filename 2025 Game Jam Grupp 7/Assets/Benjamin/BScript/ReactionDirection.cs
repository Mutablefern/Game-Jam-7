using System;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class ReactionDirection : MonoBehaviour
{
    Vector2 ButtonInput;
    int ChosenDirection = 999999;
    int PlayerNumber;
    MinigameManager MinigameManager;
    [SerializeField] float Endduration;

    private void Start()
    {
        MinigameManager = GameObject.Find("MinigameManager").GetComponent<MinigameManager>();
        string PlayerNumberString = Regex.Replace(this.gameObject.name, "[^0-9]", " ");
        int.TryParse(PlayerNumberString, out PlayerNumber);
    }
    void OnMove(InputValue InputValue)
   {
        ButtonInput = InputValue.Get<Vector2>();
        Debug.Log(ButtonInput);
        ChosenDirection = GameObject.Find("Reaction Leader").GetComponent<ReactionLeader>().ChosenDirection;

   }

    private void Update()
    {
        if (ChosenDirection == 0)
        {
            transform.position += Vector3.left * 2;
            if (ButtonInput == Vector2.left)
            {
                Win();
            }
            else
            {
                Lose();
            }
            Destroy(this.GetComponent<ReactionDirection>());
        }
        else if (ChosenDirection == 1)
        {
            transform.position += Vector3.right * 2;
            if (ButtonInput == Vector2.right)
            {
                Win();
            }
            else
            {
                Lose();
            }
            Destroy(this.GetComponent<ReactionDirection>());
        }
        else if (ChosenDirection == 2)
        {
            transform.position += Vector3.up*2;
            if (ButtonInput == Vector2.up)
            {
                Win();
            }
            else
            {
                Lose();
            }
            Destroy(this.GetComponent<ReactionDirection>());
        }
        else if (ChosenDirection == 3)
        {
            transform.position += Vector3.down*2;
            if (ButtonInput == Vector2.down)
            {
                Win();
            }
            else 
            {
                Lose();
            }
           Destroy(this.GetComponent<ReactionDirection>());
        }
        else if (ButtonInput != new Vector2(0, 0))
        {
            Lose();
        }
    }

    void Lose()
    {
        Debug.Log(this.gameObject.name + " lost");
        MinigameManager.PlayerLose(PlayerNumber, Endduration);
    }

    void Win()
    {
        Debug.Log(this.gameObject.name + " won");
        if (PlayerNumber == 1)
        {
            MinigameManager.PlayerLose(2, Endduration);
        }
        else if (PlayerNumber == 2)
        {
            MinigameManager.PlayerLose(1, Endduration);
        }
    }

}
