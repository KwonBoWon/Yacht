using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICard
{
    void CreateCard();
    void PlayCard();
    void DestroyCard();
}

public class SimpleCard : ICard
{
    public void CreateCard()
    {
        Debug.Log("Create");
    }
    public void PlayCard()
    {
        Debug.Log("Play");
    }
    public void DestroyCard()
    {
        Debug.Log("Destroy");
    }
}

public class AbilityCard : ICard
{
    public void CreateCard()
    {
        Debug.Log("Create");
    }
    public void PlayCard()
    {
        Debug.Log("Play");
        Debug.Log("Ability");
        
    }
    public void DestroyCard()
    {
        Debug.Log("Destroy");
    }
}

public interface ICardFactory
{
    ICard CreateCard();
}

public class SimpleCardFactory : ICardFactory
{
    public ICard CreateCard()
    {
        return new SimpleCard();
    }
}

public class AbilityCardFactory : ICardFactory
{
    public ICard CreateCard()
    {
        return new AbilityCard();
    }
}

public class CardFactory : MonoBehaviour
{
    private void Start()
    {
        ICardFactory simpleCardFactory = new SimpleCardFactory();
        ICardFactory abilityCardFactory = new AbilityCardFactory();

        
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ICard onePair = new SimpleCard();
            onePair.CreateCard();
            onePair.PlayCard();
        }
        
    }
}
