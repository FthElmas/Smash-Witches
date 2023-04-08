using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SW.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]private float speed = 10f;
        [SerializeField]private float speedTurn;
        [SerializeField] private float updateTime = 10f;
        
        
        NavMeshAgent navMesh;

        Rigidbody rb;
        
        public FloatingJoystick floatingJoystick;


        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            navMesh = GetComponent<NavMeshAgent>();
        }
        public IEnumerator UpdateSpeed()
        {
            speed = 6f;

            yield return new WaitForSeconds(updateTime);

            speed = 3f;
        }

        public void SpeedCoroutine()
        {
            StartCoroutine(UpdateSpeed());
        }
        private void Update()
        {
            if (Input.GetButton("Fire1"))
            {
                JoystickBehaviour();
            }
            else if(Input.GetButtonUp("Fire1"))
            {
                rb.velocity = Vector3.zero;
            }  
        }

        private void JoystickBehaviour()
        {
            float horizontal = floatingJoystick.Horizontal;
            float vertical = floatingJoystick.Vertical;
            Vector3 addedPos = new Vector3(horizontal, rb.velocity.y, vertical);

            rb.velocity = addedPos.normalized * speed;
            
            Vector3 direction  = Vector3.forward * vertical + Vector3.right * horizontal;
            if(horizontal !=0 && vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(direction);
                
            }
            
        


            
            
        }

        
    }

}
