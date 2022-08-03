using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
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




    //[SerializeField] private Head _heads;
    //[SerializeField] private Transform _transform;
    //[SerializeField] private int _countHeads;

    //private int _secounds = 0;
    //private Transform[] _numbersOfHeads;

    //void Start()
    //{
    //    _numbersOfHeads = new Transform[_transform.childCount];

    //    for(int i = 0; i < _transform.childCount; i++)
    //    {
    //        _numbersOfHeads[i] = _transform.GetChild(i);
    //    }
    //}

    //private IEnumerator Spawnn()
    //{
    //    while (_countObject > _currentCountObject)
    //    {
    //        Instantiate(_enemy, _points[_currrentPoint].position, Quaternion.identity);
    //        _currentCountObject++;
    //        _currrentPoint++;

    //        if (_currrentPoint >= _points.Length)
    //        {
    //            _currrentPoint = 0;
    //        }

    //        yield return new WaitForSeconds(_delay);
    //    }
    //    // Update is called once per frame
    //    void Update()
    //{
    //    _secounds++;

    //    if(_secounds == 2)
    //    {
    //        Instantiate(_heads, _numbersOfHeads[_currrentPoint].position, Quaternion.identity);
    //    }
    //}
}
