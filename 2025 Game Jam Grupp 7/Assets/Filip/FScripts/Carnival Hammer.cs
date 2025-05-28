using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public class CarnivalHammer : MonoBehaviour
{
    [SerializeField] private Transform rotatingHammer;
    [SerializeField] private Animator animator;

    public float charge;
    private float score;
    private bool hasEnded = false;
    private int playerNumber;
    public float maxScore = 100f;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        string playerNumberString = Regex.Replace(this.gameObject.name, "[^0-9]", " ");
        int.TryParse(playerNumberString, out playerNumber);
        charge = 0f;
        StartCoroutine(Swing());
    }

    void FixedUpdate()
    {
        if (!hasEnded && charge > 0f)
        {
            charge -= 0.06f;
            Debug.Log($"Player {playerNumber} charge: {charge}");
            animator.SetBool("Charging", true);
        }
    }

    private void OnButtonOne(InputValue value)
    {
        if (!hasEnded && value.isPressed)
        {
            charge += 5f;
        }
    }

    private IEnumerator Swing()
    {
        if (!hasEnded)
        {
            yield return new WaitForSeconds(5f);

            score += charge;

            hasEnded = true;
            if (hasEnded)
            {
                animator.SetBool("Charging", false);
            }
            ReportResult();
            FinalSwing();
        }
    }

    private void ReportResult()
    {
       ScoreManager.Instance.ReportScore(playerNumber, score);
    }

    private void FinalSwing()
    {
        rotatingHammer.localRotation = Quaternion.Euler(0f, 0f, -90f);
    }
}