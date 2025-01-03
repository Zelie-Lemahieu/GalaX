using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galacticolisée.classes.Combattant;
using Galacticolisée.classes.Combattant.Joueur;
using Galacticolisée.classes.Affichage;
using System.Security.Cryptography.X509Certificates;

namespace Galacticolisée.classes.CreationDePersonnage
{
    internal class CreationDePersonnage
    {
        //Constructeur de classe:
        public CreationDePersonnage()
        {
        }

        //Méthode
        public void NouveauPersonnage(Joueur Joueur)
        {
            //INITIALISATION DES VARIABLES:
            int choix = 0;
            bool creationEnCours = true;
            Affichage.Affichage affichage = new Affichage.Affichage();//<--Classe contenant les méthodes d'affichage (titrage, etc.)
            const string TITRE = " ________  ________  ___       ________     ___    ___ " +
                "\n|\\   ____\\|\\   __  \\|\\  \\     |\\   __  \\   |\\  \\  /  /|" +
                "\n\\ \\  \\___|\\ \\  \\|\\  \\ \\  \\    \\ \\  \\|\\  \\  \\ \\  \\/  / /" +
                "\n \\ \\  \\  __\\ \\   __  \\ \\  \\    \\ \\   __  \\  \\ \\    / / " +
                "\n  \\ \\  \\|\\  \\ \\  \\ \\  \\ \\  \\____\\ \\  \\ \\  \\  /     \\/  " +
                "\n   \\ \\_______\\ \\__\\ \\__\\ \\_______\\ \\__\\ \\__\\/  /\\   \\  " +
                "\n    \\|_______|\\|__|\\|__|\\|_______|\\|__|\\|__/__/ /\\ __\\ " +
                "\n                                           |__|/ \\|__| "; //<--Titre "GalaX" en ASCII
            const string TITRECREATIONPERSONNAGE = "CRÉATION D'UN PERSONNAGE";

            do
            {
                do
                {
                    affichage.AfficherEnCouleur(TITRE, ConsoleColor.Magenta, true);
                    affichage.Titrer(TITRECREATIONPERSONNAGE, ConsoleColor.Yellow);
                    do
                    {
                        affichage.AfficherEnCouleur("Entrez le nom de votre personnage : ", ConsoleColor.Cyan, false);
                        Joueur.Nom = Console.ReadLine();
                        if (Joueur.Nom.Length > 10)//<--Le nom doit contenir moins de 10 caractères.
                        {
                            affichage.AfficherEnCouleur("Le nom ne doit pas dépasser 10 caractères.", ConsoleColor.Red, true);
                        };
                    } while (Joueur.Nom.Length > 10); //<-- La boucle continu tant que le nom n'est pas valide.
                                                      //Message d'avertissement et de confirmation:
                    affichage.AfficherEnCouleur("Êtes-vous sûr.e ?", ConsoleColor.Cyan, true);
                    affichage.AfficherEnCouleur("(Le nom ne pourra jamais être changer !)", ConsoleColor.Red, true);
                    affichage.AfficherEnCouleur("0 --- non.\t\t1 --- oui.", ConsoleColor.Cyan, true);
                    affichage.AfficherEnCouleur("CHOIX : ", ConsoleColor.DarkMagenta, false);
                    choix = int.Parse(Console.ReadLine());
                    Console.Clear();
                } while (choix == 0);

                AmeliorerPersonnage(8, Joueur); //<-- 8pt bonus à la création du personnage.
                creationEnCours = false;
            } while (creationEnCours);
        }

        //MÉTHODE AMELIORATION PERSONNAGE:

