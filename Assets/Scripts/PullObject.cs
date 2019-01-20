using UnityEngine;
using System.Collections;

public class PullObject : MonoBehaviour
{



    private void Start()
    {
        StartCoroutine(DestroyObject());
    }

    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * 10f;
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
