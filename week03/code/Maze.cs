using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX;
    private int _currY;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
        _currX = 1;
        _currY = 1;
    }

    public void MoveLeft()
    {
        var currentSpot = (_currX, _currY);
        if (_mazeMap.ContainsKey(currentSpot) && _mazeMap[currentSpot][0])
        {
            _currX--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveRight()
    {
        var currentSpot = (_currX, _currY);
        if (_mazeMap.ContainsKey(currentSpot) && _mazeMap[currentSpot][1])
        {
            _currX++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveUp()
    {
        var currentSpot = (_currX, _currY);
        if (_mazeMap.ContainsKey(currentSpot) && _mazeMap[currentSpot][2])
        {
            _currY--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveDown()
    {
        var currentSpot = (_currX, _currY);
        if (_mazeMap.ContainsKey(currentSpot) && _mazeMap[currentSpot][3])
        {
            _currY++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}