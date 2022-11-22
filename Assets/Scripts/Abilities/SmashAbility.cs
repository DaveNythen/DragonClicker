using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/SmashAbility")]
public class SmashAbility : Ability
{
    public override void Activate(InputInfo inputInfo)
    {
        //base.Activate();
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(inputInfo.startPos);
        Physics.Raycast(ray.origin, ray.direction, out hit, 11f);

        if (hit.collider == null) return;

        if (hit.collider.gameObject.CompareTag("Enemy"))
        {
            EnemyStats enemy = hit.transform.GetComponent<EnemyStats>();

            if (enemy != null)
                enemy.Hit();

            SoundManager.PlaySound3D(SoundManager.soundList.smash, hit.point);
        }
        else
        {
            SoundManager.PlaySound3D(SoundManager.soundList.smashFail, hit.point);
        }
    }
}