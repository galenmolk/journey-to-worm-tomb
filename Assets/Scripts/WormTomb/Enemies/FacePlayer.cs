using System.Collections;
using UnityEngine;

namespace WormTomb
{
    [RequireComponent(typeof(SetFacing))]
    public class FacePlayer : MonoBehaviour
    {
        [Tooltip("The frequency in seconds that this component will try to update the facing.")]
        [SerializeField] private float updateFrequency = 1f;
        
        private SetFacing _setFacing;

        private bool shouldFacePlayer;
        
        public void StartFacingPlayer()
        {
            shouldFacePlayer = true;
            StartCoroutine(FacePlayerContinuously());
        }

        public void StopFacingPlayer()
        {
            shouldFacePlayer = false;
        }

        private IEnumerator FacePlayerContinuously()
        {
            while (shouldFacePlayer)
            {
                _setFacing.SetFacingFromTarget(Player.Instance.Transform.position);
                yield return YieldRegistry.WaitForSeconds(updateFrequency);
            }
        }
        
        private void Awake()
        {
            _setFacing = GetComponent<SetFacing>();
        }
    }
}
