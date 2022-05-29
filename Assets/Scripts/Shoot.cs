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
    public enum FireMode{
        Single = 0,
        Double = 1,
        Multiple = 3
    }
    public FireMode fireMode = FireMode.Single;
    bool isTrig;
    int bulletCap;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(Input.GetButtonDown("Fire1")){
            isTrig = true;
            switch(fireMode){
                case FireMode.Single:{
                    bulletCap = 1;
                    break;
                }
                case FireMode.Double:{
                    bulletCap = 2;
                    break;
                }
                case FireMode.Multiple:{
                    bulletCap = int.MaxValue;
                    break;
                }
            }
        }
        else if(Input.GetButtonUp("Fire1")){
            isTrig = false;
        }
        if(isTrig && bulletCap > 0 && time > coolTime){
            Fire();
            time = 0;
            bulletCap --;
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
