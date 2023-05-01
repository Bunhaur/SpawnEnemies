using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class ChangeTextColor : MonoBehaviour
{
    private Text _text;
    private IEnumerator _changeColor;

    private void Start()
    {
        _text = GetComponent<Text>();
        _changeColor = ChangeColor();
        StartCoroutine(_changeColor);
    }

    IEnumerator ChangeColor()
    {
        int waitTime = 1;

        _text.text = $"\"ESC\" - Stop spawn\n\n\"F\" - Stop timer.";

        while (Input.GetKey(KeyCode.Escape) == false)
        {
            _text.color = Color.red;
            yield return new WaitForSecondsRealtime(waitTime);
            _text.color = Color.green;
            yield return new WaitForSecondsRealtime(waitTime);
        }
    }
}