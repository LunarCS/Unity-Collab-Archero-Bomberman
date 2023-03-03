using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] ParticleSystem[] particles = new ParticleSystem[3];

    public void ParticleChoice(int particleIndex, float lifeTime)
    {
        particles[particleIndex].gameObject.SetActive(true);
        Destroy(gameObject, lifeTime);
    }


}
