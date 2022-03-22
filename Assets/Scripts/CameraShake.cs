using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Camera>();
    }

    public IEnumerator Shake(float duration, float magnitude,AnalogGlitch anal)
    {
        Vector3 originalPos = new Vector3(0,0,-10);
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            anal.colorDrift = 1f;
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            Camera.transform.position = originalPos + new Vector3(xOffset, yOffset, originalPos.z);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.position = originalPos;
    }
}
