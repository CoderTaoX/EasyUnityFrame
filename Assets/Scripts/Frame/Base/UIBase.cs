namespace U3DEventFrame
{
    public abstract class UIBase : MonoBase
    {
        public ushort[] msgIds;
        
        public void RegistSelf(MonoBase mono, params ushort[] msgs)
        {
            UIManager.Instance.RegistMsg(mono, msgs);
        }

        public void UnRegistSelf(MonoBase mono, params ushort[] msgs)
        {
            UIManager.Instance.UnRegistMsg(mono, msgs);
        }

        public void SendMsg(MsgBase msg)
        {
            UIManager.Instance.SendMsg(msg);
        }

        private void OnDestroy()
        {
            UIManager.Instance.UnRegistPanelGameObject(this.name);
            if (msgIds != null)
                UnRegistSelf(this, msgIds);
        }
    }
}