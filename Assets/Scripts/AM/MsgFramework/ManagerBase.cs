
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MsgFramework
{
    /// <summary>
    /// 模块基类
    /// </summary>
    public class ManagerBase
    {
        /// <summary>
        /// 事件关联列表
        /// </summary>
        /// <typeparam name="int">事件码</typeparam>
        /// <returns>事件关联的脚本列表</returns>
        Dictionary<int, List<MonoBase>> dict = new Dictionary<int, List<MonoBase>>();

        /// <summary>
        /// 添加事件关联
        /// </summary>
        /// <param name="eventCode">事件码</param>
        /// <param name="mono">关联的脚本</param>
        public void Add(int eventCode, MonoBase mono){
            List<MonoBase> monos = null;
            //事件未被注册过
            if(!dict.ContainsKey(eventCode)){
                monos = new List<MonoBase>();
                monos.Add(mono);
                dict.Add(eventCode, monos);
                return;
            }
            //事件被注册过
            monos = dict[eventCode];
            if(monos.Contains(mono)){
                Debug.LogWarning($"重复注册事件<{eventCode}>与脚本<{mono}>的关联");
                return;
            }
            monos.Add(mono);
        }

        /// <summary>
        /// 添加多个事件关联
        /// </summary>
        /// <param name="eventCodes">事件码列表</param>
        /// <param name="mono">关联的脚本</param>
        public void Add(int[] eventCodes, MonoBase mono){
            foreach(int eventCode in eventCodes){
                Add(eventCode, mono);
            }
        }

        /// <summary>
        /// 移除事件关联
        /// </summary>
        /// <param name="eventCode">事件码</param>
        /// <param name="mono">关联的脚本</param>
        public void Remove(int eventCode, MonoBase mono){
            if(!dict.ContainsKey(eventCode)){
                Debug.LogWarning($"未过注册事件<{eventCode}>");
                return;
            }
            List<MonoBase> monos = dict[eventCode];
            if(!monos.Contains(mono)){
                Debug.LogWarning($"未注册过事件<{eventCode}>与脚本<{mono}>的关联");
                return;
            }
            if(monos.Count == 1){
                dict.Remove(eventCode);
            }
            else{
                monos.Remove(mono);
            }
        }

        /// <summary>
        /// 移除多个事件关联
        /// </summary>
        /// <param name="eventCodes">事件码</param>
        /// <param name="mono">关联的脚本</param>
        public void Remove(int[] eventCodes, MonoBase mono){
            foreach(int eventCode in eventCodes){
                Remove(eventCode, mono);
            }
        }

        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="eventCode">事件码</param>
        /// <param name="arg">事件参数</param>
        public void Execute(int eventCode, object arg){
            if(!dict.ContainsKey(eventCode)){
                Debug.LogWarning($"事件<{eventCode}>未注册");
                return;
            }
            foreach(MonoBase mono in dict[eventCode]){
                mono.Execute(eventCode, arg);
            }
        }
    }
}