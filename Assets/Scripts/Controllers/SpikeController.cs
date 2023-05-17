using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SW.Combat;
using System;


namespace SW.Control
{

    public class SpikeController : MonoBehaviour
    {
        Health health;
        GameObject player;
        GameObject spikeTrap;
        public Action<float> spikeDamageAction;

        private void Awake()
        {
            player = GameObject.FindWithTag("Player");
            

        }

        private void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.CompareTag("Player"))
            {
                transform.GetChild(0).gameObject.SetActive(true);
                health = collider.gameObject.GetComponent<Health>();
                if(health != null)
                {
                    health.DamageIntake(5);
                }
                
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            if(collider.gameObject.CompareTag("Player"))
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

}
