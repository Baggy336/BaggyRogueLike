using Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class MovementController : MonoBehaviour
    {
        public void MoveTo(Vector3 destination, float moveSpeed)
        {
            transform.position = AnimMath.Lerp(transform.position, destination, moveSpeed * Time.deltaTime);
        }
    }
}
