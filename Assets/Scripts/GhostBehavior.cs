using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GhostLogic
{
    FOLLOW,
    DIRECTIONAL
}

public class GhostBehavior : MonoBehaviour
{
    public Transform player;

    [Header("Group A : Follow Logic")]
    public GhostSettings settingsGroupA;




    [Header("Group A : Follow Logic")]
    public GhostSettings settingsGroupB;
    public Vector2 startDirection;
    public Vector2 currentDirection;
    public Vector2 bounds;

    BoxCollider2D cd;
    Animator animator;

    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        cd = GetComponent<BoxCollider2D>();
        animator = GetComponentInChildren<Animator>();

        if (GlobalValues.group == TestGroup.GROUPA)
        {
            transform.position = settingsGroupA.startPosition;
        }
        else
        {
            transform.position = settingsGroupB.startPosition;
            currentDirection = startDirection.normalized;
            bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        }
    }

    void FixedUpdate()
    {
        if (GlobalValues.group == TestGroup.GROUPA)
        {
            GhostLogicFollow();
        }
        else
        {
            GhostLogicDirectional();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GlobalValues.playerIsAlive = false;
            SceneManager.LoadSceneAsync(2);
        }
    }

    void GhostLogicFollow()
    {
        Vector3 direction = Vector3.down;
        if (player.gameObject.activeSelf == true)
        {
            direction = (player.position - transform.position).normalized;
            transform.position += direction * settingsGroupA.speed * Time.fixedDeltaTime;
        }
        animator.SetFloat("LookX", direction.x);
        animator.SetFloat("LookY", direction.y);
    }

    void GhostLogicDirectional()
    {
        transform.Translate(currentDirection * settingsGroupB.speed * Time.fixedDeltaTime);

        Vector2 viewPos = transform.position;

        if (viewPos.x > bounds.x || viewPos.x < -bounds.x)
        {
            currentDirection.x *= -1;
        }

        if (viewPos.y > bounds.y || viewPos.y < -bounds.y)
        {
            currentDirection.y *= -1;
        }
        currentDirection.Normalize();
    }
}
