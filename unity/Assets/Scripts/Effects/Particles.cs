using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Particles : MonoBehaviour
{
    [SerializeField]
    ParticleSystem groundParticlesPrefab;

    public void PlayGroundParticles()
    {
        ParticleSystem particleSys = Instantiate(
            groundParticlesPrefab,
            transform.position,
            Quaternion.identity
        );

        particleSys.Play();

        Destroy(particleSys.gameObject,
            particleSys.main.duration);
    }
}
