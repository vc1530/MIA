using UnityEngine;

public class ArmController : MonoBehaviour
{
    public Transform armEnd;
    public LineRenderer lineRenderer;
    public float armSpeed = 10f;
    public float launchForce = 500f; // Adjust as needed
    public float verticalLaunchForce = 100f; // Adjust as needed for the desired height
    public float horizontalLaunchDistance = 1f; // Adjust as needed for the desired distance
    public LayerMask latchLayer; // Layer mask to specify which objects can be latched onto

    private bool isExtendingArm = false;
    private GameObject grabbedObject;
    private Vector2 launchDirection;
    private GameObject currentPlatform; // Track the current platform the character is on

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isExtendingArm)
        {
            isExtendingArm = true;
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, GetMouseWorldPosition() - transform.position, Mathf.Infinity, latchLayer);
            if (hit.collider != null)
            // && hit.collider.gameObject != currentPlatform) // Check if the hit platform is not the current platform
            {
                lineRenderer.SetPosition(1, hit.point);
                armEnd.position = hit.point;
                if (hit.collider.CompareTag("Floor"))
                {
                    grabbedObject = hit.collider.gameObject;
                    CalculateLaunchDirection(hit.point);
                }
                ExtendArm();
            }
            else
            {
                lineRenderer.SetPosition(1, GetMouseWorldPosition());
            }
        }
        else if (!Input.GetKey(KeyCode.Space) && isExtendingArm)
        {
            isExtendingArm = false;
            lineRenderer.enabled = false;
            if (grabbedObject != null)
            {
                LaunchCharacter();
                grabbedObject = null;
            }
        }

        //UpdateCurrentPlatform(); // Update the current platform continuously
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    void ExtendArm()
    {
        StartCoroutine(MoveArm());
    }

    System.Collections.IEnumerator MoveArm()
    {
        Vector3 startPosition = armEnd.position;
        Vector3 targetPosition = GetMouseWorldPosition();
        float distance = Vector3.Distance(startPosition, targetPosition);
        float time = distance / armSpeed;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            armEnd.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / time);
            yield return null;
        }
    }

    void CalculateLaunchDirection(Vector2 targetPosition)
    {
        Vector2 targetDirection = targetPosition - (Vector2)transform.position;
        Vector2 horizontalDirection = targetDirection.normalized * horizontalLaunchDistance;
        Vector2 verticalDirection = Vector2.up * verticalLaunchForce;
        launchDirection = horizontalDirection + verticalDirection;
    }

    void LaunchCharacter()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = launchDirection * launchForce * Time.fixedDeltaTime;
    }

    // void UpdateCurrentPlatform()
    // {
    //     RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, latchLayer);
    //     if (hit.collider != null && hit.collider.CompareTag("Floor"))
    //     {
    //         currentPlatform = hit.collider.gameObject;
    //     }
    // }
}