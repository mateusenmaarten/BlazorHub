using CAH.Backend.Classes;
using CAH.Backend.Factories;
using CAH.Backend.Interfaces;
using CAH.Data.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CAH.Testing;

public class IntegrationTest
{
    private IReader _reader;

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void TestGame()
    {
        GameFactory gameFactory = new GameFactory();

        Game game = gameFactory.CreateGame(CreateGamePlayers(CreatePlayers()));
        GameManager gameManager = game.GameManager; 

        gameManager.StartGame();

        PrintPlayerHands(game.GamePlayers);

        while(!gameManager.IsGameDone()) {

            gameManager.StartNewTurn();

            gameManager.HandleTurn();

            PrintPlayerHands(game.GamePlayers);

        }
       

        System.Diagnostics.Debug.WriteLine($"FIRST BLACKCARD SHOWN: {game.GameState.CurrentBlackCard.Text} with ID : {game.GameState.CurrentBlackCard.ID}");


    }

    private void onGameStateChanged(GameState gameState, Game game){

                System.Console.WriteLine("game state changed");
    }

    private void PrintPlayerHands(IEnumerable<IGamePlayer> players){
        foreach (var player in players)
        {
            System.Diagnostics.Debug.WriteLine($"{player.Player.Name} with ID: {player.Player.ID} has cards: ");

            foreach (var card in player.PlayerState.Hand.CardsInHand)
            {
                System.Diagnostics.Debug.WriteLine($" -> CARD: {card.Text} with ID: {card.ID}");
            }
            
        }
    }

    private List<IPlayer> CreatePlayers()
    {
        List<IPlayer> _players = new List<IPlayer>();    
        for (int i = 1; i < 4; i++)
        {
            Player p = new Player();
            p.Name = $"Player-{i}";

            p.ID = Guid.NewGuid();

            _players.Add(p);
        }

        return _players;
    }
    private List<IGamePlayer> CreateGamePlayers(List<IPlayer> players)
    {
        List<IGamePlayer> _gamePlayers = new List<IGamePlayer>();
        foreach (var player in players)
        {
            GamePlayer gp = new GamePlayer(player);
            gp.PlayerState = new GamePlayerState();
            _gamePlayers.Add(gp);
        }
        return _gamePlayers;
    }

    //[Test]
    //public void CreateBlackDeck()
    //{
    //    BlackDeckFactory factory = new BlackDeckFactory();
    //    factory.CreateDeck();
    //    Assert.Pass();
    //}

    //[Test]
    //public void CreateWhiteDeck()
    //{
    //    WhiteDeckFactory factory = new WhiteDeckFactory();
    //    factory.CreateDeck();
    //    Assert.Pass();
    //}
}