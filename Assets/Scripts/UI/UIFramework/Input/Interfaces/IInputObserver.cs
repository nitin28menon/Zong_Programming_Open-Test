using UnityEngine;

namespace MyUIFramework
{
    /// <summary>
    /// Interface to be attached on input observers
    /// </summary>
    public interface IInputObserver 
    {
        /// <summary>
        /// Notifies the obervers when key is pressed
        /// </summary>
        void Notify(KeyCode keyCode);
    }
}

