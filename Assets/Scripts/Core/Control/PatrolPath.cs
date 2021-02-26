using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class PatrolPath : MonoBehaviour
    {   
        const float wayPointGizmoRadius = 0.3f;

        private void OnDrawGizmos()
        {
            for(int i = 0; i < transform.childCount; i++)
            {

                Gizmos.DrawSphere(GetWayPoint(i), wayPointGizmoRadius);
                Gizmos.DrawLine(GetWayPoint(i), GetWayPoint(GetNextIndex(i))); 
            }

        }

        public int GetNextIndex(int i)
        {
            if(i + 1 == transform.childCount)
            {
                return 0;
            }
            return i + 1;
        }
        public Vector3 GetWayPoint(int i)
        {
            return transform.GetChild(i).transform.position;
        }
    }
}