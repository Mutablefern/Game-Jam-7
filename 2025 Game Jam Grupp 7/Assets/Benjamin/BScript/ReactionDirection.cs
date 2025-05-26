using UnityEngine;
using UnityEngine.InputSystem;
public class ReactionDirection : MonoBehaviour
{
    Vector2 ButtonInput;
    public enum Directions
    {
        Left,
        Right,
        Up,
        Down
    }
    public Directions ChosenDirection;
   void OnMove(InputValue InputValue)
   {
        ButtonInput = InputValue.Get<Vector2>();
        Debug.Log(ButtonInput);
   }

    private void Update()
    {
        if (ChosenDirection == Directions.Left)
        {
            if (ButtonInput == Vector2.left)
            {
                Debug.Log("Win");
            }
            else
            {
                Debug.LogError("Fail");
            }
        }
        if (ChosenDirection == Directions.Right)
        {
            if (ButtonInput == Vector2.right)
            {
                Debug.Log("Win");
            }
            else
            {
                Debug.LogError("Fail");
            }
        }
        if (ChosenDirection == Directions.Up)
        {
            if (ButtonInput == Vector2.up)
            {
                Debug.Log("Win");
            }
            else
            {
                Debug.LogError("Fail");
            }
        }
        if (ChosenDirection == Directions.Down)
        {
            if (ButtonInput == Vector2.down)
            {
                Debug.Log("Win");
            }
            else
            {
                Debug.LogError("Fail");
            }
        }
    }

}
