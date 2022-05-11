using System.Collections;
using UnityEngine;
using WormTomb.General;

namespace WormTomb
{
    public class Test : MonoBehaviour
    {
        public bool isPickingUp;

        private void Update()
        {
            Debug.Log(isPickingUp);
        }

        private void OnMouseDown()
        {
            Debug.Log("MouseDown");
            isPickingUp = true;
        }

        public virtual YieldInstruction WalkTo(Vector3 targetPosition)
        {
            return StartCoroutine(GetFight(targetPosition));
        }

        private IEnumerator GetFight(Vector3 pos)
        {
            yield return YieldRegistry.WaitForSeconds(1);
            Debug.Log(pos);
        }
        
    }
}
