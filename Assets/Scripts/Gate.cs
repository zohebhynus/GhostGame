using System.Collections;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public PlayerController player;

    BoxCollider2D cd;
    Transform spriteHolder;
    AudioSource audioSource;

    float closedScale = 1.5f;
    float openScale = 0.2f;
    float gateSpeed = 2.0f;

    int unlockNum = 3;

    public bool locked = true;
    public AudioClip gateSound;

    Camera cam;
    Vector3 originalCamPos;
    float shakeDuration = 0.0f;
    float shakeMagnitude = 0.05f;

    void Start()
    {
        cd = GetComponent<BoxCollider2D>();
        spriteHolder = transform.Find("SpriteHolder");
        audioSource = GetComponent<AudioSource>();
        cam = Camera.main;
        originalCamPos = cam.transform.position;

        StartCoroutine(CloseGate());
    }

    // Update is called once per frame
    void Update()
    {
        if(locked && player.keysCollected == unlockNum)
        {
            StartCoroutine(OpenGate());
        }

        if(shakeDuration > 0.0f) 
        {
            cam.transform.position = originalCamPos + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0.0f;
            cam.transform.position = originalCamPos;
        }
    }

    IEnumerator OpenGate()
    {
        cd.enabled = false;
        locked = false;
        shakeDuration = 0.5f;
        audioSource.PlayOneShot(gateSound);

        while (spriteHolder.localScale.y > openScale)
        {
            spriteHolder.localScale = Vector3.MoveTowards(spriteHolder.localScale, new Vector3(spriteHolder.localScale.x, openScale, spriteHolder.localScale.z), Time.deltaTime * gateSpeed);
            yield return null;
        }

        spriteHolder.localScale = new Vector3(spriteHolder.localScale.x, openScale, spriteHolder.localScale.z);

    }

    IEnumerator CloseGate()
    {
        cd.enabled = true;
        locked = true;
        shakeDuration = 0.5f;
        
        while (spriteHolder.localScale.y < closedScale)
        {
            spriteHolder.localScale = Vector3.MoveTowards(spriteHolder.localScale, new Vector3(spriteHolder.localScale.x, closedScale, spriteHolder.localScale.z), Time.deltaTime * gateSpeed);
            yield return null;
        }

        audioSource.PlayOneShot(gateSound);
        spriteHolder.localScale = new Vector3(spriteHolder.localScale.x, closedScale, spriteHolder.localScale.z);
    }
}
