using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControllr : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<State_Resource>().Item1++;
            coll.gameObject.GetComponent<State_Resource>().Hp=coll.gameObject.GetComponent<State_Resource>().MaxHp;
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag == "Ground")
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        }

    }

    
}
