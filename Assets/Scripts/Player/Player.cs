using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent<int> OnModeChange;
    public float batteryLife = 100f;
    public float lightModeDrainRate = 5f;
    public float darkModeDrainRate = 1f;
    private bool isDarkMode = false;

    void Update()
    {
        // Batarya tüketimi
        batteryLife -= (isDarkMode ? darkModeDrainRate : lightModeDrainRate) * Time.deltaTime;
        batteryLife = Mathf.Max(batteryLife, 0);

        // Mod değişimi
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("b basıldııı");
            ToggleMode();
        }
    }

    private void ToggleMode()
    {
        isDarkMode = !isDarkMode;
        OnModeChange.Invoke(isDarkMode ? 2 : 1);
    }
}