using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SW.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]private float speed;
        [SerializeField]private float speedTurn;
        
        public FloatingJoystick floatingJoystick;

        private void FixedUpdate()
        {
            if (Input.GetButton("Fire1"))
            {
                JoystickBehaviour();
            }  
        }

        private void JoystickBehaviour()
        {
            float horizontal = floatingJoystick.Horizontal;
            float vertical = floatingJoystick.Vertical;

            Vector3 addedPos = new Vector3 (horizontal*speed*Time.deltaTime, 0, vertical*speed*Time.deltaTime);

            transform.position += addedPos;


            Vector3 direction  = Vector3.forward * vertical + Vector3.right * horizontal;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), speedTurn * Time.deltaTime);
        }
    }

}
