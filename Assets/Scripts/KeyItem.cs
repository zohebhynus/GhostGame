using UnityEngine;

public class KeyItem : MonoBehaviour
{
    Vector3 startPos;

    float frequency = 5.0f;
    float amplitude = 0.1f;

    float timeCounter;

    private Transform spriteHolder;

    private void Start()
    {

        timeCounter = Random.Range(0, Mathf.PI * 2);
        spriteHolder = transform.Find("SpriteHolder");
        startPos = spriteHolder.position;
    }

    public void Update()
    {

        timeCounter += Time.deltaTime * frequency;
        if (timeCounter > Mathf.PI * 2)
        {
            timeCounter -= Mathf.PI * 2;
        }

        float newY = startPos.y + Mathf.Sin(timeCounter) * amplitude;
        spriteHolder.position = new Vector3(startPos.x, newY, startPos.z);
    }

    public void PickUpItem(PlayerController controller)
    {
        controller.keysCollected++;

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<PlayerController>().canPickUpItem)
        {
            PickUpItem(collision.GetComponent<PlayerController>());
        }
    }
}
