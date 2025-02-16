using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent<int> OnModeChange;
    [SerializeField] private PlayerCollector _collector;
    public float batteryLife = 100f;
    public float batteryLifeMax = 100f;
    public float lightModeDrainRate = 4f;
    public float darkModeDrainRate = 0.3f;
    private bool isDarkMode = false;
    private AudioSource effectPlayer;
    public static bool isDigging = false;
    public Animator animator;
    
    private void Start()
    {
        effectPlayer = gameObject.transform.Find("EffectPlayer").GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Batarya tüketimi
        batteryLife -= (isDarkMode ? darkModeDrainRate : lightModeDrainRate) * Time.deltaTime;
        batteryLife = Mathf.Max(batteryLife, 0);

        if (batteryLife <= 0f)
        {
            //reset Level
        }

        // Mod değişimi
        if (Input.GetKeyDown(KeyCode.B) && isDigging == false)
        {
            ToggleMode();
        }
        
        // Mod değişimi
        if (Input.GetKeyDown(KeyCode.E) && isDigging == false && isDarkMode == false)
        {
            Debug.Log("digging");
            isDigging = true;
            animator.SetBool("Running", false);
            animator.SetBool("Digging", true);
        }
    }

    private void ToggleMode()
    {
        isDarkMode = !isDarkMode;
        OnModeChange.Invoke(isDarkMode ? 2 : 1);
        effectPlayer.Play();
    }
    
    public void OnDiggingEnd()
    {
        isDigging = false;
        animator.SetBool("Digging", false);
    }

    public void OpenCollector()
    {
        _collector.gameObject.SetActive(true);
        DOVirtual.DelayedCall(0.1f, () =>
        {
            _collector.gameObject.SetActive(false);
        });
    }

    public void CollectCrystal(float value)
    {
        batteryLife += value;
        
        if (batteryLife > 100f)
        {
            batteryLife = 100f;
        }
    }
}