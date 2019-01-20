using UnityEngine;

public class FlyingEnemy : Enemy {

    [SerializeField]
    int maxrange;

    
    

    private void Update()
    {
        if (Vector3.Distance(transform.position, Player.instance.transform.position) < maxrange)
            transform.position += (Player.instance.transform.position - transform.position).normalized * Time.deltaTime * speed;
    }






}
