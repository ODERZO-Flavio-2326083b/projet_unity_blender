using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    public AudioSource audioSource;

    [SerializeField] 
    private float rotationSpeed = 180f;
    [SerializeField] 
    private Transform mesh;

    [SerializeField]
    AudioClip pickUpSound;

    void Start()
    {
        audioSource = gameObject.GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        mesh.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.addScore(10);

            audioSource.PlayOneShot(pickUpSound, 0.5f);
            Destroy(mesh.gameObject);
            
        }
    }
}
