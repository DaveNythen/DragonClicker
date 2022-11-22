using UnityEngine;

public class FireWall : MonoBehaviour
{

    public void SetWallLong(float wallLongitud)
    {
        transform.localScale = new Vector3(wallLongitud, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.GetComponent<EnemyStats>().Hit();
        }
    }
}
