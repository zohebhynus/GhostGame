using System.Collections;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public PlayerController player;

    Collider2D collider2d;
    Transform spriteHolder;

    float closedScale = 1.5f;
    float openScale = 0.2f;
    float gateSpeed = 2.0f;

    int unlockNum = 3;

    public bool locked = true;

    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        spriteHolder = transform.Find("SpriteHolder");

        StartCoroutine(CloseGate());
    }

    // Update is called once per frame
    void Update()
    {
        if(locked && player.keysCollected == unlockNum)
        {
            StartCoroutine(OpenGate());
        }
    }

    IEnumerator OpenGate()
    {
        collider2d.enabled = false;
        locked = false;

        while (spriteHolder.localScale.y > openScale)
        {
            spriteHolder.localScale = Vector3.MoveTowards(spriteHolder.localScale, new Vector3(spriteHolder.localScale.x, openScale, spriteHolder.localScale.z), Time.deltaTime * gateSpeed);
            yield return null;
        }

        spriteHolder.localScale = new Vector3(spriteHolder.localScale.x, openScale, spriteHolder.localScale.z);

    }

    IEnumerator CloseGate()
    {
        collider2d.enabled = true;
        locked = true;

        while (spriteHolder.localScale.y < closedScale)
        {
            spriteHolder.localScale = Vector3.MoveTowards(spriteHolder.localScale, new Vector3(spriteHolder.localScale.x, closedScale, spriteHolder.localScale.z), Time.deltaTime * gateSpeed);
            yield return null;
        }

        spriteHolder.localScale = new Vector3(spriteHolder.localScale.x, closedScale, spriteHolder.localScale.z);
    }
}
