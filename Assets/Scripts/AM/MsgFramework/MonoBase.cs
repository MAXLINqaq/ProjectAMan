
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MsgFramework
{

    /// <summary>
    /// 扩展 MonoBehaviour
    /// </summary>
    public class MonoBase : MonoBehaviour
    {
        public MonoBase(int ac){
            areaCode = ac;
        }

        /// <summary>
        /// 虚方法
        /// 处理事件
        /// </summary>
        public virtual void Execute(int eventCode, object arg)
        {

        }

        /// <summary>
        /// 区域码
        /// </summary>
        protected int areaCode{
            get;
            private set;
        }

        /// <summary>
        /// 自身绑定的事件列表
        /// </summary>
        /// <typeparam name="int"></typeparam>
        /// <returns>事件码</returns>
        protected List<int> bindedEvents = new List<int>();

        /// <summary>
        /// 绑定事件
        /// </summary>
        /// <param name="eventCodes">事件码</param>
        protected virtual void Bind(params int[] eventCodes)
        {
            MsgCenter.instance.managers[areaCode].Add(eventCodes, this);
            bindedEvents.AddRange(eventCodes);
        }

        /// <summary>
        /// 解除自身绑定的所有事件
        /// </summary>
        protected virtual void Unbind()
        {
            MsgCenter.instance.managers[areaCode].Remove(bindedEvents.ToArray(), this);
            bindedEvents.Clear();
        }

        protected virtual void OnDestroy()
        {
            Unbind();
        }

        /// <summary>
        /// 派发消息
        /// </summary>
        /// <param name="areaCode">区域码</param>
        /// <param name="eventCode">事件码</param>
        /// <param name="arg">消息参数</param>
        public void Dispatch(int areaCode, int eventCode, object arg)
        {
            MsgCenter.instance.Dispatch(areaCode, eventCode, arg);
        }
    }
}