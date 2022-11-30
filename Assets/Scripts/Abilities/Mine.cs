using UnityEngine;

public class Mine : MonoBehaviour
{
    public delegate void DestroyEvent();
    public static event DestroyEvent OnDestroy;

    [SerializeField] ParticleSystem _explosionParticle;
    [SerializeField] int _explosionRadius;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            //Boom
            ExplosionDamage(transform.position, _explosionRadius);
        }
    }

    void ExplosionDamage (Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            EnemyStateManager enemy = hitCollider.GetComponent<EnemyStateManager>();

            if (enemy != null)
                enemy.Hit();
        }

        if(OnDestroy != null) OnDestroy();

        ExplosionVisuals();
    }

    void ExplosionVisuals()
    {
        Vector3 instPos = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
        GameObject explosion = Instantiate(_explosionParticle.gameObject, instPos, Quaternion.identity);

        gameObject.SetActive(false);

        Destroy(explosion, 2f);
        Destroy(gameObject, 2f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere (transform.position, 2);
    }
}
