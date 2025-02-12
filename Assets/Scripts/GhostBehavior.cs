using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostBehavior : MonoBehaviour
{
    public Transform player;

    public float speed = 1.0f;

    BoxCollider2D cd;
    Animator animator;

    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        cd = GetComponent<BoxCollider2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        Vector3 direction = Vector3.down;
        if (player.gameObject.activeSelf == true)
        {
            direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.fixedDeltaTime;
        }
        animator.SetFloat("LookX", direction.x);
        animator.SetFloat("LookY", direction.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GlobalValues.playerIsAlive = false;
            SceneManager.LoadSceneAsync(2);
        }
    }
}
