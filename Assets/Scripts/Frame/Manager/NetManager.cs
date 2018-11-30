namespace U3DEventFrame
{
    public class NetManager : ManagerBase
    {
        public static NetManager Instance;

        public void SendMsg(MsgBase msg)
        {
            if (msg.GetManager() == (int)ManagerID.NetManager)
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
        }
    }
}