using Core;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Subscribed to in the AbilityController
    public static Action<KeyCode> OnAbilityInput;

    // Subscribed to in the MovementController
    public static Action<Vector3> OnMovementInput;

    // Subscribed to in the AttackController
    public static Action<Vector3> OnAttackInput;

    private List<KeyCode> abilityKeys = new List<KeyCode>();

    [SerializeField]
    private List<LayerMask> interactableLayers;

    private void Update()
    {
        CheckAbilityInput();
        CheckRightMouseButtonInput();
    }

    // AbilityController will pass the abilitykeys to this class to register
    public void RegisterKeyCode(KeyCode key)
    {
        if(!abilityKeys.Contains(key))
        {
            abilityKeys.Add(key);
        }
    }

    public void CheckAbilityInput()
    {
        // Check keys with an ability assigned to them
        foreach (KeyCode key in abilityKeys)
        {
            if (Input.GetKeyDown(key))
            {
                OnAbilityInput?.Invoke(key);
            }
        }
    }

    public void CheckRightMouseButtonInput()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                int hitLayer = hit.transform.gameObject.layer;
                
                foreach(LayerMask layer in interactableLayers)
                {
                    if(hitLayer == (int)Mathf.Log(layer.value, 2))
                    {
                        HandleValidHitLayer(hit.point, hitLayer);
                        break;
                    }
                } 
            }

        }
    }

    private void HandleValidHitLayer(Vector3 hitLocatiion, int hitLayer)
    {
        string layerName = LayerMask.LayerToName(hitLayer);

        switch (layerName)
        {
            case "Ground":
                MovementInput(hitLocatiion);
                break;
            case "Enemy":
                AttackInput(hitLocatiion); // TODO make this send a gameobject to attack rather than location?
                break;
            default:
                break;
        }
    }

    private void MovementInput(Vector3 location)
    {
        OnMovementInput?.Invoke(location);
    }
    
    private void AttackInput(Vector3 location)
    {
        OnAttackInput?.Invoke(location);
    }
}
