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

    private const char CharLose = 'X';
    private const char CharDraw = 'Y';
    private const char CharWin = 'Z';

    [Theory]
    [InlineData(MyRock, OpponentRock, PointsDraw)]
    [InlineData(MyRock, OpponentPaper, PointsLose)]
    [InlineData(MyRock, OpponentScissors, PointsWin)]

    [InlineData(MyPaper, OpponentRock, PointsWin)]
    [InlineData(MyPaper, OpponentPaper, PointsDraw)]
    [InlineData(MyPaper, OpponentScissors, PointsLose)]

    [InlineData(MyScissors, OpponentRock, PointsLose)]
    [InlineData(MyScissors, OpponentPaper, PointsWin)]
    [InlineData(MyScissors, OpponentScissors, PointsDraw)]
    public void GetRoundPointsTest(char myHand, char opponentsHand, int points)
    {
        Assert.Equal(points, Day2.GetRoundPoints(myHand, opponentsHand));
    }

    [Theory]
    [InlineData(OpponentRock, CharLose, MyScissors)]
    [InlineData(OpponentRock, CharDraw, MyRock)]
    [InlineData(OpponentRock, CharWin, MyPaper)]

    [InlineData(OpponentPaper, CharLose, MyRock)]
    [InlineData(OpponentPaper, CharDraw, MyPaper)]
    [InlineData(OpponentPaper, CharWin, MyScissors)]

    [InlineData(OpponentScissors, CharLose, MyPaper)]
    [InlineData(OpponentScissors, CharDraw, MyScissors)]
    [InlineData(OpponentScissors, CharWin, MyRock)]
    public void GetMineTest(char opponentsHand, char output, char myHand)
    {
        Assert.Equal(myHand, Day2.GetMine(opponentsHand, output));
    }

    [Fact]
    public void GetHandPointsTest()
    {
        Assert.Equal(1, Day2.GetHandPoints(MyRock));
        Assert.Equal(2, Day2.GetHandPoints(MyPaper));
        Assert.Equal(3, Day2.GetHandPoints(MyScissors));
    }
}