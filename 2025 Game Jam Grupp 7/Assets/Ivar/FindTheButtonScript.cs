using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FindTheButtonScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D my_rigidbody;
    [SerializeField] BoxCollider2D my_boxCollider;
    private bool hasGuessed = false;
    private Vector2 movementVector;



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
                Debug.Log("Win");
            }
            else { Debug.Log("lose"); }
        }
    }
}
