using System.Collections;
using UnityEngine;

public class PlatformerButton : MonoBehaviour
{
    [SerializeField] float clickTime;
    [SerializeField] Sprite Sprite1;
    [SerializeField] Sprite Sprite2;

    bool hasClicked = false;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    IEnumerator Click()
    {
        spriteRenderer.sprite = Sprite2;
        transform.position -= new Vector3(0,0.1f,0);
        yield return new WaitForSeconds(clickTime);
        transform.position += new Vector3(0, 0.1f, 0);
        spriteRenderer.sprite = Sprite1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !hasClicked)
        {
            StartCoroutine(Click());
            hasClicked = true;
        }
    }
}
