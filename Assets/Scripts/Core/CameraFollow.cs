using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SW.Core
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;

        void LateUpdate()
        {
            transform.position = target.position;
        }

        
    }
}
