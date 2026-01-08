using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarHitbox : MonoBehaviour
{
    public UnityEvent PlayerWithoutKeyInHitBox;
    public UnityEvent PlayerWithKeyInHitBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if(playerController.hasKey)
            {
                PlayerWithKeyInHitBox?.Invoke();
            } else
            {
                PlayerWithoutKeyInHitBox?.Invoke();
            }
        }
    }
}
