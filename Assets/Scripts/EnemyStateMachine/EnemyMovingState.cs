using UnityEngine;

public class EnemyMovingState : EnemyBaseState
{
    Transform tower;

    public override void EnterState(EnemyStateManager enemy)
    {
        tower = GameObject.FindGameObjectWithTag("Tower").transform;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.transform.LookAt(tower);
        enemy.transform.position += enemy.transform.forward * Time.deltaTime * enemy.speed;

        if (!enemy.IsAlive)
            enemy.SwitchState(enemy.DeadState);
    }
}
