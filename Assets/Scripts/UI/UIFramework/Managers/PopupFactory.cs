using System.Collections.Generic;
using UnityEngine;

namespace MyUIFramework
{
    public class PopupFactory : UIAbstractFactory<PopupBase>, IInputObserver
    {
        #region Private Variables

        private Stack<PopupBase> screenStack = new Stack<PopupBase>();

        #endregion 

        #region Public Variables

        public PopupBase defaultPopup;

        #endregion 

        #region Properties

        public static PopupFactory Instance { get; private set; }

        public PopupBase CurrentPopup
        {
            get
            {
                if (screenStack.Count == 0)
                    return null;
                return screenStack.Peek();
            }
        }

        #endregion

        /// <summary>
        /// Initalises components and sets the default popup
        /// </summary>
        protected override void Init()
        {
            base.Init();
            Instance = this;
            if (defaultPopup != null)
                Activate(defaultPopup);
        }

        /// <summary>
        /// activates the first popup
        /// </summary>
        public T Activate<T>() where T : PopupBase
        {
            T popup = GetPanel<T>();
            popup.Activate();
            StartCoroutine(CallBackCoroutine(popup.OnShow));
            screenStack.Push(popup as PopupBase);
            return popup;
        }

        /// <summary>
        /// activates the particular popup passed in as parameter
        /// </summary>
        public PopupBase Activate(PopupBase popup)
        {
            popup.Activate();
            StartCoroutine(CallBackCoroutine(popup.OnShow));
            screenStack.Push(popup);
            return popup;
        }

        
        public T Deactivate<T>() where T : PopupBase
        {
            T popup = null;
            if (screenStack.Count > 0)
            {
                while (!screenStack.Peek().IsActive)
                {
                    screenStack.Pop();
                    if (screenStack.Count == 0)
                        return null;
                }

                if (screenStack.Peek().GetType().Name.Equals(typeof(T).Name))
                    popup = screenStack.Pop() as T;
                else
                    popup = GetPanel<T>();

                popup.DeActivate();
                StartCoroutine(CallBackCoroutine(popup.OnHide));
            }
            return popup;
        }

        /// <summary>
        /// deactivates the particular popup passed in as parameter
        /// </summary>
        public PopupBase Deactivate(PopupBase popup)
        {
            if (screenStack.Count > 0)
            {
                while (!screenStack.Peek().IsActive)
                {
                    screenStack.Pop();
                    if (screenStack.Count == 0)
                        return null;
                }
                popup.DeActivate();
                StartCoroutine(CallBackCoroutine(popup.OnHide));
            }
            return popup;
        }

        /// <summary>
        /// deactivates the top most popup
        /// </summary>
        public void DeactivateTopPopup()
        {
            PopupBase popup = screenStack.Pop();
            popup.DeActivate();
            StartCoroutine(CallBackCoroutine(popup.OnHide));
        }

        /// <summary>
        /// deactivates all the popups
        /// </summary>
        public void DeactivateAll()
        {
            foreach (var item in allPanels)
            {
                if (item.CachedGameObject.activeSelf)
                    item.CachedGameObject.SetActive(false);
            }
        }

        public void Notify(KeyCode keyCode)
        {
            switch (keyCode)
            {
                case KeyCode.Escape:
                    CurrentPopup.OnBackKeyPressed();
                    break;
            }
        }
    }
}

