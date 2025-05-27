using UnityEngine;

public class FindTheButtonObjectMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D my_rigidbody;
    private Vector2 moveDir;
    private int moveSpeed = 2;

    private void Start()
    {
        Mover();
    }
    void Mover()
    {
        moveDir = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        if (-2 < moveDir.x&& moveDir.x < 2 || moveDir.y < -2 && moveDir.y < 2)
        {
            Mover();
        }
        else { my_rigidbody.linearVelocity = moveDir * moveSpeed; }
    }
}
