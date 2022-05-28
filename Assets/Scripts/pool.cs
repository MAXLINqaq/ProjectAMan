using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool : MonoBehaviour
{   // 尚未实现
    public List<GameObject> list = new List<GameObject>();
    //游戏预制体
    public GameObject Prefab;
    //对象池中的最大个数
    public int MaxCount = 50;

    //对象放入对象池
    public void Push(GameObject pre)
    {
        //如果池子还能装，就往里面加，满了就不往里面加
        if (list.Count < MaxCount)
        {
            list.Add(pre);
        }
        else
        {
            Destroy(pre);
        }
    }

    //从对象池中取出对象(返回值就要标记为GameObject)
    public GameObject Pop()
    {
        if (list.Count > 0)//判断列表不为空
        {
            GameObject pre = list[0];//如果有的话，就把第一项取出来
            list.RemoveAt(0);//在list中把第一项删除
            return pre;
        }

        return Instantiate(Prefab);//没有的话就直接创建一个新的预制体
    }

    //删除对象池
    public void Clear()
    {
        list.Clear();
    }

}
