using UnityEngine;

public class Droppable : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private float minXDirection = -0.5f;
    [SerializeField] private float maXDirection = 0.5f;

    [SerializeField] private float yDirection = 1f;

    [SerializeField] private float force = 5f;

    private void Start()
    {
        Drop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Drop();
    }

    public void Drop()
    {
        Debug.Log("Drop");
        rb.AddForce(GetRandomDirection());
    }

    private Vector2 GetRandomDirection()
    {
        float x = Random.Range(minXDirection, maXDirection);
        Debug.Log(new Vector2(x, yDirection));
        return new Vector2(x, yDirection) * force;
    }
}
