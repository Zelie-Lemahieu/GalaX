using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galacticolisée.classes.Combattant.Joueur;

namespace Galacticolisée.classes.Combattant.Ennemi
{
    internal class Ennemi : Combattant
    {

        //Constructeur de la classe:
        public Ennemi(string nom, int initiative, int sante, int atqBase)
        {
            Nom = nom;
            Initiative = initiative;
            Sante = sante;
            AtqBase = atqBase;
            Couleur = ConsoleColor.DarkRed;
        }

        //Constructeur par defaut
        public Ennemi()
        {
            Nom = "Combattant Anonyme";
            Initiative = 2;
            Sante = 15;
            AtqBase = 5;
            Couleur = ConsoleColor.DarkRed;
        }

        public int ChoisirDefense()
        {
            Random aleatoire = new Random();
            int choix = aleatoire.Next(0, 3);
            return choix;
        }

        public int ChoisirAttaque()
        {
            Random aleatoire = new Random();

            return aleatoire.Next(0, Convert.ToInt32(Adrenaline + 1));//<--fait un choix aléatoire sans choisir d'action qui nécessiterait plus d'Adrénaline que n'en a
        }
    }
}
