using UnityEngine;

public class FlyingShootingEnemy : Enemy
{
    [SerializeField]
    int minrange;

    [SerializeField]
    int maxrange;


    private void Update()
    {
        if (Vector3.Distance(transform.position, Player.instance.transform.position) < maxrange && Vector3.Distance(transform.position, Player.instance.transform.position) > minrange)
            transform.position += (Player.instance.transform.position - transform.position).normalized * Time.deltaTime;
    }
}
