using System.Collections;
using UnityEngine;

namespace WormTomb
{
    public class Ladder : MonoBehaviour, IInteractable
    {
        [SerializeField] private float climbDuration;
        [SerializeField] private PlayerTrigger ladderEndTrigger;
        [SerializeField] private Transform endTransform;
        
        private Vector2 startPos;
        private bool isClimbing;

        public bool CanInteract()
        {
            return true;
        }

        public void Interact()
        {
            StartCoroutine(ClimbLadder());
        }

        private IEnumerator ClimbLadder()
        {
            isClimbing = true;
            Player.Instance.RB.MoveTo(startPos);
            Vector2 distance = (Vector2)endTransform.position - startPos;
            Vector2 speed = distance / climbDuration;

            while (isClimbing)
            {
                Player.Instance.RB.MoveTo((Vector2)Player.Instance.Transform.position + speed * Time.deltaTime);
                yield return YieldRegistry.waitForFixedUpdate;
            }
        }

        private void Awake()
        {
            ladderEndTrigger.OnPlayerTriggered.AddListener(EndClimbing);
            startPos = transform.position;
        }

        private void EndClimbing()
        {
            Debug.Log("EndClimbing");
            isClimbing = false;
        }
    }
}
