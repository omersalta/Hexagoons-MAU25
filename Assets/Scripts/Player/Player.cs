using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent<int> OnModeChange;
    public float batteryLife = 100f;
    public float batteryLifeMax = 100f;
    public float lightModeDrainRate = 4f;
    public float darkModeDrainRate = 0.3f;
    private bool isDarkMode = false;
    private AudioSource effectPlayer;
    public static bool isDigging = false;

    private void Start()
    {
        effectPlayer = gameObject.transform.Find("EffectPlayer").GetComponent<AudioSource>();
    }

    void Update()
    {
        // Batarya tüketimi
        batteryLife -= (isDarkMode ? darkModeDrainRate : lightModeDrainRate) * Time.deltaTime;
        batteryLife = Mathf.Max(batteryLife, 0);

        // Mod değişimi
        if (Input.GetKeyDown(KeyCode.B) && isDigging == false)
        {
            ToggleMode();
        }
        
        // Mod değişimi
        if (Input.GetKeyDown(KeyCode.LeftControl) && isDigging == false)
        {
            isDigging = true;
            DOVirtual.DelayedCall(1, () =>
            {
                isDigging = false;
            });
        }
    }

    private void ToggleMode()
    {
        isDarkMode = !isDarkMode;
        OnModeChange.Invoke(isDarkMode ? 2 : 1);
        effectPlayer.Play();
    }
}