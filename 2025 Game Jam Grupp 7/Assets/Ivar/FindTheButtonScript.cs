using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FindTheButtonScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D my_rigidbody;
    [SerializeField] BoxCollider2D my_boxCollider;
    private bool hasGuessed = false;
    private Vector2 movementVector;
    int PlayerNumber;

    private void Start()
    {
        string PlayerNumberString = Regex.Replace(this.gameObject.name, "[^0-9]", " ");
        int.TryParse(PlayerNumberString, out PlayerNumber);
    }

    private void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>().normalized;
    }

    private void FixedUpdate()
    {
        my_rigidbody.linearVelocity = movementVector * 11f;
    }

    private void OnButtonOne(InputValue value)
    {
        hasGuessed = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(hasGuessed == true)
        {
            if (collision.gameObject.name == "CorrectButton")
            {
                if (PlayerNumber == 1) MinigameManager.Instance.PlayerLose(2, 0);
                if (PlayerNumber == 2) MinigameManager.Instance.PlayerLose(1, 0);
            }
            else { MinigameManager.Instance.PlayerLose(PlayerNumber, 0); }
        }
    }
}
