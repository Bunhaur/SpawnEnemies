using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class Timer : MonoBehaviour
{
    private Text _text;
    private Coroutine _timeLeft;

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.color = Color.yellow;
        _timeLeft = StartCoroutine(TimeLeft());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
            StopCoroutine(_timeLeft);
    }

    private IEnumerator TimeLeft()
    {
        int timeLeft = 0;
        int timeWait = 1;

        while (true)
        {
            _text.text = timeLeft.ToString();
            timeLeft++;
            yield return new WaitForSecondsRealtime(timeWait);
        }
    }
}