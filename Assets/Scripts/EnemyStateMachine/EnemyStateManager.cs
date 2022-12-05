using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState _currentState;

    public EnemyIdleState IdleState = new EnemyIdleState();
    public EnemyMovingState MovingState = new EnemyMovingState();
    public EnemyDeadState DeadState = new EnemyDeadState();

    public float speed;
    public NavMeshAgent agent;
    public Animator animator;
    bool _isSpawned;
    bool _isAlive;
    [SerializeField] SphereCollider _col;

    public bool IsSpawned { get { return _isSpawned; } set { _isSpawned = value; } }
    public bool IsAlive { get { return _isAlive; } set { _isAlive = value; } }

    private void Start()
    {
        //starting state for the state machine
        SwitchState(IdleState);
    }

    private void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state)
    {
        _currentState = state;
        state.EnterState(this);
    }

    public void Hit()
    {
        _isAlive = false;
        _col.enabled = false;
        _isSpawned = false;
    }

    public void Spawn()
    {
        gameObject.SetActive(true);

        Reset();
                
        SwitchState(IdleState);

        StartCoroutine(WaitOnIdle());
    }

    private void Reset()
    {
        _isAlive = true;
        _col.enabled = true;
        animator.SetBool("isAlive", true);
        animator.SetBool("isMoving", false);
    }

    IEnumerator WaitOnIdle()
    {
        yield return new WaitForSeconds(0.2f);
        _isSpawned = true;
    }
}
