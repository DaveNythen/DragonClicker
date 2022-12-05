using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/HoldAbility")]
public class HoldAbility : Ability
{
    [SerializeField] Mine _mine;
    //public int maxNumberOfMines;

    //int currentMines;

    public override void Activate(InputInfo inputInfo)
    {
        //base.Activate();
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(inputInfo.startPos);
        Physics.Raycast(ray.origin, ray.direction, out hit, 25f);

        if (hit.collider != null && hit.collider.gameObject.CompareTag("Ground"))
        {
            //if (currentMines > maxNumberOfMines) return;

            Instantiate(_mine.gameObject, hit.point, Quaternion.identity);
            //currentMines++;
            //Mine.OnDestroy += Mine_OnDestroy;

        }
    }

    /*private void Mine_OnDestroy()
    {
        currentMines--;
    }*/
}
