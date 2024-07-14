using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private WeaponProfile launcherWeaponProfile;
    [SerializeField] private WeaponProfile blasterWeaponProfile;
    [SerializeField] private Transform[] launcherPositions;
    [SerializeField] private Transform[] blasterPositions;

    private enum WeaponType { Launcher, Blaster }
    private WeaponType selectedWeapon = WeaponType.Launcher;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = WeaponType.Launcher;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = WeaponType.Blaster;
        }



        if (selectedWeapon == WeaponType.Launcher)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }
        else if (selectedWeapon == WeaponType.Blaster)
        {
            if (Input.GetMouseButton(0))
            {
                Fire();
            }
        }

    }

    private void Fire()
    {
        if (selectedWeapon == WeaponType.Launcher)
        {
            FireWeapon(launcherWeaponProfile, launcherPositions);
        }
        else if (selectedWeapon == WeaponType.Blaster)
        {
            FireWeapon(blasterWeaponProfile, blasterPositions);
        }
    }

    private void FireWeapon(WeaponProfile weaponProfile, Transform[] firePositions)
    {

            foreach (var firePosition in firePositions)
            {
                var bullet = Instantiate(weaponProfile.bulletObject, firePosition.position, firePosition.rotation);
                bullet.transform.SetParent(null);
                bullet.SetActive(true);
                bullet.GetComponent<BulletHandlers>().LaunchMissile(firePosition);
            }


       
    }
}
