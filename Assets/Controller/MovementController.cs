using Math;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField]
        private InputController _inputController;

        [SerializeField]
        private Collider _collider;

        public float moveSpeed;

        private Vector3 movementDestination;

        private void Start()
        {
            InputController.OnMovementInput += SetMovementDestination;
            movementDestination = GetAdjustedForGroundDestination(transform.position);
        }

        private void Update()
        {
            MoveTo(movementDestination);
        }

        private void SetMovementDestination(Vector3 destination)
        {
            destination = GetAdjustedForGroundDestination(destination);

            movementDestination = destination;
        }

        private Vector3 GetAdjustedForGroundDestination(Vector3 destination)
        {
            float objectHeight = _collider.bounds.size.y;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground")) // TODO make this a property maybe
                {
                    float groundHeight = hit.point.y;
                    destination = new Vector3(destination.x, groundHeight + objectHeight / 2, destination.z);
                }
            }

            return destination;
        }

        public void MoveTo(Vector3 destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
        }

        private void OnDestroy()
        {
            InputController.OnMovementInput -= MoveTo;
        }
    }
}
