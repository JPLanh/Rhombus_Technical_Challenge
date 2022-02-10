using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipPassive : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 45f;
    private IEnumerator startMovement;
    private IEnumerator endMovement;
    // Start is called before the first frame update
    void Start()
    {
        startMovement = enterPosition(new Vector3(0f, 2.5f, 1f), 3);
        endMovement = exitPosition(2);
        StartCoroutine(startMovement);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }


    IEnumerator enterPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.parent.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.parent.transform.position = targetPosition;
    }

    public void exit()
    {
        StopCoroutine(startMovement);
        StartCoroutine(endMovement);

    }

    IEnumerator exitPosition(float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.parent.transform.position = Vector3.Lerp(startPosition, new Vector3(0f, 5f, 50f), time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.parent.transform.position = new Vector3(0f, 5f, 50f);
        Destroy(transform.parent.gameObject);
    }
}
