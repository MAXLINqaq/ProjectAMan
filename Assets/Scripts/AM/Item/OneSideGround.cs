using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.AM.Item
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class OneSideGround : MonoBehaviour
    {
        Transform player;
        Transform self;
        Rigidbody2D rig;
        BoxCollider2D col;

        private void Awake()
        {
            self = transform;
            rig = GetComponent<Rigidbody2D>();
            col = GetComponent<BoxCollider2D>();

            rig.bodyType = RigidbodyType2D.Static;
            col.isTrigger = false;
        }

        private void FixedUpdate()
        {
            if (player == null){
                player = GameObject.Find("Player").transform;
            }
            if (player != null){
                col.isTrigger = (player.position.y < self.position.y + .0f);
            }
        }
    }
}