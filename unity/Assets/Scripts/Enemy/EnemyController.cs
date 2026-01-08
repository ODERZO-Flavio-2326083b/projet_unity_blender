using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 3f;

    CharacterController m_characterController;
    
    PlayerController player;

    void Awake()
    {
        m_characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!target) return;

        Vector3 direction = (target.position - transform.position);

        if (direction.magnitude > 60 || Mathf.Abs(direction.y) > 10) return;

        direction.y = 0;
        direction.Normalize();

        m_characterController.Move(direction * speed * Time.deltaTime);

        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerController>();
            if (player.hasStar) Destroy(gameObject);
            else player.death();
        }
    }
}