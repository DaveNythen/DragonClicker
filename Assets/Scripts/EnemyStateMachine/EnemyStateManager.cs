using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;

    public EnemyIdleState IdleState = new EnemyIdleState();
    public EnemyMovingState MovingState = new EnemyMovingState();
    public EnemyDeadState DeadState = new EnemyDeadState();

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
}
