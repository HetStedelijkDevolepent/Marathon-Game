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

        rb.MovePosition(transform.position + transform.right * Time.deltaTime * 10);
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Destroy(this);
    }
}
