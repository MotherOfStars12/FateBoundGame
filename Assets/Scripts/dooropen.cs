using UnityEngine;
using UnityEngine.InputSystem;

public class dooropen : MonoBehaviour
{
    
    public Transform pointA;  
    public Transform pointB;  

    
    public float interactDistance = 1.5f;

    Transform player;
    Transform currentTarget;  

    void Start()
    {
        
        currentTarget = pointB;
    }

    void Update()
    {
        FindPlayerIfNeeded();

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            TryDoorClick();
        }
    }

    void FindPlayerIfNeeded()
    {
        if (player == null)
        {
            var p = FindFirstObjectByType<player_movement>();
            if (p != null) player = p.transform;
        }
    }

    void TryDoorClick()
    {
        if (player == null) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider == null || hit.collider.gameObject != gameObject) return;

        float dist = Vector2.Distance(player.position, transform.position);
        if (dist <= interactDistance)
        {
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        if (currentTarget == null)
        {
            Debug.LogError("Asignar pointA y pointB a la puerta: " + name);
            return;
        }

        player.position = currentTarget.position;

        
        currentTarget = (currentTarget == pointA) ? pointB : pointA;
    }
}

