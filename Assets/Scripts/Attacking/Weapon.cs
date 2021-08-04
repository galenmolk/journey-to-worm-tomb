using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private float coolDownTime = 0.5f;

    protected WaitForSeconds coolDown = null;
    protected WaitForSeconds CoolDown
    {
        get
        {
            if (coolDown == null)
                coolDown = new WaitForSeconds(coolDownTime);

            return coolDown;
        }
    }

    protected bool isCoolDownInProgress = false;

    public abstract void Attack();
}
