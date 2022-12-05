using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/DragAbility")]
public class DragAbility : Ability
{
    [SerializeField] FireWall _wall;
    public float wallLongitud;

    public override void Activate(InputInfo inputInfo)
    {
        //base.Activate(touch);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(inputInfo.middlePoint);
        Physics.Raycast(ray.origin, ray.direction, out hit, 25f);

        if (hit.collider != null && hit.collider.gameObject.CompareTag("Ground"))
        {
            Vector3 pos = new Vector3(hit.point.x, _wall.transform.localScale.y / 2, hit.point.z);
            _wall.SetWallLong(wallLongitud);

            //Intantiate wall
            GameObject wallIns = Instantiate(_wall.gameObject, pos, Quaternion.Euler(0, inputInfo.gestureAngle, 0));
            Destroy(wallIns, activeTime);
        }
    }
}
