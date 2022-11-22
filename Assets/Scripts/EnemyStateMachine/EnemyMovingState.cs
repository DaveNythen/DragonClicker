using UnityEngine;

public class EnemyMovingState : EnemyBaseState
{
    Transform tower;

    EnemyStats stats;

    public override void EnterState(EnemyStateManager enemy)
    {
        tower = GameObject.FindGameObjectWithTag("Tower").transform;
        stats = enemy.GetComponent<EnemyStats>();
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.transform.LookAt(tower);
        enemy.transform.position += enemy.transform.forward * Time.deltaTime * stats.speed;

        if (!stats.isAlive)
            enemy.SwitchState(enemy.DeadState);
    }
}
