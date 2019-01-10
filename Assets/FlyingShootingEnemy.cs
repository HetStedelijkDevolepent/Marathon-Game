using UnityEngine;
using System.Collections;

public class FlyingShootingEnemy : Enemy
{
    [SerializeField]
    int minrange;

    [SerializeField]
    int maxrange;

    [SerializeField]
    float shootDelay = 1f;

    [SerializeField]
    GameObject bulletPrefab;


    private void Start()
    {
        StartCoroutine(FireBullets());
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Player.instance.transform.position) < maxrange && Vector3.Distance(transform.position, Player.instance.transform.position) > minrange)
            transform.position += (Player.instance.transform.position - transform.position).normalized * Time.deltaTime;
    }

    IEnumerator FireBullets()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootDelay);
            if (Vector3.Distance(transform.position, Player.instance.transform.position) > maxrange)
            {
                continue;
            }

            Vector3 target = Player.instance.transform.position;

            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;


            var dir = target - bullet.transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }
}
