using UnityEngine;

public class Frog : MonoBehaviour
{
    public bool Given = false; // Whether the frog has been given an item
    public Transform partyLocation; // The location where the frog moves after receiving an item
    private Animator animator; // For controlling animations
    private bool movedToParty = false; // Track if the frog has moved to the party location

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
            // Immediately trigger the "Given" animation
            TriggerGivenAnimation();

            // Move the frog to the party location after 2 seconds
            Invoke("MoveToParty", 2f);

            // Ensure this only happens once
            movedToParty = true;
        }
    }

    // Trigger the animation immediately when Given is true
    void TriggerGivenAnimation()
    {
        if (animator != null)
        {
            // Switch to the "Given" animation immediately
            animator.SetTrigger("Given");
        }
    }

    // Move the frog to the party location after the delay
    void MoveToParty()
    {
        // Move the frog to the specified party location
        transform.position = partyLocation.position;
    }
}
