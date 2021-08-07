using UnityEngine;

public class AutoRun : MonoBehaviour
{
    [SerializeField] private bool autoRunEnabled = true;
    [SerializeField] private float speed = 0f;

    private void FixedUpdate()
    {
        if (!autoRunEnabled)
            return;

        Run();
    }

    private void Run()
    {
        Player.Instance.RunSpeed = speed;
    }
}
