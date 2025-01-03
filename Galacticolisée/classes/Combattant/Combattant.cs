using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Galacticolisée.classes.Combattant
{
    public class Combattant
    {
        //Attributs de la classe:
        private string _nom = "Guerrier Anonyme";
        private int _initiative = 1;
        private int _sante = 10; //<--"santé".
        private int _atqBase = 5; //<--Désigne la valeur de base d'attaque, celle qui s'ajoutera à la valeur d'un résultat de dé.
        private int _adrenaline = 0;
        private ConsoleColor _couleur = ConsoleColor.DarkRed;

        //Propriétés de la classe:
        public string Nom { get { return _nom; } set { _nom = value; } }
        public int Initiative { get { return _initiative; } set { _initiative = value; } }
        public int Sante { get { return _sante; } set { _sante = value; } }
        public int AtqBase { get { return _atqBase; } set { _atqBase = value; } }
        public int Adrenaline { get { return _adrenaline; } set { _adrenaline = value; } }
        public ConsoleColor Couleur { get { return _couleur; } set { _couleur = value; } }

        //Constructeur de la classe:
        public Combattant(string nom, int initiative, int sante, int atqBase)
        {
            Nom = nom;
            Initiative = initiative;
            Sante = sante;
            AtqBase = atqBase;
        }

        //Constructeur vide:
        public Combattant()
        {
        }

        //DÉFENDRE
        public void Defendre(Combattant Attaquant, Combattant Defenseur, int attaque, int choixDefense)
        {
            //INITIALISATION DES VARIABLES:
            Random aleatoire = new Random();
            int nombreAleatoire = aleatoire.Next(0, 2);
            Affichage.Affichage affichage = new Affichage.Affichage();

            switch (choixDefense)
            {
                case 0: //encaissement
                    Defenseur.Adrenaline += 1;
                    Defenseur.Sante -= attaque / 2;
                    affichage.AfficherEnCouleur(Defenseur.Nom, Defenseur.Couleur, false);
                    affichage.AfficherEnCouleur(" encaisse ", ConsoleColor.Cyan, false);
                    affichage.AfficherEnCouleur("les dégats !", ConsoleColor.DarkMagenta, true);
                    break;
                case 1: //esquive
                    Defenseur.Adrenaline += 2;
                    affichage.AfficherEnCouleur(Defenseur.Nom, Defenseur.Couleur, false);
                    affichage.AfficherEnCouleur(" tente d'", ConsoleColor.DarkMagenta, false);
                    affichage.AfficherEnCouleur("esquiver", ConsoleColor.Cyan, false);
                    affichage.AfficherEnCouleur(", ", ConsoleColor.DarkMagenta, false);
                    if (nombreAleatoire == 0) //échec
                    {
                        Defenseur.Sante -= attaque;
                        affichage.AfficherEnCouleur("mais ", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("échoue ", ConsoleColor.Red, false);
                        affichage.AfficherEnCouleur("!", ConsoleColor.DarkMagenta, true);
                    }
                    else //(nombreAleatoire == 1) //réussite
                    {
                        //Defenseur.Sante -= 0;
                        affichage.AfficherEnCouleur("et ", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("réussit ", ConsoleColor.Green, false);
                        affichage.AfficherEnCouleur("!", ConsoleColor.DarkMagenta, true);
                    };
                    break;
                case 2: //parade
                    Defenseur.Adrenaline += 3;
                    affichage.AfficherEnCouleur(Defenseur.Nom, Defenseur.Couleur, false);
                    affichage.AfficherEnCouleur(" tente de ", ConsoleColor.DarkMagenta, false);
                    affichage.AfficherEnCouleur("parer", ConsoleColor.Cyan, false);
                    affichage.AfficherEnCouleur(", ", ConsoleColor.DarkMagenta, false);
                    if (nombreAleatoire == 0) //échec
                    {
                        Defenseur.Sante -= attaque * 2;
                        affichage.AfficherEnCouleur("mais ", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("échoue ", ConsoleColor.Red, false);
                        affichage.AfficherEnCouleur("et se blesse d'avantage !", ConsoleColor.DarkMagenta, true);
                    }
                    else //(nombreAleatoire == 1) //réussite
                    {
                        Attaquant.Sante -= attaque;
                        affichage.AfficherEnCouleur("et ", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("réussit ", ConsoleColor.Green, false);
                        affichage.AfficherEnCouleur("à renvoyer l'attaque !", ConsoleColor.DarkMagenta, true);
                    };
                    break;
            }
        }


        //ATTAQUER
        public int Attaquer(Combattant Attaquant, int choixAttaque)
        {
            //INITIALISATION DES VARIABLES:
            int attaque = 0;
            Random aleatoire = new Random();
            Affichage.Affichage affichage = new Affichage.Affichage();

            switch (choixAttaque)
            {
                case 0:
                    affichage.AfficherEnCouleur(Attaquant.Nom, Attaquant.Couleur, false);
                    affichage.AfficherEnCouleur(" a choisit ", ConsoleColor.DarkMagenta, false);
                    affichage.AfficherEnCouleur("D4", ConsoleColor.Cyan, true);
                    //Attaquant.Adrenaline -= 0;
                    attaque = Convert.ToInt32(Attaquant.AtqBase) + aleatoire.Next(1, 5);
                    break;
                case 1:
                    affichage.AfficherEnCouleur(Attaquant.Nom, Attaquant.Couleur, false);
                    affichage.AfficherEnCouleur(" a choisit ", ConsoleColor.DarkMagenta, false);
                    affichage.AfficherEnCouleur("D4+D6", ConsoleColor.Cyan, true);
                    Attaquant.Adrenaline -= 1;
                    attaque = Convert.ToInt32(Attaquant.AtqBase) + aleatoire.Next(1, 5) + aleatoire.Next(1, 7);
                    break;
                case 2:
                    affichage.AfficherEnCouleur(Attaquant.Nom, Attaquant.Couleur, false);
                    affichage.AfficherEnCouleur(" a choisit ", ConsoleColor.DarkMagenta, false);
                    affichage.AfficherEnCouleur("D4+D6+D8", ConsoleColor.Cyan, true);
                    Attaquant.Adrenaline -= 2;
                    attaque = Convert.ToInt32(Attaquant.AtqBase) + aleatoire.Next(1, 5) + aleatoire.Next(1, 7) + aleatoire.Next(1, 9);
                    break;
                case 3:
                    Attaquant.Adrenaline -= 3;
                    affichage.AfficherEnCouleur(Attaquant.Nom, Attaquant.Couleur, false);
                    affichage.AfficherEnCouleur(" a choisit ", ConsoleColor.DarkMagenta, false);
                    affichage.AfficherEnCouleur("D4+D6+D8+D10", ConsoleColor.Cyan, true);
                    attaque = Convert.ToInt32(Attaquant.AtqBase) + aleatoire.Next(1, 5) + aleatoire.Next(1, 7) + aleatoire.Next(1, 9) + aleatoire.Next(1, 11);
                    break;
            };
            return attaque;
        }
    }
}
