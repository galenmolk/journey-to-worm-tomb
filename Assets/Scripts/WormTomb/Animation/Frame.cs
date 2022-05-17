using UnityEngine;

namespace WormTomb.Animation
{
    public abstract class Frame<T> : ScriptableObject
    {
        protected const string MENU = "Custom/Animation/Frame/";
        
        public T Value => value;
        [SerializeField] private T value;
    }
}
