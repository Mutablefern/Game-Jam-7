using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class BombDefusal : MonoBehaviour
{
    Countdown countdown_S;
    int PlayerNumber;
    bool isGuessing;
    [SerializeField] GameObject Kaboom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        string PlayerNumberString = Regex.Replace(this.gameObject.name, "[^0-9]", " ");
        int.TryParse(PlayerNumberString, out PlayerNumber);
        countdown_S = GetComponent<Countdown>();
        countdown_S.countdown = 5;
    }
    void OnButtonOne(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            isGuessing = true;
        }
    }
    void Update()
    {
        Debug.Log(countdown_S.currentTime);
        if (countdown_S.currentTime == 0)
        {
            ReportResult(99999);
            Instantiate(Kaboom,transform.position, Quaternion.identity);
        }
        else if (isGuessing)
        {
            ReportResult(countdown_S.currentTime);
        }
    }

    private void ReportResult(float score)
    {
        ScoreManager.Instance.ReportScore(PlayerNumber, score*-1);
        Destroy(this.gameObject);
    }
}
