using System;

public class Running : Activity
{
    private double _distanceKm;

    public Running(DateTime date, double lengthMinutes, double distanceKm)
        : base(date, lengthMinutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return _distanceKm;
    }

    public override double GetSpeed()
    {
        return (_distanceKm / _lengthMinutes) * 60;  // km/h
    }

    public override double GetPace()
    {
        return _lengthMinutes / _distanceKm;  // min/km
    }
}
