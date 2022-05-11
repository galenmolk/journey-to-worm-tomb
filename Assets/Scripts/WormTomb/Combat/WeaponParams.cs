using UnityEngine;

namespace WormTomb.Combat
{
    public class WeaponParams
    {
        public WeaponParams(LayerMask ignoreLayers)
        {
            IgnoreLayers = ignoreLayers;
        }

        public LayerMask IgnoreLayers { get; }
    }
}
