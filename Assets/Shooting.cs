using UnityEngine;

public class Shooting : MonoBehaviour {

    [SerializeField]
    GameObject bulletPrefab;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position + target.normalized;


            var dir = target - bullet.transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
