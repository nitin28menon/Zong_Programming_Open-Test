namespace MyUIFramework
{
    public abstract class PopupBase : PanelBase
    {
        public override bool IsActive
        {
            get
            {
                return CachedGameObject.activeSelf;
            }
        }

        public override void Activate()
        {
            base.Activate();
            CachedGameObject.SetActive(true);
        }

        public override void DeActivate()
        {
            base.DeActivate();
            CachedGameObject.SetActive(false);
        }

        public override void OnBackKeyPressed()
        {
            base.OnBackKeyPressed();
            DeActivate();
        }
    }
}
