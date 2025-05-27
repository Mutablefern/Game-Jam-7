using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WackAMolePlayer : MonoBehaviour
{
    [SerializeField] int pointsToWin = 10;
    [SerializeField] GameObject mole;
    [SerializeField] GameObject otherPlayer;
    [SerializeField] TextMeshPro scoreText;

    Vector2 inputVector;
    int score;
    bool isPressing;
    public bool canPress = true;

    Mole MoleScript;
    WackAMolePlayer otherPlayerScript;

    private void Start()
    {
        MoleScript = mole.GetComponent<Mole>();
        otherPlayerScript = otherPlayer.GetComponent<WackAMolePlayer>();
        scoreText.text = "0";
    }

    void Update()
    {
        SetPos();
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    void OnButtonOne(InputValue value)
    {

        if (value.isPressed && transform.position == mole.transform.position && canPress)
        {
            score++;
            scoreText.text = score.ToString();
            MoleScript.RandomPos();
            if (score == pointsToWin)
            {
                Debug.Log(name + " wins");
                canPress = false;
                otherPlayerScript.canPress = false;
            } 
        } 
    }

    void SetPos()
    {
        if (isPressing) { return; }
        transform.position = Vector2.zero;
        if (inputVector.x > 0)
        {
            transform.position += new Vector3(3,0);
        }
        else if (inputVector.x < 0)
        {
            transform.position += new Vector3(-3, 0);
        }

        if (inputVector.y > 0)
        {
            transform.position += new Vector3(0, 3);
        }
        else if (inputVector.y < 0)
        {
            transform.position += new Vector3(0, -3);
        }
    }


}
