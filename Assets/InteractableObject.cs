using UnityEngine;
using UnityEngine.UI;

public class BearObject : MonoBehaviour
{
    public GameObject textBox; // UI element for text box
    public GameObject player; // Reference to the player object
    public float interactionRadius = 3f; // Radius for interaction
    public CharacterController2D characterController; // Reference to the CharacterController2D script
    public static bool hasReceivedBuff = false; // Flag to track if the buff has been applied
    public GameObject interactionIndicator; // Assign this in the Inspector

void Update()
{

    FacePlayer();
    
    // Check if the player is within the interaction area and has not received a buff
    if (IsPlayerInInteractionArea() && !hasReceivedBuff)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowOptions();
        }

        ShowInteractionIndicator(true); // Show the interaction indicator only if no buff has been received
    }
    else
    {
        textBox.SetActive(false); // Hide text box when player is too far or has received a buff
        ShowInteractionIndicator(false); // Hide the interaction indicator
    }
}

void ShowInteractionIndicator(bool show)
{
    if(interactionIndicator != null)
    {
        interactionIndicator.SetActive(show);
    }
}

void FacePlayer()
{
    // Assuming the bear's sprite initially faces right and flips on the x-axis to face left.
    bool shouldFaceRight = player.transform.position.x > transform.position.x;
    if(shouldFaceRight)
    {
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    else
    {
        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}

    bool IsPlayerInInteractionArea()
    {
        return Vector2.Distance(player.transform.position, transform.position) <= interactionRadius;
    }

    void ShowOptions()
    {
        // Code to display text box and buff options
        textBox.SetActive(true);
    }

   public void ApplyBuff(string buffType)
{
    if (hasReceivedBuff) return; // If the buff has already been applied, do nothing

    // Code to apply the selected buff to the player
    switch(buffType)
    {
        case "Jump":
            characterController.IncreaseJumpHeight();
            break;
        case "Speed":
            characterController.IncreaseMovementSpeed();
            break;
    }

    // Hide the options panel after applying a buff
    textBox.SetActive(false);

    // Set the flag to indicate that the player has received a buff
    hasReceivedBuff = true;

    // Additionally, hide the interaction indicator as the buff has been received
    ShowInteractionIndicator(false);
}
}