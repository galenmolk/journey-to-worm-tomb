using System.Collections;
using UnityEngine;
using WormTomb;

public class Teleporter : Trigger
{
    [SerializeField] private Transform destination;
    [SerializeField] private float delay;

    protected override void TriggerEntered()
    {
        StartCoroutine(Teleport());
    }

    private IEnumerator Teleport()
    {
        yield return YieldRegistry.WaitForSeconds(delay);
        Player.Instance.transform.position = destination.position;
    }
}
