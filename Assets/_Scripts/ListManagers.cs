using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "GameManager/ListManager")]
public class ListManagers : ScriptableObject
{
    [Header("Lists")]
    public List<GameGenera> ListofGeneras;
    public int Popularity;

    [Header("Optinal Lists")]
    public List<string> Characters;
    public List<string> Themes;
    public List<string> Goals;
    public List<string> Addational;
}
[System.Serializable]
public class GameGenera
{
    public string Genera;
    public bool hasSubGenera;
    public GameSubGenera[] ListofSubGeneras;

    public GameGenera(string g , bool hsG , GameSubGenera[] list = null)
    {
        Genera = g;
        hasSubGenera = hsG;
        ListofSubGeneras = list;
    }
}

[System.Serializable]
public class GameSubGenera
{
    public string SubGeneras;
    [Space(12f)]
    public string[] Examples;
}