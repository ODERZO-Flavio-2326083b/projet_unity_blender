using UnityEngine;
using UnityEngine.SceneManagement; // pour recharger la scène

public class DeathZone : MonoBehaviour
{
    PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerController>();
            player.death();
        }
    }
}
