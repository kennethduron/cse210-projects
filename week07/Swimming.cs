using System;

public class Swimming : Activity
{
    private int _laps;
    private double _lapDistanceMeters = 50; // 50 meters per lap

    public Swimming(DateTime date, double lengthMinutes, int laps)
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * _lapDistanceMeters) / 1000.0; // convert meters to km
    }

    public override double GetSpeed()
    {
        return (GetDistance() / _lengthMinutes) * 60; // km/h
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        return distance > 0 ? _lengthMinutes / distance : 0; // min/km
    }
}
