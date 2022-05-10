using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoverCsharp;

namespace TestProject1;

[TestClass]
public class RoverTestClass
{
    private Rover _target = null!;
    private Random _random;

    [TestInitialize]
    public void RoverTestSetUp()
    {
        _target = new Rover();
        _random = new Random();
    }

    [TestMethod]
    public void ExecuteGivenEmptyStringReturnsStartingLocation()
    {
        var position = _target.Execute("");
        Assert.AreEqual("0:0:N", position);
    }

    [TestMethod]
    public void ExecuteGivenMoveCommandMovesNorthOneStep()
    {
        var position = _target.Execute("M");
        Assert.AreEqual("0:1:N", position);
    }

    [TestMethod]
    public void ExecuteGivenMultipleCommandsMovesNorthSameNumberOfSteps()
    {
        const int rollOver = 10;
        var numberOfMoveCommands = _random.Next(0, 100);
        var commandString = "";
        for (var i = 0; i < numberOfMoveCommands; i++)
        {
            commandString += "M";
        }

        var expectedPosition = "0:" + numberOfMoveCommands % rollOver + ":N";

        var position = _target.Execute(commandString);
        
        Assert.AreEqual(expectedPosition, position);
    }
}