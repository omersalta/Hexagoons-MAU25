using DG.Tweening;
using Game;
using TMPro;
using UnityEngine;

public class DarkLightUIText : MonoBehaviour,ILightDarkBehaviour
{
    private TextMeshProUGUI _textMeshPro;

    void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        OnLight();
    }

    public void OnLight()
    {
        _textMeshPro.DOKill();
        _textMeshPro.DOFade(0, 0.03f);
    }
    
    public void OnDark()
    {
        _textMeshPro.DOKill();
        _textMeshPro.DOFade(1, 3f).SetDelay(1.2f);
        
    }
}
