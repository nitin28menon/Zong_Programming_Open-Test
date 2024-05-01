using UnityEngine;
using UnityEngine.UI;

namespace MyUIFramework
{
    public class UIBehaviour : CustomBehaviour
    {
        RectTransform cachedRectTransform;

        public RectTransform CachedRectTransform
        {
            get
            {
                if(cachedRectTransform == null)
                    cachedRectTransform = GetComponent<RectTransform>();
                return cachedRectTransform;
            }
        }

        Image cachedImage;

        public Image CachedImage
        {
            get
            {
                if(cachedImage == null)
                    cachedImage = GetComponent<Image>();
                return cachedImage;
            }
        }
    }
}

