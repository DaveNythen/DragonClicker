using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState _currentState;

    public EnemyIdleState IdleState = new EnemyIdleState();
    public EnemyMovingState MovingState = new EnemyMovingState();
    public EnemyDeadState DeadState = new EnemyDeadState();

    public NavMeshAgent agent;
    bool _isSpawned;
    bool _isAlive;
    public float speed;
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

    public void Reset()
    {
        SwitchState(IdleState);
        _isAlive = true;
        _col.enabled = true;
    }
}
