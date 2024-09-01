using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ButtonAnimation : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(buttonAnimation);
        }
        else
        {
            Debug.LogError("Button component not found on this GameObject.");
        }
    }

    private void buttonAnimation()
    {
        StartCoroutine(AnimateButton());
    }

    private IEnumerator AnimateButton()
    {
        Vector3 originalScale = gameObject.transform.localScale;
        Vector3 targetScale = originalScale + new Vector3(0.2f, 0.2f, 0.2f);

        float duration = 0.2f; // Duration of the animation
        float elapsedTime = 0f;

        // Scale up
        while (elapsedTime < duration)
        {
            gameObject.transform.localScale = Vector3.Lerp(originalScale, targetScale, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameObject.transform.localScale = targetScale;

        // Wait a moment
        yield return new WaitForSeconds(0.1f);

        // Scale down
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            gameObject.transform.localScale = Vector3.Lerp(targetScale, originalScale, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameObject.transform.localScale = originalScale;
    }
}
