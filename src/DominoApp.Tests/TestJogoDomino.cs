using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DominoApp.DomainModel.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DominoApp.Tests
{
    /// <summary>
    /// Summary description for TestJogoDomino
    /// </summary>
    [TestClass]
    public class TestJogoDomino
    {
        public TestJogoDomino()
        {
            
        }
        
        
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestJogo1()
        {
            var jogo = JogoDomino.NovoJogo("player1", "player2");

            var j1 = jogo.Jogadores[0];
            var p1 = j1.Mao[0];

            var s1 = jogo.Jogar("player1", p1.ToString(), "e");

            var j2 = jogo.Jogadores[1];
            List<Pedra> jogadas;

            while (!(jogadas = j2.ObterJogadasPossiveis(jogo.Mesa.PontaEsquerda, jogo.Mesa.PontaDireita)).Any())
            {
                jogo.ComprarPedra(j2.Id);
            }

            Assert.AreEqual(j1.Mao.Count, 6);
            Assert.AreEqual(jogo.Mesa.PedrasJogadas.Count, 1);
            Assert.AreEqual(jogo.Mesa.PontaEsquerda, p1.Lado2);

            var s2 = jogo.Jogar("player2", jogadas[0].ToString(), "d");
        }

        [TestMethod]
        public void TestPedrasEq()
        {
            var p1 = Pedra.FromString("6x2");
            var p2 = Pedra.FromString("2x6");

            Assert.AreEqual(p1, p2);
        }
    }
}
