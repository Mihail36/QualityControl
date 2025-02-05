namespace AirplaneTests
{
    using Xunit;
    using Airplane;

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
            Assert.True("Airbus A380" == airplane.GetModel(),
                "Не удалось изменить название модели, фактическое - 'Boeing 747', ожидаемое - 'Airbus A380'");
        }

        [Fact]
        public void TestSetMaxSpeed()
        {
            // Arrange
            var airplane = new Airplane("Boeing 747", 1000, 400);

            // Act
            airplane.SetMaxSpeed(1200);

            // Assert
            Assert.True(1200 == airplane.GetMaxSpeed(),
                "Не удалось изменить скорость модели, фактическое - '1000', ожидаемое - '1200'");
        }

        [Fact]
        public void TestSetPassengers()
        {
            // Arrange
            var airplane = new Airplane("Boeing 747", 1000, 400);

            // Act
            airplane.SetPassengers(500);

            // Assert
            Assert.True(500 == airplane.GetPassengers(),
                "Не удалось изменить количество пассажиров модели, фактическое - '400', ожидаемое - '500'");
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
            Assert.True(1000 == airplane.GetCurrentSpeed(),
                "Не удалось установить фиксацию скорости при увеличении его выше максимальной скорости, фактическое - 'currentSpeed = 0', " +
                "ожидаемое - 'currerntSpeed = 1000'");
        }

        [Fact]
        public void TestDecelerateBelowZero()
        {
            // Arrange
            var airplane = new Airplane("Boeing 747", 1000, 400);
            airplane.StartEngine();

            // Act
            airplane.Decelerate(500);

            // Assert
            Assert.True(0 == airplane.GetCurrentSpeed(),
                "Не удалось установить фиксацию скорости при уменьшении его ниже нуля, фактическое - 'currentSpeed = 0', ожидаемое - " +
                "'currentSpeed = 0'");
        }

        [Fact]
        public void TestStartEngine()
        {
            // Arrange
            var airplane = new Airplane("Boeing 747", 1000, 400);

            // Act
            airplane.StartEngine();

            // Assert
            Assert.True(airplane.IsEngineOn(),
                "Не удалось установить статус включенного двигателя, фактическое - 'engineState = false ', ожидаемое - 'engineState = true'");
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
            Assert.False(airplane.IsEngineOn(),
                "Не удалось установить статус выключенного двигателя, фактическое - 'engineState = true ', ожидаемое - 'engineState = false'");
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
            Assert.True(airplane.IsInFlight(),
                "Не удалось установить статус полета самолета, фактическое - 'inFlight = false ', ожидаемое - 'inFlight = true'");
            Assert.True(400 == airplane.GetCurrentSpeed(),
                "Не удалось установить скорость текущей модели, фактическое - 'currentSpeed = 0', ожидаемое - 'currentSpeed = 400'");
        }

        [Fact]
        public void TestDecelerate()
        {
            // Arrange
            var airplane = new Airplane("Boeing 747", 1000, 400);
            airplane.StartEngine();

            // Act
            airplane.Decelerate(400);

            // Assert
            Assert.False(airplane.IsInFlight(),
                "Не удалось установить статус полета самолета, фактическое - 'inFlight = true ', ожидаемое - 'inFlight = false'");
            Assert.True(0 == airplane.GetCurrentSpeed(),
                "Не удалось установить скорость текущей модели, фактическое - 'currentSpeed = 0', ожидаемое - 'currentSpeed = 0'");
        }

        [Fact]
        public void TestAccelerateWithEngineOff()
        {
            // Arrange
            var airplane = new Airplane("Boeing 747", 1000, 400);

            // Act
            airplane.Accelerate(400);

            // Assert
            Assert.False(airplane.IsInFlight(),
                "Не удалось установить статус полета самолета, фактическое - 'inFlight = false ', ожидаемое - 'inFlight = false'");
            Assert.True(0 == airplane.GetCurrentSpeed(),
                "Не удалось установить скорость текущей модели, фактическое - 'currentSpeed = 0', ожидаемое - 'currentSpeed = 0'");
        }

        [Fact]
        public void TestDecelerateWithEngineOff()
        {
            // Arrange
            var airplane = new Airplane("Boeing 747", 1000, 400);

            // Act
            airplane.Decelerate(400);

            // Assert
            Assert.False(airplane.IsInFlight(),
                "Не удалось установить статус полета самолета, фактическое - 'inFlight = false ', ожидаемое - 'inFlight = false'");
            Assert.True(0 == airplane.GetCurrentSpeed(),
                "Не удалось установить скорость текущей модели, фактическое - 'currentSpeed = 0', ожидаемое - 'currentSpeed = 0'");
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
            Assert.False(airplane.IsEngineOn(),
                "Не удалось установить статус выключенного двигателя, фактическое - 'engineState = false ', ожидаемое - 'engineState = false'");
            Assert.False(airplane.IsInFlight(),
                "Не удалось установить статус полета самолета, фактическое - 'inFlight = false ', ожидаемое - 'inFlight = false'");
            Assert.True(0 == airplane.GetCurrentSpeed(),
                "Не удалось установить скорость текущей модели, фактическое - '0', ожидаемое - '0'");
        }
    }
}