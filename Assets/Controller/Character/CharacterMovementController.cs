using Math;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class CharacterMovementController : MonoBehaviour
    {
        [SerializeField]
        private Collider _collider;

        public float moveSpeed;

        public float rotationSpeed;

        private Vector3 movementDestination;

        private Quaternion rotationDestination;

        private void Start()
        {
            InputController.OnCharacterMovementInput += HandleMovement;
            movementDestination = GetAdjustedForGroundDestination(transform.position); // Set Initial movement
        }

        private void Update()
        {
            MoveTo(movementDestination);
            RotateTo(rotationDestination);
        }

        private void HandleMovement(Vector3 destination)
        {
            SetMovementDestination(destination);
            SetRotationDestination(destination);
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

        private void SetRotationDestination(Vector3 destination)
        {
            Quaternion rotateDirection = GetRotationDirection(destination);
            rotationDestination = rotateDirection;
        }

        private Quaternion GetRotationDirection(Vector3 destination)
        {
            Quaternion rotateDirection = transform.rotation;
            Vector3 movementDirection = (destination - transform.position).normalized;

            if (movementDirection != Vector3.zero)
            {
                float yRotation = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
                rotateDirection = Quaternion.Euler(0, yRotation, 0);
            }

            return rotateDirection;
        }

        private void RotateTo(Quaternion destination)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, destination, rotationSpeed * Time.deltaTime); // TODO give CharacterStats a rotation speed
        }

        private void OnDestroy()
        {
            InputController.OnCharacterMovementInput -= SetMovementDestination;
        }
    }
}
