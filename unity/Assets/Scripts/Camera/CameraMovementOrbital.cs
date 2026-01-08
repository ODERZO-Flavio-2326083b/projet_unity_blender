using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovementOrbital : MonoBehaviour
{
    [SerializeField]
    float m_SpeedRotation;
    public float SpeedRotation => Mathf.Deg2Rad * m_SpeedRotation * Time.deltaTime;

    Vector3 m_CurrentRotation;

    [SerializeField]
    Vector2 m_RotationXLimits;

    [SerializeField] Transform target;
    [SerializeField] float smoothFollowValue = 10f;

    private void LateUpdate()
    {
        if (!target) return;
        transform.position = Vector3.Lerp(
            transform.position, target.position, smoothFollowValue * Time.deltaTime);
    }

    private void Start()
    {
        // init rotation
        m_CurrentRotation = transform.rotation.eulerAngles;
    }

    // rotate when input received
    public void Rotate(InputAction.CallbackContext _context)
    {
        // add rotation
        m_CurrentRotation.y += _context.ReadValue<Vector2>().x * SpeedRotation;
        m_CurrentRotation.x += -_context.ReadValue<Vector2>().y * SpeedRotation;

        m_CurrentRotation.x = Mathf.Clamp(m_CurrentRotation.x, m_RotationXLimits.x, m_RotationXLimits.y);

        // apply rotation
        transform.rotation = Quaternion.Euler(m_CurrentRotation.x, m_CurrentRotation.y, m_CurrentRotation.z);
    }
}