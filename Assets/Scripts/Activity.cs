using UnityEngine;

[CreateAssetMenu(fileName = "Activities", menuName = "New Activity", order = 1)]
public class Activity : ScriptableObject
{
    public string activityName;
    public string desciption;
    public Sprite logo;
    public Sprite storefront;
    public string url;
    public CityInfo cityInfo;
    public ActivityHandler.ActivityType type;
}
