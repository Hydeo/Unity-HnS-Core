using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Transform zoomTransforms;
        // Start is called before the first frame update
        int zoomLevel = 0;
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = target.position; // Follow the target
            UpdateZoomLevel();

        }

        private void UpdateZoomLevel()
        {
            float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
            if (scrollDelta != 0f)
            {
                if (scrollDelta > 0f) // forward
                {
                    zoomLevel = zoomLevel - 1 < 0 ? zoomTransforms.childCount - 1 : zoomLevel - 1;
                }
                else
                {
                    zoomLevel = zoomLevel + 1 >= zoomTransforms.childCount ? 0 : zoomLevel + 1;
                }
            }
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, zoomTransforms.GetChild(zoomLevel).position, 0.2f);

        }
    }
}