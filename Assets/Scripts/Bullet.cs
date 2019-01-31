using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Delete());
    }

    private void Update()
    {

        rb.velocity = (transform.right* 10);
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Destroy(this);
    }
}
