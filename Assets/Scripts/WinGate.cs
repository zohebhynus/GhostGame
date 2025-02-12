using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGate : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GlobalValues.playerIsAlive = true;
            SceneManager.LoadSceneAsync(2);
        }
    }
}
