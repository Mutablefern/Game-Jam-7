using UnityEngine;

public class Mole : MonoBehaviour
{
    int posID, lastPos;

    private void Start()
    {
        RandomPos();
    }

    public void RandomPos()
    {
        transform.position = Vector3.zero;
        lastPos = posID;
        posID = Random.Range(0, 9);
        if( posID == lastPos)
        {
            RandomPos();
            return;
        }
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

    public int GetPosID()
    {
        return posID;
    }
}
