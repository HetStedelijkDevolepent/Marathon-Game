using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        float xMov = Input.GetAxis("Horizontal");
        float yMov = Input.GetAxis("Vertical");

        if(yMov > 0.2)
        {
            rb.AddForce(new Vector2(0, 100f));
        }

        transform.position += new Vector3(xMov, 0) * Time.deltaTime;

    }

}
