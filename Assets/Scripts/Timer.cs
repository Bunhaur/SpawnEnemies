using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class Timer : MonoBehaviour
{
    private Text _text;
    private IEnumerator _timeLeft;

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.color = Color.yellow;
        _timeLeft = TimeLeft();

        StartCoroutine(_timeLeft);
    }

    IEnumerator TimeLeft()
    {
        int timeLeft = 0;
        int waitTime = 1;

        while (true)
        {
            _text.text = timeLeft.ToString();
            timeLeft++;
            yield return new WaitForSecondsRealtime(waitTime);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            StopCoroutine(_timeLeft );
        }
    }
}