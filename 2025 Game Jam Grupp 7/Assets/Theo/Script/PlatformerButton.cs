using UnityEngine;

public class PlatformerButton : MonoBehaviour
{
    [SerializeField] GameObject otherButton;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name + " wins");
            Destroy(otherButton);
            Destroy(gameObject);
        }
    }
}
