using System;
using GameTOP.Interface;
using static GameTOP.Program;

namespace GameTOP
{
    class JogoFoda{

        private readonly IJogador _jogadorA;
        private readonly IJogador _jogadorB;
        private readonly IJogador _jogadorC;
        public JogoFoda(IJogador jogadorA, IJogador jogadorB, IJogador jogadorC)
        {
            _jogadorA = jogadorA;
            _jogadorB = jogadorB;
            _jogadorC = jogadorC;
        }

        public void IniciarJogo()
        {
            Console.Write(_jogadorA.Chuta());
            Console.Write(_jogadorA.Passe());
            Console.Write(_jogadorA.Corre());

            Console.Write("\n========PROXIMO JOGADOR=====\n\n");
            Console.Write(_jogadorB.Chuta());
            Console.Write(_jogadorB.Passe());
            Console.Write(_jogadorB.Corre());

             Console.Write("\n========PROXIMO JOGADOR=====\n\n");
            Console.Write(_jogadorC.Chuta());
            Console.Write(_jogadorC.Passe());
            Console.Write(_jogadorC.Corre());
        }
    }

}