using UnityEngine;

[CreateAssetMenu(fileName = "Cities", menuName = "New City", order = 1)]
public class CityInfo : ScriptableObject
{
    public string cityName;
    public string description;
    public Sprite coatOfArms;
}
