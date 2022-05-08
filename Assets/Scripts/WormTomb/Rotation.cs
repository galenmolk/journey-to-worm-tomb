using System;
using UnityEngine;

namespace WormTomb
{
    public class Rotation : MonoBehaviour
    {
        public float rotationSpeed;
        
        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }
}