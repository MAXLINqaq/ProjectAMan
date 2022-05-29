using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.MsgFramework.UI;
using UnityEngine;

namespace Assets.Scripts.AM.UI
{
    public class PanelBase : UIBase
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}