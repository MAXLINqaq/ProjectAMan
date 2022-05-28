using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class State_Resource : MonoBehaviour
{

    public int Item1;
    public Text text;
    public RawImage RedHp;
    public float initialWidth;

    public float Hp;//血量
    public float DamageSpeed;
    public float explosionDamage;
    public float Mp;//精神量
    public float MaxHp;
    // Start is called before the first frame update
    void Start()
    {
        MaxHp = Hp;
        initialWidth = RedHp.rectTransform.sizeDelta.x;
        Item1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Hp -= Time.deltaTime * DamageSpeed;
        text.text = Item1.ToString();
        if (Hp > 0)
        {
            RedHp.rectTransform.sizeDelta = new Vector2((Hp / MaxHp) * initialWidth, RedHp.rectTransform.sizeDelta.y);
        }


    }
    public void ExploreHit()
    {
        Hp = Hp - explosionDamage;
    }
}
