using UnityEngine;

public class FlyingEnemy : MonoBehaviour {

    private void Update()
    {
        transform.position += (Player.instance.transform.position - transform.position).normalized * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
    }

        
    

}
