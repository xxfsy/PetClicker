using System.Collections;
using UnityEngine;

public class TickService : BaseTickService
{
    [SerializeField] private float _tickIntervalInSeconds = 1f; // частота тика TickAll

    private WaitForSeconds _tickInterval;
    private Coroutine _tickRoutine;

    private void OnEnable()
    {
        _tickInterval = new WaitForSeconds(_tickIntervalInSeconds);
        _tickRoutine = StartCoroutine(TickRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(_tickRoutine);
    }

    private IEnumerator TickRoutine()
    {
        while (true)
        {
            TickAll(_tickIntervalInSeconds);
            yield return _tickInterval;
        }
    }
}
