using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    [SerializeField]
    Weapon currentWeapon;

    int currentAmmo;

    [SerializeField]
    GameObject bulletPrefab;

    bool isReloading = false;


    private void Awake()
    {
        currentAmmo = currentWeapon.bullets;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if(currentAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;


            var dir = target - bullet.transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            currentAmmo--;

            if (currentAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }
        }
    }

    IEnumerator Reload()
    {
        if (isReloading)
            yield break;

        isReloading = true;
        yield return new WaitForSeconds(currentWeapon.reloadTime);
        currentAmmo = currentWeapon.bullets;

        isReloading = false;
    }

}
