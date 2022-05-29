using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.MsgFramework.Character;
using UnityEngine;

namespace Assets.Scripts.AM.Character
{
    public class Enemy : CharacterBase
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
            screenCamera = GameObject.Find("Camera/MainCamera").GetComponent<Camera>();
        }
        #endregion
        
        #region 方法
        public float L;
        public float R;
        public LayerMask layerMask;
        public float r = 6;
        public float speed = 1;
        Camera screenCamera;
        Transform player;
        private void Update() {
            if(player == null){
                Collider2D collider = Physics2D.OverlapCircle(transform.position, r, layerMask);
                if(collider!=null){
                    player = collider.transform;
                }
            }
            else{
                MoveTo(player.position);
            }
        }
        void MoveTo(Vector3 p){
            float toX = p.x > R? Mathf.Min(R, p.x) : Mathf.Max(L, p.x);
            transform.position += (transform.position.x > toX ? -1 : 1) * speed * Time.deltaTime * Vector3.right;
            if(toX < L || toX > R){
                ShotAt(p);
            }
        }
        public float cd = 3;
        float timer;
        public GameObject bulletPrefab;
        void ShotAt(Vector3 p){
            timer += Time.deltaTime;
            if(timer >= cd){
                //TODO shoot
                timer = 0;
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