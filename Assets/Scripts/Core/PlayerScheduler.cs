using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SW.Interface;


namespace SW.Core
{

    public class PlayerScheduler : MonoBehaviour
    {
        IAction currentAction;
            public void StartAction(IAction action)
            {
                if(currentAction == action) return;
                if(currentAction != null)
                {
                    currentAction.Cancel();
                }
                
                currentAction = action;
            }

            public void CancelCurrentAction()
            {
                StartAction(null);
            }
    }

}
