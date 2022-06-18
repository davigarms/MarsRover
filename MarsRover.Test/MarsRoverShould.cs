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
    [TestCase("MRMMMRMRMMMM", "9:0:W")]
    [TestCase("MRMMMRMRMMMML", "9:0:S")]
    [TestCase("MRMMMRMRMMMMLM", "9:9:S")]
    [TestCase("MRMMMRMRMMMMLMRRM", "9:0:N")]
    [TestCase("MMRMMLM", "2:3:N")]
    [TestCase("MMMMMMMMMM", "0:0:N")]
    public void MoveRover(string moveCommands, string expected)
    {
        var finalPosition = new MarsRover().MoveRover(moveCommands);
        Assert.That(finalPosition, Is.EqualTo(expected));
    }
}