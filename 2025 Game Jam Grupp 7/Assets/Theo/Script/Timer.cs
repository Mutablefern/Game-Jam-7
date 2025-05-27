using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] Sprite Sprite1;
    [SerializeField] Sprite Sprite2;
    [SerializeField] Sprite Sprite3;
    [SerializeField] Sprite Sprite4;
    [SerializeField] Sprite Sprite5;
    [SerializeField] Sprite Sprite6;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        spriteRenderer.sprite = Sprite1;
        yield return new WaitForSeconds(1);
        spriteRenderer.sprite = Sprite2;
        yield return new WaitForSeconds(1);
        spriteRenderer.sprite = Sprite3;
        yield return new WaitForSeconds(1);
        spriteRenderer.sprite = Sprite4;
        yield return new WaitForSeconds(1);
        spriteRenderer.sprite = Sprite5;
        yield return new WaitForSeconds(1);
        spriteRenderer.sprite = Sprite6;
    }
}
