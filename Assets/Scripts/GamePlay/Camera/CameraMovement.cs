using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZPOT.GamePlay
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform cameraPosition;

        private void Update()
        {
            transform.position = cameraPosition.position;
        }
    }
}
