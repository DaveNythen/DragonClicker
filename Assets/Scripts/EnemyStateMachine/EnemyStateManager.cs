using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;

    public EnemyIdleState IdleState = new EnemyIdleState();
    public EnemyMovingState MovingState = new EnemyMovingState();
    public EnemyDeadState DeadState = new EnemyDeadState();


    bool isSpawned;
    bool isAlive;
    public float speed;
    [SerializeField] SphereCollider col;

    public bool IsSpawned { get { return isSpawned; } set { isSpawned = value; } }
    public bool IsAlive { get { return isAlive; } set { isAlive = value; } }

    private void Start()
    {
        //starting state for the state machine
        currentState = IdleState;
        currentState.EnterState(this);
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
    }

    public void Reset()
    {
        isAlive = true;
        col.enabled = true;
    }
}
