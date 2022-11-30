using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ClearScreen")]
public class ClearScreenAbility : Ability
{
    [SerializeField] KillingWave _wave;

    public override void Activate(InputInfo inputInfo)
    {
        //base.Activate(touch);
        Transform tower = GameObject.FindGameObjectWithTag("Tower").transform;

        Vector3 pos = new Vector3(tower.position.x, _wave.transform.localScale.y / 2, tower.position.z);

        //Intantiate wall
        GameObject wallIns = Instantiate(_wave.gameObject, pos, Quaternion.identity);
        Destroy(wallIns, activeTime);
    }

}
