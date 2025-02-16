using Game;
using UnityEngine;

public class PlayerLight : MonoBehaviour,ILightDarkBehaviour
{
    private static float lightMaxScale = 8;
    private static float lightMinScale = 1;
    
    public void OnLight()
    {
        transform.localScale = new Vector3(lightMaxScale, lightMaxScale, lightMaxScale);
    }
    public void OnDark()
    {
        transform.localScale = new Vector3(lightMinScale, lightMinScale, lightMinScale);
    }
}
