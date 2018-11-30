using System.Collections.Generic;
using UnityEngine;

namespace U3DEventFrame
{
    public class UIManager : ManagerBase
    {
        public static UIManager Instance;

        public void SendMsg(MsgBase msg, int backId = -1)
        {
            this.ProcessSendBackMsg(backId);

            if (msg.GetManager() == (int)ManagerID.UIManager)
            {
                ProcessEvent(msg);
            }
            else
            {
                MsgCenter.Instance.SendToMsg(msg);
            }
        }

        private void Awake()
        {
            Instance = this;
            InitialBackMsg();
        }

        #region GameObject

        public Dictionary<string, Dictionary<string, GameObject>> ChildMembers
        {
            get
            {
                if (_childMembers == null)
                {
                    _childMembers = new Dictionary<string, Dictionary<string, GameObject>>();
                }

                return _childMembers;
            }
        }

        private Dictionary<string, Dictionary<string, GameObject>> _childMembers = null;

        public void RegistGameObject(string panelName, string objName, GameObject tmpObj)
        {
            if (ChildMembers.ContainsKey(panelName))
            {
                if (!ChildMembers[panelName].ContainsKey(objName))
                {
                    ChildMembers[panelName].Add(objName, tmpObj);
                }
            }
            else
            {
                Dictionary<string, GameObject> tmpPanel = new Dictionary<string, GameObject>();
                
                tmpPanel.Add(objName, tmpObj);
                ChildMembers.Add(panelName, tmpPanel);
            }
        }

        public void UnRegistGameObject(string panelName, string objName)
        {
            if (ChildMembers.ContainsKey(panelName))
            {
                if (ChildMembers[panelName].ContainsKey(objName))
                {
                    ChildMembers[panelName].Remove(objName);
                }
            }
        }

        public void UnRegistPanelGameObject(string panelName)
        {
            if (ChildMembers.ContainsKey(panelName))
            {
                ChildMembers[panelName].Clear();
                ChildMembers.Remove(panelName);
            }
        }

        public GameObject GetGameObject(string panelName, string objName)
        {
            if (ChildMembers.ContainsKey(panelName))
            {
                if (ChildMembers[panelName].ContainsKey(objName))
                    return ChildMembers[panelName][objName];
            }

            return null;
        }

        #endregion
    }
}
