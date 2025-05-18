using System.Collections;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;

    private WaitForSeconds _waitTime = new WaitForSeconds(0.5f);
    private Counter _counter = new Counter();
    private Coroutine _counterCoroutine = null;
    private bool _isCounting = false;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
            {
                StopCounter();
            }
            else
            {
                StartCounter();
            }
        }
    }

    private void StartCounter()
    {
        if (_counterCoroutine == null)
        {
            _isCounting = true;
            _counterCoroutine = StartCoroutine(UpdateCounter());
        }
    }

    private void StopCounter()
    {
        if (_counterCoroutine != null)
        {
            StopCoroutine(_counterCoroutine);
            _counterCoroutine = null;
            _isCounting = false;
        }
    }

    private IEnumerator UpdateCounter()
    {
        while (true)
        {
            yield return _waitTime;

            if (_counterText != null)
            {
                _counter.Increment();
                _counterText.text = "Count: " + _counter.Count;
            }
        }
    }
}
