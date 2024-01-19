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
    public static Action<Vector3> OnCharacterMovementInput;

    // Subscribed to in the AttackController
    public static Action<GameObject> OnAttackInput;

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
                        HandleValidHitLayer(hit.point, hit.transform.gameObject, hitLayer); //TODO Just pass the hit to a method, and use the hit information to call other methods
                        break;
                    }
                } 
            }

        }
    }

    private void HandleValidHitLayer(Vector3 hitLocation, GameObject hitObject, int hitLayer)
    {
        string layerName = LayerMask.LayerToName(hitLayer);

        switch (layerName)
        {
            case "Ground":
                AttackInput(null);
                MovementInput(hitLocation);
                break;
            case "Enemy":
                AttackInput(hitObject);
                break;
            default:
                break;
        }
    }

    private void MovementInput(Vector3 location)
    {
        OnCharacterMovementInput?.Invoke(location);
    }
    
    private void AttackInput(GameObject hitEnemy)
    {
        OnAttackInput?.Invoke(hitEnemy);
    }
}
