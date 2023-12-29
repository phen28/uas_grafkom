using System.Collections;
using UnityEngine;

public class ChangeTargetCam : MonoBehaviour
{
    public GameObject target;
    private Vector3 initialCameraPosition;
    private Quaternion initialCameraRotation;
    private bool isResetting = false;

    void Start()
    {
        initialCameraPosition = new Vector3(0, 0, -15);
        initialCameraRotation = Quaternion.identity;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            AdjustCamera();
        }

        if (Input.GetKeyDown(KeyCode.R) && !isResetting)
        {
            StartCoroutine(ResetCameraCoroutine());
        }
    }

    void AdjustCamera()
    {
        TargetCam.target = target;
        Camera.main.fieldOfView = Mathf.Clamp(60 * target.transform.localScale.x, 1, 30);
    }

    IEnumerator ResetCameraCoroutine()
    {
        isResetting = true;
        TargetCam.target = null;

        Vector3 currentPos = Camera.main.transform.position;
        Quaternion currentRot = Camera.main.transform.rotation;

        float elapsedTime = 0f;
        float resetTime = 1.0f; // Adjust the time as needed

        while (elapsedTime < resetTime)
        {
            Camera.main.transform.position = Vector3.Lerp(currentPos, initialCameraPosition, elapsedTime / resetTime);
            Camera.main.transform.rotation = Quaternion.Lerp(currentRot, initialCameraRotation, elapsedTime / resetTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Camera.main.transform.position = initialCameraPosition;
        Camera.main.transform.rotation = initialCameraRotation;

        isResetting = false;
    }
}
