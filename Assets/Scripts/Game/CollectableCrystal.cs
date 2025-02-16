using UnityEngine;

namespace Game
{
    public class CollectableCrystal : Collectable
    {

        public override void OnCollect(Player player)
        {
            Debug.Log("collected");
            player.CollectCrystal(15f);
        }
    }
}