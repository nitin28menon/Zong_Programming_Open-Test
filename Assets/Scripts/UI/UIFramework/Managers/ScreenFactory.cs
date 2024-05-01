using UnityEngine;

namespace MyUIFramework
{
    /// <summary>
    /// Factory class for managing all screens
    /// </summary>
    public class ScreenFactory : UIAbstractFactory<ScreenBase>, IInputObserver
    {
        #region Public Variables

        public ScreenBase defaultScreen;
        public ScreenBase currentScreen;

        #endregion

        #region Properties

        public static ScreenFactory Instance { get; private set; }

        #endregion

        #region Factory methods implementations

        /// <summary>
        /// Initalises components and sets the default screen
        /// </summary>
        protected override void Init()
        {
            base.Init();
            Instance = this;
            if (defaultScreen != null)
            {
                defaultScreen.Activate();
                currentScreen = defaultScreen;
            }
        }

        /// <summary>
        /// activates the first screen
        /// </summary>
        public virtual T Activate<T>() where T : ScreenBase
        {
            T panel = GetPanel<T>();
            panel.Activate();
            StartCoroutine(CallBackCoroutine(panel.OnShow));
            currentScreen = panel;
            return panel;
        }

        /// <summary>
        /// deactivates the first active screen
        /// </summary>
        public virtual T Deactivate<T>() where T : ScreenBase
        {
            T panel = GetPanel<T>();
            panel.DeActivate();
            StartCoroutine(CallBackCoroutine(panel.OnHide));
            return panel;
        }

        /// <summary>
        /// deactivates the particular screen passed in as parameter
        /// </summary>
        public virtual ScreenBase Deactivate(ScreenBase panel)
        {
            panel.DeActivate();
            StartCoroutine(CallBackCoroutine(panel.OnHide));
            return panel;
        }

        /// <summary>
        /// deactivates all the screens
        /// </summary>
        public void DeactivateAll()
        {
            foreach (var item in allPanels)
            {
                if (item.CachedGameObject.activeSelf)
                    item.CachedGameObject.SetActive(false);
            }
        }

        #endregion

        #region Input observer interface implementations

        /// <summary>
        /// called when a key is pressed
        /// </summary>
        public void Notify(KeyCode keyCode)
        {
            switch (keyCode)
            {
                case KeyCode.Escape:
                    if (currentScreen != null)
                        currentScreen.OnBackKeyPressed();
                    break;
            }
        }

        #endregion
    }
}

