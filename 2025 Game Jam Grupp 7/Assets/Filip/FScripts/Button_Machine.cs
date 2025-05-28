using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Machine : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Mashed());
        animator.SetBool("Mashed", false);
    }

    private IEnumerator Mashed()
    {
        yield return new WaitForSeconds(5f);

        animator.SetBool("Mashed", true);
    }
}
