using System;
using System.Linq;
using System.Text;
using UnityEngine;

public class CharToByteLogger : MonoBehaviour
{
    [SerializeField] private string stringForConversion = string.Empty;

    // Unused. For display.
    [SerializeField] private string convertedBytesAsString = string.Empty;

    [ContextMenu("Convert")]
    public void ConvertToBytes()
    {
        byte[] bytes = Encoding.UTF8.GetBytes(stringForConversion);

        foreach (byte b in bytes)
        {
            convertedBytesAsString += b.ToString();
        }

        convertedBytesAsString = string.Join(string.Empty, Encoding.UTF8.GetBytes(stringForConversion).Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
    }
}
