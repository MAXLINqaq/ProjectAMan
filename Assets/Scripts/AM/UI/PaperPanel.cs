using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts.AM.UI
{
    public class PaperPanel : PanelBase, IPointerClickHandler
    {
        #region 消息绑定
        private void Awake() {
            Bind(
                UIEventCode.SHOW_PAPER_CONTENT
            );
        }
        public override void Execute(int eventCode, object arg) {
            switch(eventCode){
                case UIEventCode.SHOW_PAPER_CONTENT:{
                    ShowContent((int)arg);
                    break;
                }
                default:break;
            }
        }
        #endregion
        
        #region 子物体
        public PaperConfig paperConfig;
        Text text;
        private void Start() {//初始化
            text = transform.Find("Img_Bg/Text").GetComponent<Text>();
            paperConfig.Init();
            Hide();
        }
        #endregion
        
        #region 方法
        void ShowContent(int id){
            text.text = paperConfig.GetPaperContent(id);
            Show();
        }
        public void OnPointerClick(PointerEventData eventData) {
            Hide();
        }
        #endregion
        
        #region Test
        #if UNITY_EDITOR
        [ContextMenu("Test/Test")]
        void TEST_Test(){
            ShowContent(0);
        }

        #endif
        #endregion
    }
}