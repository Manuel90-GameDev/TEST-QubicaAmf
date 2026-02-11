[System.Serializable]
public struct LocationData
{
    public float latitude;
    public float longitude;

    public LocationData(float lat, float lon)
    {
        latitude = lat;
        longitude = lon;
    }
}