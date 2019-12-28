using System;
using GameTOP.Interface;

namespace GameTOP.Lib
{
        public class Jogador1 : IJogador
        {
            public readonly string _nome;
            public Jogador1(string nome = "Ronaldo Nazaro")
            {
                _nome = nome;
            }
            //chuta
            public string Chuta()
            {
               return $"{_nome} está Chutando!\n";
            }
            //corre
            public string Corre()
            {
               return $"{_nome} está Correndo!\n";
            }

            //passa
            public string Passe()
            {
               return $"{_nome} está Passando!\n";
            }

        }
        }