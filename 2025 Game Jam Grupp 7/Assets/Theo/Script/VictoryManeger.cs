using System.Collections;
using UnityEngine;

public class VictoryManeger : MonoBehaviour
{
    [SerializeField] Sprite Sprite1;
    [SerializeField] Sprite Sprite2;

    bool canRestart = false;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int WhoWon = MinigameManager.WhoLost;
        MinigameManager Manager = MinigameManager.Instance;
        StartCoroutine(wait());
        if (WhoWon == 1)
        {
            spriteRenderer.sprite = Sprite1;
        } else
        {
            spriteRenderer.sprite = Sprite2;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
        canRestart = true;
    }

    void OnButtonOne()
    {
        if (canRestart)
        {
            MinigameManager.PlayerHealth = new int[] { 5, 5 };
            MinigameManager.Instance.LoadRandomMicroGame(1);
        }
    }
}
