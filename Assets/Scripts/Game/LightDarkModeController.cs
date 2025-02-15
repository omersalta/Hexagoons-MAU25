
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class LightDarkModeController : MonoBehaviour
    {
        private List<ILightDarkBehaviour> _lightDarkBehaviours;
        
        private void Awake()
        {
            _lightDarkBehaviours = new List<ILightDarkBehaviour>();
            IEnumerable<ILightDarkBehaviour> objectsWithInterface = FindObjectsOfType<MonoBehaviour>().OfType<ILightDarkBehaviour>();
            foreach (var behaviour in objectsWithInterface)
            {
                _lightDarkBehaviours.Add(behaviour);
            }
            FindObjectOfType<Player>().OnModeChange.AddListener(OnModeChange);
        }

        private void OnModeChange(int modeNo)
        {
            if (modeNo == 1)
            {
                foreach (var behaviour in _lightDarkBehaviours)
                {
                    behaviour.OnLight();
                }
            }

            if (modeNo == 2)
            {
                foreach (var behaviour in _lightDarkBehaviours)
                {
                    behaviour.OnDark();
                }
            }
        }
        
        
    }
}