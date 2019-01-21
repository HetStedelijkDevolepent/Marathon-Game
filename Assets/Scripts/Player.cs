using UnityEngine;

public class Player : MonoBehaviour {
    
    [SerializeField]
    int maxHealth = 11;

    [SerializeField]
    Sprite[] healthbarSprites;

    [SerializeField]
    SpriteRenderer healthBar;

    

    int health;


    public static Player instance;

    private void Awake()
    {
        instance = this;
        health = maxHealth;
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 0.3f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage();
            TakeDamage();
        }

        if (collision.collider.CompareTag("EnemyBullet"))
        {
            Destroy(collision.collider.gameObject);
            TakeDamage();
        }

        if (collision.collider.CompareTag("Shockwave"))
        {
            Destroy(collision.collider.gameObject);
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        health -= 1;

        healthBar.sprite = healthbarSprites[health];

        if (health <= 1)
        {
            Destroy(gameObject);
        }
    }


    
    

}
