using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionBarGraphics : MonoBehaviour
{
    [SerializeField]
    private Transform startOfBar;
    [SerializeField]
    private Transform endOfBar;
    [SerializeField]
    private Transform teamAPos;
    [SerializeField]
    private Transform teamBPos;
    [SerializeField]
    private Transform charHolder;
    [SerializeField]
    private RectTransform bar;

    [SerializeField]
    private CharacterTokenGraphics tokemPrefab;

    private List<Character> actionQueue = new List<Character>();

    private int lowerLimitValue = 0;
    private int higherLimitValue = 100;
    private float barWidth;

    private float barSizeImPoints => (higherLimitValue - lowerLimitValue);

    private void Awake()
    {
        if (!bar)
        {
            throw new Exception("Bar Rect Transform Was not found");
        }

        barWidth = bar.rect.width;
    }

    public void UpdateBarLimits(int lowerLimit, int higherLimt)
    {
        lowerLimitValue = lowerLimit;
        higherLimitValue = higherLimt;
    }

    public void AddCharacterToQueue(Character character, Team team)
    {
        if (actionQueue.Contains(character))
        {
            return;
        }

        actionQueue.Add(character);

        InstantiateCharacterToken(character, team);

        OrderQueue();
    }

    private CharacterTokenGraphics InstantiateCharacterToken(Character character, Team team)
    {
        CharacterTokenGraphics characterGraphics = Instantiate(tokemPrefab);

        characterGraphics.transform.parent = charHolder;

        Vector3 desiredPos = GetTeamPosition(team);
        float barPos = GetPositionOnBar(character);

        characterGraphics.transform.position = new Vector3(startOfBar.position.x + barPos,
            desiredPos.y, characterGraphics.transform.position.z);

        return characterGraphics;
    }

    private float GetPositionOnBar(Character character)
    {
        return Mathf.Clamp(character.momentum / (barSizeImPoints), 0, 1) * barWidth;
    }

    private Vector3 GetTeamPosition(Team team)
    {
        return team switch
        {
            Team.Player => teamAPos.position,
            Team.Enemy => teamBPos.position,
            _ => throw new Exception("This team does not exit")
        };
    }

    private void OrderQueue()
    {
        actionQueue.Sort((Character char1, Character char2) => char1.momentum.CompareTo(char2.momentum));
    }
}
