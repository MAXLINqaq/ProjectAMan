using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public int boxMode;//1：普通箱子，2：爆炸箱子，3：悬挂的普通箱子，4：悬挂的爆炸箱子
    public int DropMode;
    public int hitCount;
    public int boxHp;
    public GameObject itme1;
    private float damageRadius;
    void Start()
    {
        hitCount = 0;
        damageRadius = 10;
    }


    void Update()
    {
        switch (boxMode)
        {
            case 1:
                NormalBox();
                break;
            case 2:
                ExplosionBox();
                break;
            case 3:
                ropeNormalBox();
                break;
            case 4:
                ropeExplosionBox();
                break;
            default:
                break;
        }


    }
    private void NormalBox()
    {
        if (hitCount >= boxHp)
        {

            SelectDropMode();
            Destroy(this.gameObject);

        }
    }
    private void ExplosionBox()
    {

        if (hitCount >= boxHp)
        {

            ExplosionDamage(this.transform.position, damageRadius);
            Destroy(this.gameObject);
        }

    }
    private void ropeNormalBox()
    {
        if (hitCount >= boxHp)
        {

            SelectDropMode();
            Destroy(this.gameObject);
        }
    }
    private void ropeExplosionBox()
    {
        if (hitCount >= boxHp)
        {

            ExplosionDamage(this.transform.position, damageRadius);
            Destroy(this.gameObject);
        }
    }
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            hitCollider.SendMessage("ExploreHit", null, SendMessageOptions.DontRequireReceiver);
        }
        GameObject.Find("MainCamera").GetComponent<CameraShake>().SetBigShakeAmount();
    }
    public void SelectDropMode()
    {
        switch (DropMode)
        {
            case 1:
                GameObject newItem = Instantiate(itme1);
                newItem.transform.position = transform.position;
                break;
            default:
                break;
        }

    }
    public void ExploreHit()
    {
        hitCount += 5;
    }
}
