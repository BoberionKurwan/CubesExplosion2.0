using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private int _leftMouseButton = 0;
    private int _layerMask;

    public event Action<Cube> CubeClicked;

    private void Start()
    {
        int ignoreLayer = LayerMask.NameToLayer("IgnoreRaycast");
        _layerMask = ~(1 << ignoreLayer);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMask))
            {
                Cube cube = hit.collider.GetComponent<Cube>();
                
                if (cube != null) 
                CubeClicked?.Invoke(cube);
            }
        }
    }
}