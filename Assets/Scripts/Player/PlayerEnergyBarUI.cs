using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyBarUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _fillImage;
    
    // Update is called once per frame
    void Update()
    {
        _fillImage.fillAmount = _player.batteryLife / _player.batteryLifeMax;
    }
}
