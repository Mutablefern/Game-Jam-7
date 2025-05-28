using System.Collections;
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
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Sprite Sprite1;
    [SerializeField] Sprite Sprite2;

    Vector2 inputVector;
    int score, posID;
    bool isPressing;
    public bool canPress = true;

    Mole MoleScript;
    WackAMolePlayer otherPlayerScript;
    SpriteRenderer SpriteRenderer;

    private void Start()
    {
        MoleScript = mole.GetComponent<Mole>();
        otherPlayerScript = otherPlayer.GetComponent<WackAMolePlayer>();
        scoreText.text = "0";
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = Sprite1;
    }

    private void LateUpdate()
    {
        SetPos();
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    void OnButtonOne(InputValue value)
    {
        StartCoroutine(Animate());
        if (value.isPressed && checkPos() && canPress)
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
        posID = 0;
        transform.position = Vector2.zero;
        if (inputVector.x > 0)
        {
            transform.position += new Vector3(3,0);
            posID += 2;
        }
        else if (inputVector.x < 0)
        {
            transform.position += new Vector3(-3, 0);
        }
        else
        {
            posID += 1;
        }


        if (inputVector.y > 0)
        {
            transform.position += new Vector3(0, 3);
        }
        else if (inputVector.y < 0)
        {
            transform.position += new Vector3(0, -3);
            posID += 6;
        }
        else
        {
            posID += 3;
        }
    }

    IEnumerator Animate()
    {
        isPressing = true;
        SpriteRenderer.sprite = Sprite2;
        transform.position += new Vector3(0.05f, 0.06f);
        yield return new WaitForSeconds(0.1f);
        transform.position -= new Vector3(0.05f, 0.06f);
        SpriteRenderer.sprite = Sprite1;
        isPressing = false;
    }

    bool checkPos()
    {
        if (MoleScript.GetPosID() == posID)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
