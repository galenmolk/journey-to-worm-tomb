using System;
using System.Collections;
using UnityEngine;
using WormTomb.General;

namespace WormTomb.Utils
{
    public static class MonoBehaviourExtensions
    {
        public static void ExecuteAfterDelay(this MonoBehaviour mb, float delay, Action callback)
        {
            mb.StartCoroutine(DelayedCallback(delay, callback));
        }

        private static IEnumerator DelayedCallback(float delay, Action callback)
        {
            yield return YieldRegistry.WaitForSeconds(delay);
            callback?.Invoke();
        }
    }
}
