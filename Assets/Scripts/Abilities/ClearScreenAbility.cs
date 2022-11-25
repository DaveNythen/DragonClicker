using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ClearScreen")]
public class ClearScreenAbility : Ability
{
    [SerializeField] KillingWave wave;

    public override void Activate(InputInfo inputInfo)
    {
        //base.Activate(touch);
        Transform tower = GameObject.FindGameObjectWithTag("Tower").transform;

        Vector3 pos = new Vector3(tower.position.x, wave.transform.localScale.y / 2, tower.position.z);

        //Intantiate wall
        GameObject wallIns = Instantiate(wave.gameObject, pos, Quaternion.identity);
        Destroy(wallIns, activeTime);
    }

}
