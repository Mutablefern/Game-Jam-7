using System.Collections;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MashPlayer : MonoBehaviour
{
    [SerializeField] GameObject otherMashPlayer;
    [SerializeField] Sprite ButtonSprite1;
    [SerializeField] Sprite ButtonSprite2;
    [SerializeField] Sprite ButtonSprite3;
    [SerializeField] Sprite PlayerSpriteWin;
    [SerializeField] Sprite PlayerSpriteLose;
    [SerializeField] GameObject buttonGrafik;
    [SerializeField] GameObject playerGrafik;

    int presses;
    bool canPress = true;

    MashPlayer otherMashPlayerScript;
    SpriteRenderer PlayerSpriteRenderer;
    SpriteRenderer ButtonSpriteRenderer;

    private void Awake()
    {
        otherMashPlayerScript = otherMashPlayer.GetComponent<MashPlayer>();
        ButtonSpriteRenderer = buttonGrafik.GetComponent<SpriteRenderer>();
        PlayerSpriteRenderer = playerGrafik.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(Timer());
        ButtonSpriteRenderer.sprite = ButtonSprite1;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        canPress = false;
        Debug.Log(name + " Score: " +  presses);
        if (presses > otherMashPlayerScript.GetPresses())
        {
            Debug.Log(name + " wins");
            PlayerSpriteRenderer.sprite = PlayerSpriteWin;
        }
        else if (presses == otherMashPlayerScript.GetPresses())
        {
            MinigameManager.Instance.LoadRandomMicroGame(0);
        }
        else
        {
            PlayerSpriteRenderer.sprite = PlayerSpriteLose;
        }
        ButtonSpriteRenderer.sprite = ButtonSprite3;
        if (transform.position.x < 0)
        {
            buttonGrafik.transform.position += new Vector3(0.48f, -0.45f);
        }
        else
        {
            buttonGrafik.transform.position += new Vector3(-0.48f, -0.45f);
        }
        
    }

    void OnButtonOne(InputValue value)
    {
        if (value.isPressed && canPress)
        {
            presses++;
            StartCoroutine(Animate());
        }
    }

    IEnumerator Animate()
    {
        if (transform.position.x < 0)
        {
            ButtonSpriteRenderer.sprite = ButtonSprite2;
            buttonGrafik.transform.position += new Vector3(0.55f, -0.25f);
            yield return new WaitForSeconds(0.1f);
            buttonGrafik.transform.position -= new Vector3(0.55f, -0.25f);
            ButtonSpriteRenderer.sprite = ButtonSprite1;
        }
        else
        {
            ButtonSpriteRenderer.sprite = ButtonSprite2;
            buttonGrafik.transform.position += new Vector3(-0.55f, -0.25f);
            yield return new WaitForSeconds(0.1f);
            buttonGrafik.transform.position -= new Vector3(-0.55f, -0.25f);
            ButtonSpriteRenderer.sprite = ButtonSprite1;
        }
        
    }

    public int GetPresses()
    {
        return presses;
    }
}
