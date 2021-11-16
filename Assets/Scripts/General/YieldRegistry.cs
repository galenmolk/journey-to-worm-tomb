using System.Collections.Generic;
using UnityEngine;

public static class YieldRegistry
{
    public static WaitForEndOfFrame EndOfFrame
    {
        get
        {
            if (endOfFrame == null)
                endOfFrame = new WaitForEndOfFrame();

            return endOfFrame;
        }
    }

    private static WaitForEndOfFrame endOfFrame;

    private static readonly Dictionary<float, WaitForSeconds> yieldRegistry = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds Wait(float seconds)
    {
        if (!yieldRegistry.TryGetValue(seconds, out WaitForSeconds yield))
            yield = CreateNewYield(seconds);

        return yield;
    }

    private static WaitForSeconds CreateNewYield(float seconds)
    {
        WaitForSeconds yield = new WaitForSeconds(seconds);
        yieldRegistry.Add(seconds, yield);
        return yield;
    }
}
