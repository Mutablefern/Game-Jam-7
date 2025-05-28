using System.Collections;
using TMPro;
using UnityEngine;

public class Promt : MonoBehaviour
{

    [SerializeField] TMP_Text Text;

    string keepText;

    void Start()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        keepText = Text.text;
        Text.text = keepText;
        yield return new WaitForSeconds(0.2f);
        Text.text = null;
        yield return new WaitForSeconds(0.2f);
        Text.text = keepText;
        yield return new WaitForSeconds(0.2f);
        Text.text = null;
        yield return new WaitForSeconds(0.2f);
        Text.text = keepText;
        yield return new WaitForSeconds(0.2f);
        Text.text = null;
        yield return new WaitForSeconds(0.2f);
        Text.text = keepText;
        yield return new WaitForSeconds(0.2f);
        Text.text = null;
        yield return new WaitForSeconds(0.2f);
    }

}
