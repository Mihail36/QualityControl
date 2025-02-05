using System;

public class Airplane
{
    private string model;
    private int maxSpeed;
    private int passengers;
    private int currentSpeed;
    private bool inFlight;
    private bool engineState;

    public Airplane(string model, int maxSpeed, int passengers)
    {
        this.model = model;
        this.maxSpeed = maxSpeed;
        this.passengers = passengers;
        this.currentSpeed = 0;
        this.inFlight = false;
        this.engineState = false;
    }

    public void SetModel(string model)
    {
        this.model = model;
    }

    public void SetMaxSpeed(int maxSpeed)
    {
        this.maxSpeed = maxSpeed;
    }

    public void SetPassengers(int passengers)
    {
        this.passengers = passengers;
    }

    public string GetModel()
    {
        return model;
    }

    public int GetMaxSpeed()
    {
        return maxSpeed;
    }

    public int GetPassengers()
    {
        return passengers;
    }

    public int GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public bool IsInFlight()
    {
        return inFlight;
    }

    public bool IsEngineOn()
    {
        return engineState;
    }

    public void StartEngine()
    {
        engineState = true;
        Console.WriteLine("Engine started.");
    }

    public void StopEngine()
    {
        engineState = false;
        Console.WriteLine("Engine stopped.");
    }

    public void Accelerate(int speedIncrease)
    {
        if (!engineState)
        {
            Console.WriteLine("Engine is off. Cannot accelerate.");
            return;
        }
        currentSpeed += speedIncrease;
        if (currentSpeed > maxSpeed / 3 && !inFlight)
        {
            inFlight = true;
            Console.WriteLine("The airplane has taken off.");
        }
        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }
    }

    public void Decelerate(int speedDecrease)
    {
        if (!engineState)
        {
            Console.WriteLine("Engine is off. Cannot decelerate.");
            return;
        }
        currentSpeed -= speedDecrease;
        if (currentSpeed <= maxSpeed / 3 && inFlight)
        {
            inFlight = false;
            Console.WriteLine("The airplane has landed.");
        }
        if (currentSpeed < 0)
        {
            currentSpeed = 0;
        }
    }
}