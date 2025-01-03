using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galacticolisée.classes.Affichage;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Galacticolisée.classes.Combattant.Joueur
{
    internal class Joueur : Combattant
    {
        //Attributs de la classe:
        private int _santeMax;

        //Propriétés de la classe:
        public int SanteMax { get { return _santeMax; } set { _santeMax = value; } }

        //Constructeur de la classe:
        public Joueur(string nom, int initiative, int sante, int atqBase)
        {
            Nom = nom;
            Initiative = initiative;
            Sante = sante;
            AtqBase = atqBase;
            SanteMax = sante;
            Couleur = ConsoleColor.DarkGreen;
        }

        //Constructeur vide
        public Joueur()
        {
            Nom = "Glorp";
            Initiative = 1;
            Sante = 10;
            AtqBase = 5;
            SanteMax = Sante;
            Couleur = ConsoleColor.DarkGreen;
        }

        public int ChoisirDefense()
        {
            //INITIALISATION DES VARIABLES:
            Affichage.Affichage affichage = new Affichage.Affichage();

            affichage.AfficherEnCouleur("Choisissez une ", ConsoleColor.DarkMagenta, false);
            affichage.AfficherEnCouleur("défense ", ConsoleColor.Cyan, false);
            affichage.AfficherEnCouleur(":", ConsoleColor.DarkMagenta, true);
            affichage.AfficherEnCouleur("0 --- encaisser     1 --- esquiver     2 --- parer", ConsoleColor.Cyan, true);
            affichage.AfficherEnCouleur("CHOIX : ", ConsoleColor.DarkMagenta, false);
            int choix = int.Parse(Console.ReadLine());
            return choix;
        }

        public int ChoisirAttaque()
        {
            //INITIALISATION DES VARIABLES:
            Affichage.Affichage affichage = new Affichage.Affichage();
            int choix = 0;

            do
            {
                affichage.AfficherEnCouleur("Choisissez des ", ConsoleColor.DarkMagenta, false);
                affichage.AfficherEnCouleur("dés d'attaque ", ConsoleColor.Cyan, false);
                affichage.AfficherEnCouleur(":", ConsoleColor.DarkMagenta, true);
                affichage.AfficherEnCouleur("0 --- D4 (-0Æ)\t\t1 --- D4+D6 (-1Æ)" +
                    "\n2 --- D4+D6+D8 (-2Æ)\t3 --- D4+D6+D8+D10 (-3Æ)", ConsoleColor.Cyan, true);
                affichage.AfficherEnCouleur("CHOIX : ", ConsoleColor.DarkMagenta, false);
                choix = int.Parse(Console.ReadLine());
                if (choix > Adrenaline)
                {
                    affichage.AfficherEnCouleur("Pas assez d'adrénaline !", ConsoleColor.Red, true);
                };
            } while (choix > Adrenaline);

            return choix;
        }
    }
}
