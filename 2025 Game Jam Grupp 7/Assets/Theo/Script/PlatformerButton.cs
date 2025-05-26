using UnityEngine;

public class PlatformerButton : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("win");
        }
    }
}
