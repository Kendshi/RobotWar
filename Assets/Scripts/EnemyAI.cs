using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _target;
    private Animator _animator;

    [Inject]
    private void Construct(MovementController movementController)
    {
        _target = movementController.GetComponent<Transform>();
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = GetPositionRoundTarget();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (HasReached())
        {
            _agent.SetDestination(GetPositionRoundTarget());
        }
    }

    private bool HasReached()
    {
        if (_agent.remainingDistance < 2f)
        {
            _animator.SetBool("IsMoveing", false);
            return true;
        }
        else
        {
            _animator.SetBool("IsMoveing", true);
            return false;
        }
    }

    private Vector3 GetPositionRoundTarget()
    {
        Vector3 randomOffset = new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f));
        return _target.position + randomOffset;
    }

}
