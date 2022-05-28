using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hitCount;
    // Start is called before the first frame update
    void Start()
    {
        hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ExploreHit()
    {
        hitCount += 5;
    }
}
