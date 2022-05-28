using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float force;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        force = 40;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * force;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject.Find("MainCamera").GetComponent<CameraShake>().SetSmallShakeAmount();
        if (coll.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            coll.gameObject.GetComponent<EnemyController>().hitCount++;
        }
        if (coll.gameObject.tag == "Box")
        {
            Destroy(this.gameObject);
            coll.attachedRigidbody.AddForce(transform.right * 600);
            coll.gameObject.GetComponent<BoxController>().hitCount++;
        }
        if (coll.gameObject.tag == "Rope")
        {
            coll.attachedRigidbody.AddForce(transform.right * 600);
            Destroy(coll.transform.parent.gameObject, 5);
            Destroy(coll.gameObject);
        }

    }
}