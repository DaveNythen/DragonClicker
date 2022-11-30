using UnityEngine;

public class EnemyMovingState : EnemyBaseState
{
    Transform _tower;

    public override void EnterState(EnemyStateManager enemy)
    {
        _tower = GameObject.FindGameObjectWithTag("Tower").transform;
        //enemy.transform.LookAt(tower);
        enemy.agent.speed = enemy.speed;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.agent.SetDestination(_tower.transform.position);
        //enemy.transform.position += enemy.transform.forward * Time.deltaTime * enemy.speed;

        if (!enemy.IsAlive)
            enemy.SwitchState(enemy.DeadState);
    }
}
