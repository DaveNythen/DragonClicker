using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;

    public EnemyIdleState IdleState = new EnemyIdleState();
    public EnemyMovingState MovingState = new EnemyMovingState();
    public EnemyDeadState DeadState = new EnemyDeadState();

    public UnityEngine.AI.NavMeshAgent agent;
    bool isSpawned;
    bool isAlive;
    public float speed;
    [SerializeField] SphereCollider col;

    public bool IsSpawned { get { return isSpawned; } set { isSpawned = value; } }
    public bool IsAlive { get { return isAlive; } set { isAlive = value; } }

    private void Start()
    {
        //starting state for the state machine
        SwitchState(IdleState);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void Hit()
    {
        isAlive = false;
        col.enabled = false;
        isSpawned = false;
    }

    public void Reset()
    {
        SwitchState(IdleState);
        isAlive = true;
        col.enabled = true;
    }
}
