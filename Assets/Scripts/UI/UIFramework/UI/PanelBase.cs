using UnityEngine;
using UnityEngine.EventSystems;

namespace MyUIFramework
{
    public class PanelBase : UIBehaviour, IPanel
    {
        public virtual bool IsActive { get; private set; }
        public virtual void Init()
        {
        }

        public virtual void Activate()
        {
        }

        public virtual void DeActivate()
        {
        }

        public virtual void OnShow()
        {

        }

        public virtual void OnHide()
        {

        }

        public void OnButtonEventReceived()
        {
            OnButtonClick(EventSystem.current.currentSelectedGameObject);
        }

        public virtual void OnBackKeyPressed()
        {
            
        }

        protected virtual void OnButtonClick(GameObject button)
        {

        }
    }
}

