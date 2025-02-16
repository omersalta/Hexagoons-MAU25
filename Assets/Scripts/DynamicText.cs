using UnityEngine;
using TMPro;
using Game;
using DG.Tweening;
using System.Collections;

public class DynamicText : MonoBehaviour, ILightDarkBehaviour
{
    public string lightText = "";
    public string darkText = "";

    private TextMeshProUGUI element;

    void Start()
    {
        element = GetComponent<TextMeshProUGUI>();
        element.text = darkText;
    }

    IEnumerator change()
    {
        yield return new WaitForSeconds(1.4f);
        element.text = lightText;
    }

    public void OnLight()
    {
        element.text = darkText;
    }
    public void OnDark()
    {
        StopAllCoroutines();
        StartCoroutine(change());
    }
}
