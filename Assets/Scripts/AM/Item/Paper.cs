using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.AM.UI;
using Assets.Scripts.MsgFramework;
using Assets.Scripts.MsgFramework.Item;
using UnityEngine;

namespace Assets.Scripts.AM.Item
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Paper : ItemBase {
        public int paperId = 0;
        private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
                Dispatch(AreaCode.UI, UIEventCode.SHOW_PAPER_CONTENT, paperId);

                Destroy(gameObject);
            }
        }
    }
}