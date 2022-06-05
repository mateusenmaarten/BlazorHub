using System.Xml;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAH.Backend.Interfaces;
using CAH.Backend.Classes;

namespace CAH.Backend.Factories
{
    public class GameFactory
    {

        public GameFactory() {

        }

        private BlackDeckFactory _bdf = new BlackDeckFactory();
        private WhiteDeckFactory _wdf = new WhiteDeckFactory();

        protected virtual BlackDeck createBlackDeck(){
            return _bdf.CreateDeck();
        }

        protected virtual WhiteDeck createWhiteDeck(){
            return _wdf.CreateDeck();
        }

        public Game CreateGame(IEnumerable<IGamePlayer> players){

            //Hier enkel het 'lobby' gedeelte aanmaken? Spel zelf is voor de gamemanager?

            var blackDeck = createBlackDeck();
            var whiteDeck = createWhiteDeck();


            return new Game(blackDeck, whiteDeck, players);
        }

        protected GameState createGameState(BlackDeck bd, WhiteDeck wd, IEnumerable<IPlayer> players){

                // GameState gameState = new GameState(){
                     
                        return null;

                // }

        }

        //protected BlackDeck createBlackDeck(){
        //        return new BlackDeck();
        //}

        //protected WhiteDeck createWhiteDeck(){
        //    return new WhiteDeck();
        //}
    }
}