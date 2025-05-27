using UnityEngine;

public class Mole : MonoBehaviour
{
    int posID;

    private void Start()
    {
        RandomPos();
    }

    private void Update()
    {

    }

    public void RandomPos()
    {
        transform.position = Vector3.zero;
        posID = Random.Range(0, 9);
        if (posID < 3)
        {
            transform.position += new Vector3(0,3);
        }
        else if (posID > 5)
        {
            transform.position += new Vector3(0,-3);
        }

        if (posID == 0 || posID == 3 || posID == 6)
        {
            transform.position += new Vector3(-3, 0);
        }
        else if (posID == 2 || posID == 5 || posID == 8)
        {
            transform.position += new Vector3(3, 0);
        }

    }
}
