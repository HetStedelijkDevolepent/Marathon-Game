using UnityEngine;

public class Jaspocalypse : Enemy
{
    [SerializeField]
    float minrange = 3f;

    [SerializeField]
    float maxrange = 7f;

    Animator anim;

    private new void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Player.instance.transform.position) > minrange)
        {

            Vector3 direction = (Player.instance.transform.position - transform.position).normalized;
            transform.position += direction * Time.deltaTime * speed;
            transform.position = new Vector2(transform.position.x, .5f);
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);

        }

        if (Vector3.Distance(transform.position, Player.instance.transform.position) > maxrange)
        {
            Player.instance.GetComponent<Rigidbody2D>().AddForce((transform.position - Player.instance.transform.position) * 5f);
        }


    }
}
