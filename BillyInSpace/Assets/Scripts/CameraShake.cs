using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform target;
    public float rotationMultiplier = 1f;
    private float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, target.position.y, -10);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            ShakeCamera(.2f, .1f);
        }
    }
    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xShake = Random.Range(-1f, 1f) * shakePower;
            float yShake = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xShake, yShake, 0f);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);

            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);
        }

        transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));
    }

    public void ShakeCamera(float duration, float power)
    {
        shakeTimeRemaining = duration;
        shakePower = power;

        shakeFadeTime = power / duration;

        shakeRotation = power * rotationMultiplier;
    }
}
