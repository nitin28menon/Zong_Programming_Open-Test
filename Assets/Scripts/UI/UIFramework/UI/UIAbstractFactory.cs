using System.Collections;
using UnityEngine;

namespace MyUIFramework
{
    public class UIAbstractFactory<U> : UIBehaviour where U : PanelBase
    {
        [SerializeField] protected U[] allPanels;

        private void Awake()
        {
            for (int i = 0; i < allPanels.Length; i++)
            {
                allPanels[i].Init();
            }
            Init();
        }

        protected virtual void Init()
        {

        }

        public IEnumerator CallBackCoroutine(System.Action callback)
        {
            yield return null;
            callback.Invoke();
        }

        public T GetPanel<T>() where T : PanelBase
        {
            return System.Array.Find(allPanels, t => t.GetType().Name == typeof(T).Name) as T;
        }

        public void AddCustomPanels(U[] panels)
        {
            U[] _allPanels = new U[allPanels.Length + panels.Length];

            for (int i = 0; i < allPanels.Length; i++)
            {
                _allPanels[i] = allPanels[i];
            }

            for (int i = 0; i < panels.Length; i++)
            {
                _allPanels[allPanels.Length + i] = panels[i];
                panels[i].Init();
            }

            allPanels = new U[_allPanels.Length];
            allPanels = _allPanels;
            Init();
        }
    }
}

