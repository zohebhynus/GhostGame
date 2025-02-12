using UnityEngine;

public class GhostBehavior : MonoBehaviour
{
    public Transform player;

    public float speed = 1.0f;

    BoxCollider2D cd;

    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        cd = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        Vector3 direction = Vector3.zero;
        if (player != null)
        {
            direction = (player.position - transform.position).normalized;
        }
        transform.position += direction * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
