using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private void Start()
    {
        StartCoroutine(Delete());
    }

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * 10;
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
