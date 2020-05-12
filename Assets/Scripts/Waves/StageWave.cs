using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class StageWave : ScriptableObject
{
    private bool _canContinue = false;

    public bool CanContinue { get => _canContinue; set => _canContinue = value; }
}
