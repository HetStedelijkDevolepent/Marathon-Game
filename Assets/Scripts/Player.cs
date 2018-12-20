using UnityEngine;

public class Player : MonoBehaviour {


    public void Update()
    {
        float xMov = Input.GetAxis("Horizontal");
        float yMov = Input.GetAxis("Vertical");

        transform.position += new Vector3(xMov, yMov) * Time.deltaTime;

    }

}
