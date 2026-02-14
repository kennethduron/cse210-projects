using System;

public class Cycling : Activity
{
    private double _speedKmh;

    public Cycling(DateTime date, double lengthMinutes, double speedKmh)
        : base(date, lengthMinutes)
    {
        _speedKmh = speedKmh;
    }

    public override double GetDistance()
    {
        return _speedKmh * (_lengthMinutes / 60);  // distance = speed * time in hours
    }

    public override double GetSpeed()
    {
        return _speedKmh;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        return distance > 0 ? _lengthMinutes / distance : 0;  // min/km
    }
}
