using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MsgFramework
{
    /// <summary>
    /// 消息中心，负责消息的转发
    /// </summary>
    public class MsgCenter : MonoBehaviour
    {
        public static MsgCenter instance = null;

        public Dictionary<int, ManagerBase> managers{
            get;
            private set;
        }

        private void Awake() {
            if(instance == null){
                instance = this;
                DontDestroyOnLoad(gameObject);

                #region 模块
                managers = new Dictionary<int, ManagerBase>();
                managers.Add(AreaCode.UI, new ManagerBase());
                managers.Add(AreaCode.GAME, new ManagerBase());
                managers.Add(AreaCode.CHARACTER, new ManagerBase());
                managers.Add(AreaCode.NETWORK, new ManagerBase());
                managers.Add(AreaCode.AUDIO, new ManagerBase());
                managers.Add(AreaCode.ITEM, new ManagerBase());

                #endregion
            }
            else{
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// 派发事件
        /// </summary>
        /// <param name="areaCode">区域码</param>
        /// <param name="eventCode">事件码</param>
        /// <param name="arg">参数</param>
        public void Dispatch(int areaCode, int eventCode, object arg){
            if(!managers.ContainsKey(areaCode)){
                Debug.LogWarning("模块<{areaCode}>不存在");
                return ;
            }
            managers[areaCode].Execute(eventCode, arg);
        }
    }
}