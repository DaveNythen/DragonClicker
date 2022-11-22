using UnityEngine;

public class EnemyDespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyPool.ReturnToPoolPos(col.transform);
        }
    }
}
