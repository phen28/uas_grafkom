using UnityEngine;

public class LightObject : MonoBehaviour
{
    public GameObject targetLight;

    private bool isObjectActive = true;

    void Update()
    {
        // Turn off the target light when the 'O' key is pressed
        if (Input.GetKeyDown(KeyCode.O) && isObjectActive)
        {
            targetLight.SetActive(false);
            isObjectActive = false;
        }

        // Turn on the target light when the 'P' key is pressed
        if (Input.GetKeyDown(KeyCode.P) && !isObjectActive)
        {
            targetLight.SetActive(true);
            isObjectActive = true;
        }
    }
}

