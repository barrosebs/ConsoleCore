using GameTOP.Interface;

namespace GameTOP.Lib
{
    public class Jogador3 : IJogador
    {
        public string Chuta()
        {
            return "Eduardo esta chutando\n";
        }

        public string Corre()
        {
            return "Eduardo esta correndo\n";
        }

        public string Passe()
        {
            return "Eduardo esta passando\n";
        }
    }
}