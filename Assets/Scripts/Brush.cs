using UnityEngine;

public class Brush : MonoBehaviour
{
    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
    }
}
