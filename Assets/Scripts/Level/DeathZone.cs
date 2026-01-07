using UnityEngine;
using UnityEngine.SceneManagement; // pour recharger la scène

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("DeathUIScene");
        }
    }
}
