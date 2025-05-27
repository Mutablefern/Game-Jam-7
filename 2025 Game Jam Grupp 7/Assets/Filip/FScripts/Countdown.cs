using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    public float currentTime;
    public float countdown = 5f;

    [SerializeField] TMP_Text countdownText;

    void Start()
    {
        currentTime = countdown;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        if (countdownText != null)
        {
            countdownText.text = currentTime.ToString("0");
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
}