        public void AmeliorerPersonnage(int pointsBonus, Joueur Joueur)
        {
            //INITIALISATION DES VARIABLES
            int choix = 0;
            bool creationEnCours = true;

            do
            {
                Affichage.Affichage affichage = new Affichage.Affichage();//<--Classe contenant les méthodes d'affichage (titrage, etc.)
                const string TITREAMELIORATIONPERSONAGE = "AMÉLIORATION DU PERSONNAGE";

                affichage.Titrer(TITREAMELIORATIONPERSONAGE, ConsoleColor.Yellow);

                //Message explicatif:
                affichage.AfficherEnCouleur("Vous avez ", ConsoleColor.DarkMagenta, false);
                affichage.AfficherEnCouleur($"{pointsBonus} points bonus", ConsoleColor.Cyan, false);
                affichage.AfficherEnCouleur(". Utilisez les pour améliorer les caractéristiques de votre personnage." +
                    "\n\t1pt investi en initiative vaut +1pt d'initiative." +
                    "\n\t1pt investi en santé vaut +10pt de santé." +
                    "\n\t1pt investi en attaque vaut +1pt d'attaque de base.", ConsoleColor.DarkMagenta, true);
                affichage.AfficherEnCouleur("\nCaractéristiques actuelles:", ConsoleColor.DarkMagenta, true);
                affichage.AfficherEnCouleur($"\tInitiative = {Joueur.Initiative}     Santé = {Joueur.Sante}     Attaque de base = {Joueur.AtqBase}" +
                    $"\n\nChoisir d'investir des points ;\n\t1 --- en initiative.    2 --- en santé.   3 --- en attaque de base.\n\t0 --- valider.", ConsoleColor.Cyan, true);

                choix = int.Parse(Console.ReadLine());
                switch (choix)
                {
                    case 1: //Initiative:
                        Console.Clear();
                        affichage.Titrer(TITREAMELIORATIONPERSONAGE, ConsoleColor.Yellow);
                        affichage.AfficherEnCouleur("1pt investi en initiative vaut +1pt d'initiative." +
                            "\n(initiative maximale = 5)" +
                            "\nCombien de points voulez-vous investir en ", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("initiative ", ConsoleColor.Cyan, false);
                        affichage.AfficherEnCouleur("? ", ConsoleColor.DarkMagenta, false);
                        choix = int.Parse(Console.ReadLine());

                        if (Joueur.Initiative + choix > 5 || Joueur.Initiative + choix < 1)//<--Empèche l'initiative de dépasser 5 et être inférieur à 1.
                        {
                            affichage.AfficherEnCouleur("\tL'initiative doit être comprise entre 1 et 5 !", ConsoleColor.Red, true);
                        }
                        else if (pointsBonus - choix < 0)
                        {
                            affichage.AfficherEnCouleur("\tPlus assez de point bonus !", ConsoleColor.Red, true);
                        }
                        else
                        {
                            pointsBonus -= choix;
                            Joueur.Initiative += choix;
                        };
                        break;
                    case 2://Santé
                        Console.Clear();
                        affichage.Titrer(TITREAMELIORATIONPERSONAGE, ConsoleColor.Yellow);
                        affichage.AfficherEnCouleur("1pt investi en santé vaut +10pt de santé." +
                            "\nCombien de points voulez-vous investir en ", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("santé ", ConsoleColor.Cyan, false);
                        affichage.AfficherEnCouleur("? ", ConsoleColor.DarkMagenta, false);
                        choix = int.Parse(Console.ReadLine());

                        if (Joueur.Sante + choix < 10)//<--Empèche la santé d'être inférieur à 10.
                        {
                            affichage.AfficherEnCouleur("\tLa santé ne peut être inférieur à 10 !", ConsoleColor.Red, true);
                        }
                        else if (pointsBonus - choix < 0)
                        {
                            affichage.AfficherEnCouleur("\tPlus assez de point bonus !", ConsoleColor.Red, true);
                        }
                        else
                        {
                            pointsBonus -= choix;
                            Joueur.Sante += choix * 10;
                            Joueur.SanteMax = Joueur.Sante;
                        };
                        break;
                    case 3://Attaque de base:
                        Console.Clear();
                        affichage.Titrer(TITREAMELIORATIONPERSONAGE, ConsoleColor.Yellow);
                        affichage.AfficherEnCouleur("1pt investi en attaque de base vaut +1pt d'attaque de base." +
                            "\nCombien de points voulez-vous investir en ", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("attaque de base ", ConsoleColor.Cyan, false);
                        affichage.AfficherEnCouleur("? ", ConsoleColor.DarkMagenta, false);
                        choix = int.Parse(Console.ReadLine());

                        if (Joueur.AtqBase + choix < 5)//<--Empèche l'attaque de base d'être inférieur à 5.
                        {
                            affichage.AfficherEnCouleur("\tL'attaque de base ne peut être inférieur à 5 !", ConsoleColor.Red, true);
                        }
                        else if (pointsBonus - choix < 0)
                        {
                            affichage.AfficherEnCouleur("\tPlus assez de point bonus !", ConsoleColor.Red, true);
                        }
                        else
                        {
                            pointsBonus -= choix;
                            Joueur.AtqBase += choix;
                        };
                        break;
                    case 0://Validation des choix.
                        Console.Clear();
                        affichage.AfficherEnCouleur("Votre combattant :", ConsoleColor.DarkMagenta, true);
                        affichage.AfficherEnCouleur($"\t{Joueur.Nom}, initiative = {Joueur.Initiative}, santé = {Joueur.Sante}, attaque de base = {Joueur.AtqBase}", ConsoleColor.Cyan, true);
                        Console.WriteLine("");//<--Passage de ligne.

                        if (pointsBonus > 0)
                        {
                            affichage.AfficherEnCouleur("Il vous reste des points bonus, voulez-vous vraiment valider ?", ConsoleColor.Red, true);
                            affichage.AfficherEnCouleur("0 --- non.\t\t1 --- oui.", ConsoleColor.Cyan, true);
                            choix = int.Parse(Console.ReadLine());
                        }
                        else
                        {
                            affichage.AfficherEnCouleur("Voulez-vous ", ConsoleColor.DarkMagenta, false);
                            affichage.AfficherEnCouleur("valider ", ConsoleColor.Cyan, false);
                            affichage.AfficherEnCouleur("votre répartission des points bonus ?", ConsoleColor.DarkMagenta, true);
                            affichage.AfficherEnCouleur("0 --- non.\t\t1 --- oui.", ConsoleColor.Cyan, true);
                            choix = int.Parse(Console.ReadLine());
                        }
                        if (choix == 1)
                        {
                            creationEnCours = false; //<--On affecte cette valeur afin de pouvoir atteindre la porte de sortie.
                        };
                        Console.Clear();
                        break;
                };
            } while (creationEnCours);
        }
    }
}
