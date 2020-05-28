using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial {
    public class AimScript : MonoBehaviour
    {

        public Transform targetTransform;
        public LayerMask mouseAimMask;

        private Rigidbody rg;
        private Camera mainCamera;

        void Start()
        {
            rg = GetComponent<Rigidbody>();
            mainCamera = Camera.main;
        }

        private void Update()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mouseAimMask))
            {
                targetTransform.position = hit.point;
            }
        }

        private void FixedUpdate()
        {
            float direction = Mathf.Sign(targetTransform.position.z - transform.position.z);
            if (direction > 0)
            {
                VirtualInputManager.Instance.LookRight = true;
                VirtualInputManager.Instance.LookLeft = false;
            }
            else
            {
                VirtualInputManager.Instance.LookLeft = true;
                VirtualInputManager.Instance.LookRight = false;

            }
            rg.MoveRotation(Quaternion.Euler(new Vector3(0, 90 - (90 * Mathf.Sign(targetTransform.position.z - transform.position.z)), 0)));
        }

    }
}
