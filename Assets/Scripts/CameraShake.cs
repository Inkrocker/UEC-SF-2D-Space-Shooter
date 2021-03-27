using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator CameraShakeRoutine(float duration, float strength)
    {
        Vector3 defaultCamPos = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float xPos = Random.Range(-0.4f, 0.4f) * strength;
            float yPos = Random.Range(-0.4f, 0.4f) * strength;
            float zPos = Random.Range(-0.8f, 0.8f) * strength;

            transform.localPosition = new Vector3(xPos, yPos, zPos);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = defaultCamPos;

    }
}
