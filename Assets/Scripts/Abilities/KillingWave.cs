using System.Collections;
using UnityEngine;

public class KillingWave : MonoBehaviour
{
    private float targetScale = 20;
    private float timeToGrow = 5;
    private float scaleModifier = 1;

    private void Start()
    {
        StartCoroutine(ScaleWave(targetScale, timeToGrow));
    }

    IEnumerator ScaleWave(float endValue, float duration)
    {
        float time = 0;
        float startValue = scaleModifier;
        Vector3 startScale = transform.localScale;

        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = new Vector3 (startScale.x * scaleModifier, transform.localScale.y, startScale.z * scaleModifier);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = new Vector3(startScale.x * endValue, transform.localScale.y, startScale.z * endValue);
        scaleModifier = endValue;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.GetComponent<EnemyStateManager>().Hit();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x);
    }
}
