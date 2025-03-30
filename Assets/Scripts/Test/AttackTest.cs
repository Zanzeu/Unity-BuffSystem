using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTest : MonoBehaviour
{
    private ComboSystem _comboSystem;

    private void Awake()
    {
        _comboSystem = gameObject.AddComponent<ComboSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _comboSystem.RecordCombo();
            Debug.Log("¹¥»÷!");
        }
    }
}
