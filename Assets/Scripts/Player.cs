using UnityEngine;

public class Player : MonoBehaviour {
    
    [SerializeField]
    int maxHealth = 11;

    [SerializeField]
    Sprite[] healthbarSprites;

    [SerializeField]
    SpriteRenderer healthBar;

    

    int health;

    float slomoSeconds;
    [SerializeField]
    float maxSlomoSeconds = 1f;

    bool slomoRanOut = false;


    public static Player instance;

    private void Awake()
    {
        slomoSeconds = maxSlomoSeconds;
        instance = this;
        health = maxHealth;
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            slomoRanOut = false;
        }
        if (Input.GetKey(KeyCode.LeftShift) && slomoSeconds >= 0 && !slomoRanOut)
        {
            Time.timeScale = 0.3f;
            slomoSeconds -= Time.unscaledDeltaTime;
            if(slomoSeconds <= 0)
            {
                slomoRanOut = true;
            }
        }
        else
        {
            Time.timeScale = 1f;
            slomoSeconds += Time.deltaTime;
            slomoSeconds = Mathf.Clamp(slomoSeconds, 0, maxSlomoSeconds);
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
