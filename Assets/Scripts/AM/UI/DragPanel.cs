using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts.AM.UI
{
    public class DragPanel : PanelBase, IPointerDownHandler, IPointerUpHandler
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
        Image Img_Drag;
        List<float> flagHeights = new List<float>(){1f/3,2f/3,1f};
        private void Start() {//初始化
            Img_Drag = transform.Find("Img_OutLine/Img_Drag").GetComponent<Image>();
            Img_Drag.transform.localScale = Vector3.right;

            Img_Drag.color = Color.green;
        }
        #endregion
        
        #region 方法
        //float des = .02f;
        float inc = .006f;
        int flagInd;
        bool isEnter;
        bool isDes;
        private void Update() {
            if(flagInd >= flagHeights.Count){
                if(!isEnter)
                    Hide();
                return;
            }
            if(isEnter && !isDes){
                if(Img_Drag.transform.localScale.y < flagHeights[flagInd]){
                    Img_Drag.transform.localScale += Vector3.up * inc;
                }
                else{
                    flagInd ++;
                    isDes = true;
                    Img_Drag.color = Color.red;
                }
            }
            else{
                if(Img_Drag.transform.localScale.y > 0){
                    Img_Drag.transform.localScale -= Vector3.up * inc;
                }
                else if(!isEnter){
                    Img_Drag.transform.localScale = Vector3.right;
                    Img_Drag.color = Color.green;
                    isDes = false;
                }
            }
        }
        public void OnPointerDown(PointerEventData eventData) {
            isEnter = true;
        }
        public void OnPointerUp(PointerEventData eventData) {
            isEnter = false;
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