using UnityEngine;

public class Frog : MonoBehaviour
{
    public bool Given = false;
    public Transform partyLocation; // The location where the frog moves after receiving an item
    private Animator animator; // For controlling animations
    private bool movedToParty = false;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();

        // If the animator is found, play the idle animation
        if (animator != null)
        {
            animator.Play("Idle");
        }
    }

    void Update()
    {
        if (Given && !movedToParty)
        {
            // Check if the animator exists before trying to trigger an animation
            if (animator != null)
            {
                // Switch to the "Given" animation
                animator.SetTrigger("Given");
            }

            // Move the frog to the party location after 2 seconds
            Invoke("MoveToParty", 2f);

            // Ensure this only happens once
            movedToParty = true;
        }
    }

    void MoveToParty()
    {
        // Move the frog to the party location
        transform.position = partyLocation.position;
    }
}
