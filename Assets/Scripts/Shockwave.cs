using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{

    bool right = true;


    private void Start()
    {
        StartCoroutine(DestroyObject());
    }

    private void Update()
    {

        if (right)
            transform.position += Vector3.right * Time.deltaTime * 8f;
        else
            transform.position += Vector3.left * Time.deltaTime * 8f;
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    public void SetDirection(bool _right)
    {
        right = _right;

        if (right)
        {
            transform.position += Vector3.right* 1.6f;
        }
        else
        {
            transform.position += Vector3.left * 1.6f;
        }
    }
}
