using UnityEngine;

[RequireComponent(typeof(Particles))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerListeners : MonoBehaviour
{
    private bool wasGrounded;
    private Particles m_Particles;
    private PlayerMovement m_PlayerMovement;

    private void Awake()
    {
        m_Particles = GetComponent<Particles>();
        m_PlayerMovement = GetComponent<PlayerMovement>();

        if (m_PlayerMovement != null)
            wasGrounded = m_PlayerMovement.IsGrounded;
    }

    private void OnEnable()
    {
        if (m_PlayerMovement == null) return;
        m_PlayerMovement.OnGroundedChange.AddListener(OnGroundedChanged);
    }

    private void OnDisable()
    {
        if (m_PlayerMovement == null) return;
        m_PlayerMovement.OnGroundedChange.RemoveListener(OnGroundedChanged);
    }

    private void OnGroundedChanged(bool isGrounded)
    {
        if (!wasGrounded && isGrounded)
        {
            m_Particles.PlayGroundParticles();
        }

        wasGrounded = isGrounded;
    }
}