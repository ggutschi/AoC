using AoC2022.Days;

namespace AoC.Test;

public class Day2Tests
{
    private const int PointsLose = 0;
    private const int PointsDraw = 3;
    private const int PointsWin = 6;

    private const char OpponentRock = 'A';      // 0
    private const char OpponentPaper = 'B';     // 1
    private const char OpponentScissors = 'C';  // 2

    private const char MyRock = 'X';            // 0
    private const char MyPaper = 'Y';           // 1
    private const char MyScissors = 'Z';        // 2

    [Theory]
    [InlineData(MyRock, OpponentRock, PointsDraw)]
    [InlineData(MyRock, OpponentPaper, PointsLose)]
    [InlineData(MyRock, OpponentScissors, PointsWin)]

    [InlineData(MyPaper, OpponentRock, PointsWin)]
    [InlineData(MyPaper, OpponentPaper, PointsDraw)]
    [InlineData(MyPaper, OpponentScissors, PointsLose)]
    public void GetRoundPointsTest(char myHand, char opponentsHand, int points)
    {
        Assert.Equal(points, Day2.GetRoundPoints(myHand, opponentsHand));
    }

    [Fact]
    public void GetHandPointsTest()
    {
        Assert.Equal(1, Day2.GetHandPoints(MyRock));
        Assert.Equal(2, Day2.GetHandPoints(MyPaper));
        Assert.Equal(3, Day2.GetHandPoints(MyScissors));
    }
}