using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ReactionLeader : MonoBehaviour
{
    public int ChosenDirection = 99999999;
    [SerializeField] GameObject[] DirectionObject;

    private void Start()
    {
        StartCoroutine(Choose());
    }

    IEnumerator Choose()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        ChosenDirection = Random.Range(0, 4);
        Debug.Log(ChosenDirection);
        Instantiate(DirectionObject[ChosenDirection], transform.position, Quaternion.identity);
    }
}