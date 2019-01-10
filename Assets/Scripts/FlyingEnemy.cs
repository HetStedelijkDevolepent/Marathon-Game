using UnityEngine;

public class FlyingEnemy : Enemy {

    private void Update()
    {
        if(Vector3.Distance(transform.position, Player.instance.transform.position) < 15f)
            transform.position += (Player.instance.transform.position - transform.position).normalized * Time.deltaTime;
    }

    

        
    

}
