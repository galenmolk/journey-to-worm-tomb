using System;
using UnityEngine;
using UnityEngine.UI;

namespace WormTomb.Utils
{
    public static class ImageExtensions
    {
        public static void SetInstanceProp(this Image image, Action<Material> setAction)
        {
            Material mat = new Material(image.material);
            setAction?.Invoke(mat);
            image.material = mat;
        }
    }
}
