using UnityEngine;

public class AnimationCompleteChecker : MonoBehaviour
{
    Animator animator;
    private bool hasTriggered;
    public GameObject createBlock;
    public GameManager gameManager;
    bool isResume;
    public AutoCreate autoCreate;
    float preserveRelativeSpeed;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        hasTriggered = false;
        isResume = false;
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !animator.IsInTransition(0))
        {
            if (!hasTriggered)
            {
                OnAnimationComplete();
                hasTriggered = true;
            }
        }
        else
        {
            hasTriggered = false; // Reset the flag if the animation is still playing or has transitioned to another state
        }
    }

    private void OnAnimationComplete()
    {
        Debug.Log("Animation Complete!");
       
        if (!isResume)
        {
            OnStarting();
        }

        else if (isResume)
        {
            autoCreate.relativeSpeed = preserveRelativeSpeed;
            Debug.Log($"Preserved relative speed is {preserveRelativeSpeed}");
            isResume = false;
        }

        gameObject.SetActive(false);
    }

    void OnStarting()
    {
        createBlock.SetActive(true);
    }

    public void OnResuming()
    {
        isResume = true;
        preserveRelativeSpeed = autoCreate.relativeSpeed;
        autoCreate.relativeSpeed = 0;
        gameManager.ResumeGame();
        
    }
}
