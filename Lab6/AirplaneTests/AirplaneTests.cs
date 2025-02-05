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
                "�� ������� �������� �������� ������, ����������� - 'Boeing 747', ��������� - 'Airbus A380'");
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
                "�� ������� �������� �������� ������, ����������� - '1000', ��������� - '1200'");
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
                "�� ������� �������� ���������� ���������� ������, ����������� - '400', ��������� - '500'");
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
                "�� ������� ���������� �������� �������� ��� ���������� ��� ���� ������������ ��������, ����������� - 'currentSpeed = 0', " +
                "��������� - 'currerntSpeed = 1000'");
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
                "�� ������� ���������� �������� �������� ��� ���������� ��� ���� ����, ����������� - 'currentSpeed = 0', ��������� - " +
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
                "�� ������� ���������� ������ ����������� ���������, ����������� - 'engineState = false ', ��������� - 'engineState = true'");
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
                "�� ������� ���������� ������ ������������ ���������, ����������� - 'engineState = true ', ��������� - 'engineState = false'");
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
                "�� ������� ���������� ������ ������ ��������, ����������� - 'inFlight = false ', ��������� - 'inFlight = true'");
            Assert.True(400 == airplane.GetCurrentSpeed(),
                "�� ������� ���������� �������� ������� ������, ����������� - 'currentSpeed = 0', ��������� - 'currentSpeed = 400'");
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
                "�� ������� ���������� ������ ������ ��������, ����������� - 'inFlight = true ', ��������� - 'inFlight = false'");
            Assert.True(0 == airplane.GetCurrentSpeed(),
                "�� ������� ���������� �������� ������� ������, ����������� - 'currentSpeed = 0', ��������� - 'currentSpeed = 0'");
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
                "�� ������� ���������� ������ ������ ��������, ����������� - 'inFlight = false ', ��������� - 'inFlight = false'");
            Assert.True(0 == airplane.GetCurrentSpeed(),
                "�� ������� ���������� �������� ������� ������, ����������� - 'currentSpeed = 0', ��������� - 'currentSpeed = 0'");
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
                "�� ������� ���������� ������ ������ ��������, ����������� - 'inFlight = false ', ��������� - 'inFlight = false'");
            Assert.True(0 == airplane.GetCurrentSpeed(),
                "�� ������� ���������� �������� ������� ������, ����������� - 'currentSpeed = 0', ��������� - 'currentSpeed = 0'");
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
                "�� ������� ���������� ������ ������������ ���������, ����������� - 'engineState = false ', ��������� - 'engineState = false'");
            Assert.False(airplane.IsInFlight(),
                "�� ������� ���������� ������ ������ ��������, ����������� - 'inFlight = false ', ��������� - 'inFlight = false'");
            Assert.True(0 == airplane.GetCurrentSpeed(),
                "�� ������� ���������� �������� ������� ������, ����������� - '0', ��������� - '0'");
        }
    }
}