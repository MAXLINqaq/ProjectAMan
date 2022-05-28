using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float coolTime;

    private float time;
    private List<GameObject> list = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(Input.GetButton("Fire1")&& time > coolTime){
            Fire();
            time = 0;
        }
    }
    private void Fire()
    {
        Vector3 obj = Camera.main.WorldToScreenPoint(firePoint.transform.position);
        Vector2 direction = Input.mousePosition - obj;
        firePoint.LookAt(direction);
        firePoint.Rotate(0, -90, 0);
        if (this.transform.localScale.x > 0 && direction.x > 0)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
        else if (this.transform.localScale.x <= 0 && direction.x < 0)
        {

            firePoint.Rotate(0, 0, 180);
            Instantiate(bullet, firePoint.position, firePoint.rotation);

        }
    }
}
