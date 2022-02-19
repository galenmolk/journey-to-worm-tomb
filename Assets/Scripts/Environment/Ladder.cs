using System.Collections;
using UnityEngine;

namespace WormTomb
{
    public class Ladder : MonoBehaviour, IInteractable
    {
        [SerializeField] private float climbDuration;
        [SerializeField] private PlayerTrigger ladderEndTrigger;
        [SerializeField] private Transform endTransform;
        
        private bool isClimbing;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
                Interact();
        }

        public void Interact()
        {
            StartCoroutine(ClimbLadder());
        }

        private IEnumerator ClimbLadder()
        {
            isClimbing = true;
            Vector2 distance = endTransform.position - Player.Instance.Transform.position;
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
        }

        private void EndClimbing()
        {
            Debug.Log("EndClimbing");
            isClimbing = false;
        }
    }
}
