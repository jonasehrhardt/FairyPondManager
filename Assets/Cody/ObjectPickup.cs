using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public float rayDistance = 5f; // Distance of raycast
    public Transform holdPosition; // Where the object will be held by the player

    public Material highlightMaterial; // Assign this in the Inspector
    private Material originalMaterial; // To store the object's original material
    private GameObject highlightedObject; // To keep track of the currently highlighted object

    private GameObject heldObject = null;
    private bool isHolding = false;

    void Update()
    {
        // Highlight object if we are not holding anything
        if (!isHolding)
        {
            HighlightObject();
        }
        else
        {
            // If we're holding an object, make sure nothing is highlighted
            RemoveHighlight();
        }

        // Existing pickup and interaction logic
        if (Input.GetMouseButtonDown(0))
        {
            if (isHolding)
            {
                TryGiveToFrog();
            }
            else
            {
                TryPickupObject();
            }
        }
    }

    // Try to pick up an object
    // Try to pick up an object
    void TryPickupObject()
    {
        // Cast a ray from the center of the screen
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // Check if the hit object is on the "Pickup" layer
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Pickup"))
            {
                // Make sure to remove the highlight before picking up
                RemoveHighlight();

                // Get the object's Rigidbody and set it to kinematic
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                // Disable the collider to prevent collisions while holding
                Collider collider = hit.collider.GetComponent<Collider>();
                if (collider != null)
                {
                    collider.enabled = false;
                }

                // Parent the object to the "Hold Position" object
                heldObject = hit.collider.gameObject;
                heldObject.transform.SetParent(holdPosition);
                heldObject.transform.localPosition = Vector3.zero; // Position it at the hold position
                heldObject.transform.localRotation = Quaternion.identity; // Reset rotation

                isHolding = true;
            }
        }
    }

    // Try to give the held object to the frog
    // Try to give the held object to the frog
    void TryGiveToFrog()
    {
        // Cast a ray from the center of the screen
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // Check if the hit object is on the "Frog" layer
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Frog"))
            {
                // If we have an object in hand
                if (heldObject != null)
                {
                    // Remove the highlight before giving the object
                    RemoveHighlight();

                    // Destroy the held object and stop holding
                    Collider heldCollider = heldObject.GetComponent<Collider>();
                    if (heldCollider != null)
                    {
                        heldCollider.enabled = true; // Re-enable the collider if necessary
                    }

                    // Destroy the held object
                    Destroy(heldObject);
                    isHolding = false;

                    // Trigger the specific frog's "Given" behavior
                    Frog frog = hit.collider.GetComponent<Frog>();
                    if (frog != null)
                    {
                        frog.Given = true; // Set the frog's "Given" state to true
                    }

                    // Ensure the frog is not highlighted after the object is given
                    RemoveHighlight();
                }
            }
        }
    }





    // Highlight object under the raycast
    // Highlight object under the raycast
    void HighlightObject()
    {
        // Cast a ray from the center of the screen
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        // Check for raycast hit
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // Check if we are hitting something on the "Pickup" or "Frog" layers
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Pickup") ||
                hit.collider.gameObject.layer == LayerMask.NameToLayer("Frog"))
            {
                Highlight(hit.collider.gameObject);
            }
            else
            {
                RemoveHighlight(); // Remove the highlight if the ray is not over a valid object
            }
        }
        else
        {
            RemoveHighlight(); // No hit, so remove the highlight
        }
    }

    // Helper method to handle the actual highlighting
    void Highlight(GameObject obj)
    {
        // If the object is not already highlighted, switch the material
        if (highlightedObject != obj)
        {
            RemoveHighlight(); // Remove the highlight from the previously highlighted object

            // Store the reference to the original material
            Renderer objRenderer = obj.GetComponent<Renderer>();
            if (objRenderer != null)
            {
                originalMaterial = objRenderer.material; // Save the original material
                objRenderer.material = highlightMaterial; // Switch to the highlight material
            }

            highlightedObject = obj; // Update the currently highlighted object
        }
    }




    // Remove highlight from the currently highlighted object
    void RemoveHighlight()
    {
        if (highlightedObject != null)
        {
            // Revert the material to the original one
            Renderer objRenderer = highlightedObject.GetComponent<Renderer>();
            if (objRenderer != null && originalMaterial != null)
            {
                objRenderer.material = originalMaterial;
            }

            // Clear the highlighted object
            highlightedObject = null;
        }
    }

}