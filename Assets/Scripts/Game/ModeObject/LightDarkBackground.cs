using UnityEngine;

namespace Game
{
    public class LightDarkBackground : MonoBehaviour,ILightDarkBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        
        public void OnLight()
        {
            _renderer.color = Color.white;
        }
        public void OnDark()
        {
            _renderer.color = Color.grey;
        }
    }
}