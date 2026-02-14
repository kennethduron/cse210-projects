using System;

public abstract class Activity
{
    // Protected or private member variables
    protected DateTime _date;
    protected double _lengthMinutes;

    // Constructor
    public Activity(DateTime date, double lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    // Abstract methods for polymorphism
    public abstract double GetDistance();  // in km
    public abstract double GetSpeed();     // km/h
    public abstract double GetPace();      // min/km

    // Virtual method to get a summary of the activity
    public virtual string GetSummary()
    {
        return $"{_date.ToShortDateString()} ({GetType().Name}) - Duration: {_lengthMinutes} min, " +
               $"Distance: {GetDistance():0.00} km, Speed: {GetSpeed():0.00} km/h, Pace: {GetPace():0.00} min/km";
    }
}
