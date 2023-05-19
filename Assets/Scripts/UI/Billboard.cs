using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


namespace SW.UI
{
    public class Billboard : MonoBehaviour
    {
        public GameObject cinemachineCam;

        private void Start()
        {
            cinemachineCam = GameObject.FindWithTag("MainCamera");
        }
        private void LateUpdate()
        {
            transform.LookAt(transform.position + cinemachineCam.transform.forward);
        }
    }

}
