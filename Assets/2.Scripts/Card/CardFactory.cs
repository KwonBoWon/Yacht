using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ICard
{
    void PlayCard();
    void DestroyCard();
}

public class SimpleCard : ICard
{
    public SimpleCard(Cardd cardd)
    {
        
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
    public AbilityCard(Cardd cardd)
    {
        
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
    ICard CreateCard(Cardd cardd);
}

public class SimpleCardFactory : ICardFactory
{
    public ICard CreateCard(Cardd cardd)
    {
        return new SimpleCard(cardd);
    }
}

public class AbilityCardFactory : ICardFactory
{
    public ICard CreateCard(Cardd cardd)
    {
        return new AbilityCard(cardd);
    }
}

public class CardFactory : MonoBehaviour
{
    public CardDataParse cardDataParse;
    public Deck deckData;
    public Cardd nowCardd;
    public int cardIndex;
    public ICard nowCard;
    ICardFactory simpleCardFactory = new SimpleCardFactory();
    ICardFactory abilityCardFactory = new AbilityCardFactory();
    
    public GameObject CardPrefab;
    
    
    private void Start()
    {
        cardIndex = 0;
        simpleCardFactory = new SimpleCardFactory();
        abilityCardFactory = new AbilityCardFactory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            //ICard onePair = simpleCardFactory.CreateCard();
        }
        
    }

    public void CardDraw()
    {
        if (cardIndex >= deckData.deck.Count)
        {
            nowCardd = deckData.deck[cardIndex];
            cardIndex++;

            
        }
        else
        {
            // TODO:GameEnd
        }

    }
    
    
}
