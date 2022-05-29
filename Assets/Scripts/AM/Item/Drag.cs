using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.MsgFramework.Item;
using UnityEngine;

namespace Assets.Scripts.AM.Item
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Drag : ItemBase
    {
        #region 消息绑定
        private void Awake() {
            Bind(
                
            );
        }
        public override void Execute(int eventCode, object arg) {
            switch(eventCode){
                default:break;
            }
        }
        #endregion
        
        #region 子物体
        private void Start() {//初始化
            
        }
        #endregion
        
        #region 方法
        public void Init(){
            isCollecting = false;
        }
        float r = 5;
        bool isCollecting;
        Transform player;
        private void Update() {
            if(isCollecting){
                return;
            }
            player = GameObject.Find("Player").transform;
            Vector3 dir = (player.transform.position + Vector3.up * 2 - transform.position);
            if(dir.magnitude > r){
                player = null;
            }
            else{
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, dir.normalized, dir.magnitude);
                foreach(var hit in hits){
                    if(LayerMask.LayerToName(hit.collider.gameObject.layer) == "Ground"){
                        player = null;
                        break;
                    }
                }
            }

            if(player != null && !isCollecting){
                isCollecting = true;
                StartCoroutine(AnimateCollect());
            }
        }
        IEnumerator AnimateCollect(){
            float percent = 0;
            float duration = 1.2f;
            while(percent < 1){
                transform.position = Vector3.Lerp(
                    transform.position, player.position + Vector3.up * 2, percent
                );
                percent += Time.deltaTime / duration;
                yield return null;
            }

            Destroy(gameObject);
        }
        private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
                Destroy(gameObject);
            }
        }
        #endregion
        
        #region Test
        #if UNITY_EDITOR
        [ContextMenu("Test/Test")]
        void TEST_Test(){
            
        }
        #endif
        #endregion
    }
}