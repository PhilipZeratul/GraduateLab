using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerMovement : MonoBehaviour
{
	public float speed = 1.2f;
    public const float inputHoldDelay = 0.5f;
    public bool interactionFinished = false;

	private bool isMouseClickedWalking = false;
    private bool handleInput = true;
	private Animator walkAnimator;
    private Interactable currentInteractable = null;
    private Vector3 destinationPosition;
    private WaitForSeconds inputHoldWait;

    private readonly int hashSpeedPara = Animator.StringToHash("Speed");
    private readonly int hashLocomotionTag = Animator.StringToHash("Locomotion");

    private void Awake()
	{
		walkAnimator = GetComponent<Animator>();
        inputHoldWait = new WaitForSeconds(inputHoldDelay);
	}

	private void Update()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		if (h != 0 || v != 0)
			KeyBoardMove(h, v);
        else if (isMouseClickedWalking)
            MouseMove();
        else
			Stop();
    }

	private void KeyBoardMove(float h, float v)
	{
        if (!handleInput)
            return;

        walkAnimator.SetFloat(hashSpeedPara, 2.0f);

        if (walkAnimator.GetCurrentAnimatorStateInfo(0).tagHash != hashLocomotionTag)
            return;

        isMouseClickedWalking = false;
        currentInteractable = null;

        if (h > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            h = -h;
        }
        else if (h < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        transform.Translate(h*speed*Time.deltaTime, v*speed*Time.deltaTime, 0.0f);
		
	}

    private void MouseMove()
    {
        walkAnimator.SetFloat(hashSpeedPara, 2.0f);

        if (walkAnimator.GetCurrentAnimatorStateInfo(0).tagHash != hashLocomotionTag)
            return;

        if (Vector2.Distance(transform.position, destinationPosition) < 0.1f)
        {
            isMouseClickedWalking = false;            
            return;
        }
        if (destinationPosition.x > transform.position.x)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if (destinationPosition.x < transform.position.x)
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, speed*Time.deltaTime);        
    }

	private void Stop()
	{
        isMouseClickedWalking = false;
		walkAnimator.SetFloat(hashSpeedPara, 0.0f);
        
        if (currentInteractable)
        {
            // ... set the player's rotation to match the interactionLocation's.
            transform.rotation = currentInteractable.interactionLocation.rotation;

            // Interact with the interactable and then null it out so this interaction only happens once.
            currentInteractable.Interact();
            currentInteractable = null;

            // Start the WaitForInteraction coroutine so that input is ignored briefly.
            StartCoroutine(WaitForInteraction());
        }
    }

    public void OnGroundClick(BaseEventData data)
    {
        if (!handleInput)
            return;

        currentInteractable = null;

        PointerEventData pData = (PointerEventData)data;
        destinationPosition = pData.pointerCurrentRaycast.worldPosition;
        isMouseClickedWalking = true;
        walkAnimator.SetFloat(hashSpeedPara, 0.0f);
    }

    public void OnInteractableClick(Interactable interactable)
    {
        if (!handleInput)
            return;

        currentInteractable = interactable;

        destinationPosition = interactable.interactionLocation.position;
        isMouseClickedWalking = true;
        walkAnimator.SetFloat(hashSpeedPara, 0.0f);
    }

    private IEnumerator WaitForInteraction()
    {
        // As soon as the wait starts, input should no longer be accepted.
        handleInput = false;

        // Wait for the normal pause on interaction.
        yield return inputHoldWait;

        // Until the animator is in a state with the Locomotion tag, wait.
        while (!interactionFinished)
        {
            yield return null;
        }

        Debug.Log("interactionFinished");
        // Now input can be accepted again.
        handleInput = true;
    }
}