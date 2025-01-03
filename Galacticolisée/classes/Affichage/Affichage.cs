using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galacticolisée.classes.Combattant.Ennemi;
using Galacticolisée.classes.Combattant.Joueur;

namespace Galacticolisée.classes.Affichage
{
    internal class Affichage
    {
        //Constructeur de classe:
        public Affichage()
        {
        }

        //MÉTHODE AFFICHER EN COULEUR : Affiche une ligne ou qlq mots en couleur
        public void AfficherEnCouleur(string texte, ConsoleColor couleur, bool passageDeLigne)
        {
            Console.ForegroundColor = couleur;

            if (passageDeLigne == true)
            {
                Console.WriteLine(texte);
            }
            else//(passageDeLigne == false)
            {
                Console.Write(texte);
            };

            Console.ResetColor();
        }

        //MÉTHODE TITRER : Affichage d'un titre encadré
        public void Titrer(string texte, ConsoleColor couleur)
        {
            Console.ForegroundColor = couleur;

            texte = $"║ {texte} ║";

            Console.Write("╔");
            for (int i = 0; i < texte.Length - 2; i++)
            {
                Console.Write("═");
            };
            Console.WriteLine("╗");
            Console.WriteLine(texte);
            Console.Write("╚");
            for (int i = 0; i < texte.Length - 2; i++)
            {
                Console.Write("═");
            };
            Console.WriteLine("╝");

            Console.ResetColor();
        }

        //MÉTHODE INFOSCOMBATTANTS : Pour afficher les infos nécessaire en combat.
        public void InfosCombattants(Combattant.Combattant Joueur, Combattant.Combattant Ennemi)
        {
            Console.BackgroundColor = ConsoleColor.White;
            AfficherEnCouleur("     " + Ennemi.Nom + " (" + Ennemi.Adrenaline + "Æ)", ConsoleColor.DarkRed, true);
            BarreDeSante(Ennemi);
            Console.WriteLine("");//<--Passage de ligne.
            Console.BackgroundColor = ConsoleColor.White;
            AfficherEnCouleur("   " + Joueur.Nom + " (" + Joueur.Adrenaline + "Æ)", ConsoleColor.DarkGreen, true);
            BarreDeSante(Joueur);
        }

        private void BarreDeSante(Combattant.Combattant Combattant)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i < Combattant.Sante; i++)
            {
                Console.Write(" ");
            };
            Console.ResetColor();
            Console.WriteLine("");//<--Passage de ligne.
        }
    }
}
