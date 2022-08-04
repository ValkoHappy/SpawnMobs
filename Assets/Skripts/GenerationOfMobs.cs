using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationOfMobs : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _point;
    [SerializeField] private float _delay;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_point.childCount];

        for (int i = 0; i < _point.childCount; i++)
        {
            _points[i] = _point.GetChild(i);
        }

        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(_template, _points[i].position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}
