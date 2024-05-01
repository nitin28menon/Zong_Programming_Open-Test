using System;

namespace MyUIFramework
{
    public abstract class ScreenBase : PanelBase
    {
        public override bool IsActive
        {
            get
            {
                return CachedGameObject.activeSelf;
            }
        }

        protected DateTime startTime = DateTime.Now;

        public override void Activate()
        {
            base.Activate();
            CachedGameObject.SetActive(true);
            startTime = DateTime.Now;
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

