using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    public AudioSource audioSource;

    [SerializeField] 
    private float rotationSpeed = 100f;
    [SerializeField] 
    private Transform mesh;

    [SerializeField]
    AudioClip pickUpSound;

    PlayerController player;

    void Start()
    {
        audioSource = gameObject.GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (mesh) 
            mesh.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (mesh != null)
            {
                player = other.GetComponent<PlayerController>();
                player.getKey();

                audioSource.PlayOneShot(pickUpSound, 0.5f);
                Destroy(mesh.gameObject);
                Destroy(gameObject, pickUpSound.length);
            }
        }
    }
}
