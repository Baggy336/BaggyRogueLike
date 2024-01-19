using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Controller
{
    public class HighlightOnHover : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer _meshRenderer;

        private Material originalMaterial;

        [SerializeField]
        private Material highlightMaterial;

        private void Start()
        {
            originalMaterial = _meshRenderer.material;
        }

        private void OnMouseOver()
        {
            _meshRenderer.material = highlightMaterial;
        }

        private void OnMouseExit()
        {
            _meshRenderer.material = originalMaterial;
        }
    }
}
