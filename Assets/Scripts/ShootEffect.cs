using UnityEngine;
using System.Collections;

public class ShootEffect : BasePoolElement
{
    private ParticleSystem _shootEffect;

    private void OnEnable()
    {
        if (_shootEffect != null)
        {
            _shootEffect.Play(true);
        }
        else
        {
            _shootEffect = GetComponent<ParticleSystem>();
            _shootEffect.Play(true);
            _duration = _shootEffect.main.duration;
        }

        StartCoroutine(LifeRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(LifeRoutine());
    }
}
