using UnityEngine;

namespace MyUIFramework
{
    public class CustomBehaviour : MonoBehaviour
    {
        GameObject cachedGameObject;

        public GameObject CachedGameObject
        {
            get
            {
                if(cachedGameObject == null)
                    cachedGameObject = gameObject;
                return cachedGameObject;
            }
        }

        Transform cachedTransform;

        public Transform CachedTransform
        {
            get
            {
                if(cachedTransform == null)
                    cachedTransform = GetComponent<Transform>();
                return cachedTransform;
            }
        }
    }
}

