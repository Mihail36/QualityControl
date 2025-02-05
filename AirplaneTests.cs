using Xunit;
using System;
public class AirplaneTests
{
    [Fact]
    public void TestSetModel()
    {
        // Arrange
        var airplane = new Airplane("Boeing 747", 1000, 400);

        // Act
        airplane.SetModel("Airbus A380");

        // Assert
        Assert.Equal("Airbus A380", airplane.GetModel());
    }

    [Fact]
    public void TestSetMaxSpeed()
    {
        // Arrange
        var airplane = new Airplane("Boeing 747", 1000, 400);

        // Act
        airplane.SetMaxSpeed(1200);

        // Assert
        Assert.Equal(1200, airplane.GetMaxSpeed());
    }

    [Fact]
    public void TestSetPassengers()
    {
        // Arrange
        var airplane = new Airplane("Boeing 747", 1000, 400);

        // Act
        airplane.SetPassengers(500);

        // Assert
        Assert.Equal(500, airplane.GetPassengers());
    }

    [Fact]
    public void TestAccelerateBeyondMaxSpeed()
    {
        // Arrange
        var airplane = new Airplane("Boeing 747", 1000, 400);
        airplane.StartEngine();

        // Act
        airplane.Accelerate(1100);

        // Assert
        Assert.Equal(1000, airplane.GetCurrentSpeed());
    }

    [Fact]
    public void TestDecelerateBelowZero()
    {
        // Arrange
        var airplane = new Airplane("Boeing 747", 1000, 400);
        airplane.StartEngine();
        airplane.Accelerate(100);

        // Act
        airplane.Decelerate(200);

        // Assert
        Assert.Equal(0, airplane.GetCurrentSpeed());
    }

    [Fact]
    public void TestStartEngine()
    {
        // Arrange
        var airplane = new Airplane("Boeing 747", 1000, 400);

        // Act
        airplane.StartEngine();

        // Assert
        Assert.True(airplane.IsEngineOn());
    }

    [Fact]
    public void TestStopEngine()
    {
        // Arrange
        var airplane = new Airplane("Boeing 747", 1000, 400);
        airplane.StartEngine();

        // Act
        airplane.StopEngine();

        // Assert
        Assert.False(airplane.IsEngineOn());
    }

    [Fact]
    public void TestAccelerate()
    {
        // Arrange
        var airplane = new Airplane("Boeing 747", 1000, 400);
        airplane.StartEngine();

        // Act
        airplane.Accelerate(400);

        // Assert
        Assert.True(airplane.IsInFlight());
        Assert.Equal(400, airplane.GetCurrentSpeed());
    }

    [Fact]
    public void TestDecelerate()
    {
        // Arrange
        var airplane = new Airplane("Boeing 747", 1000, 400);
        airplane.StartEngine();
        airplane.Accelerate(400);

        // Act
        airplane.Decelerate(400);

        // Assert
        Assert.False(airplane.IsInFlight());
        Assert.Equal(0, airplane.GetCurrentSpeed());
    }

    [Fact]
    public void TestAccelerateWithEngineOff()
    {
        // Arrange
        var airplane = new Airplane("Boeing 747", 1000, 400);

        // Act
        airplane.Accelerate(400);

        // Assert
        Assert.False(airplane.IsInFlight());
        Assert.Equal(0, airplane.GetCurrentSpeed());
    }

    [Fact]
    public void TestDecelerateWithEngineOff()
    {
        // Arrange
        var airplane = new Airplane("Boeing 747", 1000, 400);

        // Act
        airplane.Decelerate(400);

        // Assert
        Assert.False(airplane.IsInFlight());
        Assert.Equal(0, airplane.GetCurrentSpeed());
    }
   
    [Fact]
    public void TestMethodInteraction()
    {
        // Arrange
        var airplane = new Airplane("Boeing 747", 1000, 400);

        // Act
        airplane.StartEngine();
        airplane.Accelerate(400);
        airplane.Decelerate(400);
        airplane.StopEngine();

        // Assert
        Assert.False(airplane.IsEngineOn());
        Assert.False(airplane.IsInFlight());
        Assert.Equal(0, airplane.GetCurrentSpeed());
    }
}