using UnityEngine;
using System.Collections;

public abstract class BasePoolElement : MonoBehaviour
{
    protected float _duration;

    protected void PlayElementLogic()
    {
        StartCoroutine(LifeRoutine());
    }

    protected void DiactivateElement()
    {
        StopCoroutine(LifeRoutine());
    }

    protected IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(_duration);
        Deactivate();
    }

    protected void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
