using UnityEngine;

public class Jaspocalypse : Enemy
{
    [SerializeField]
    float minrange = 3f;

    [SerializeField]
    float maxrange = 7f;

    [SerializeField]
    GameObject pullObject;

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

            PullPlayer();
        }


    }

    private void PullPlayer()
    {
        StartCoroutine(Player.instance.GetComponent<PlayerPlatformerController>().GetPulled((transform.position - Player.instance.transform.position)));
        Instantiate(pullObject, transform).transform.position += Vector3.right * 5 + Vector3.down;
    }
}
