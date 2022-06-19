namespace MarsRover.Test;

public class MarsRoverShould
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("M", "0:1:N")]
    [TestCase("MM", "0:2:N")]
    [TestCase("MMM", "0:3:N")]
    [TestCase("MR", "0:1:E")]
    [TestCase("MRM", "1:1:E")]
    [TestCase("MRMM", "2:1:E")]
    [TestCase("MRMMM", "3:1:E")]
    [TestCase("MRMMMR", "3:1:S")]
    [TestCase("MRMMMRM", "3:0:S")]
    [TestCase("MRMMMRMR", "3:0:W")]
    [TestCase("MRMMMRMRM", "2:0:W")]
    [TestCase("MRMMMRMRMM", "1:0:W")]
    [TestCase("MRMMMRMRMMM", "0:0:W")]
    [TestCase("MRMMMRMRMMMM", "0:0:W")]
    [TestCase("MRMMMRMRMMMM", "0:0:W")]
    [TestCase("MRMMMRMRMMMMRRR", "0:0:S")]
    [TestCase("MRMMMRMRMMMMRRRM", "0:0:S")]
    public void MoveRover(string moveCommands, string expected)
    {
        var finalPosition = new MarsRover().MoveRover(moveCommands);
        Assert.That(finalPosition, Is.EqualTo(expected));
    }
}