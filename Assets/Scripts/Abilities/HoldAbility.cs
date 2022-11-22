using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/HoldAbility")]
public class HoldAbility : Ability
{
    [SerializeField] Mine mine;
    public int maxNumberOfMines;

    //int currentMines;

    public override void Activate(InputInfo inputInfo)
    {
        //base.Activate();
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(inputInfo.startPos);
        Physics.Raycast(ray.origin, ray.direction, out hit, 11f);

        if (hit.collider != null && hit.collider.gameObject.CompareTag("Ground"))
        {
            //if (currentMines > maxNumberOfMines) return;

            Instantiate(mine.gameObject, hit.point, Quaternion.identity);
            //currentMines++;
            //Mine.OnDestroy += Mine_OnDestroy;

        }
    }

    /*private void Mine_OnDestroy()
    {
        currentMines--;
    }*/
}
