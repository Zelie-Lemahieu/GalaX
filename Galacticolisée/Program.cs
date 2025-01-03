using System;
using System.Reflection.Metadata;
using Galacticolisée.classes.Affichage;
using Galacticolisée.classes.Combattant;
using Galacticolisée.classes.Combattant.Ennemi;
using Galacticolisée.classes.Combattant.Joueur;
using Galacticolisée.classes.CreationDePersonnage;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //INITIALISATION DES VARIABLES:
            int choix = 0;//<--entrée utilisateur (pour naviguer dans les menus).
            Random aleatoire = new Random();//<--Générateur de nombre aléatoire.
            CreationDePersonnage creationDePersonnage = new CreationDePersonnage();//<--Classe permettant de créer un personnage
            Affichage affichage = new Affichage();//<--Classe contenant les méthodes d'affichage (titrage, etc.)
            Joueur Joueur = new Joueur();//<--Création du personnage du joueur
            const string TITRE = " ________  ________  ___       ________     ___    ___ " +
                "\n|\\   ____\\|\\   __  \\|\\  \\     |\\   __  \\   |\\  \\  /  /|" +
                "\n\\ \\  \\___|\\ \\  \\|\\  \\ \\  \\    \\ \\  \\|\\  \\  \\ \\  \\/  / /" +
                "\n \\ \\  \\  __\\ \\   __  \\ \\  \\    \\ \\   __  \\  \\ \\    / / " +
                "\n  \\ \\  \\|\\  \\ \\  \\ \\  \\ \\  \\____\\ \\  \\ \\  \\  /     \\/  " +
                "\n   \\ \\_______\\ \\__\\ \\__\\ \\_______\\ \\__\\ \\__\\/  /\\   \\  " +
                "\n    \\|_______|\\|__|\\|__|\\|_______|\\|__|\\|__/__/ /\\ __\\ " +
                "\n                                           |__|/ \\|__| "; //<--Titre "GalaX" en ASCII

            //Création d'un tableau contenant les ennemis dans l'ordre:
            Ennemi ZipZip = new Ennemi("Zip-Zip", 1, 15, 1);
            Ennemi Borp = new Ennemi("Borp", 1, 30, 5);
            Ennemi Vegzep = new Ennemi("Vegzep", 2, 50, 6);
            Ennemi Gnorp = new Ennemi("Gnorp", 2, 80, 8);
            Ennemi Galax = new Ennemi("Galax le boulotteur de galaxie", 3, 110, 10);
            Ennemi[] ennemis = { ZipZip, Borp, Vegzep, Gnorp, Galax };


            affichage.AfficherEnCouleur(TITRE, ConsoleColor.Magenta, true);
            affichage.Titrer("MENU PRINCIPAL", ConsoleColor.Yellow);

            do
            {
                affichage.AfficherEnCouleur("1 --- Créer un nouveau personnage et commencer une nouvelle partie." +
                    "\n2 --- Commencer une nouvelle partie avec Glorp." +
                    "\n3 --- Lire les règles." +
                    "\n0 --- Quitter.", ConsoleColor.Cyan, true);
                affichage.AfficherEnCouleur("CHOIX : ", ConsoleColor.DarkMagenta, false);
                choix = int.Parse(Console.ReadLine());
                switch (choix)
                {
                    case 1://Création de personnage
                        Console.Clear();
                        creationDePersonnage.NouveauPersonnage(Joueur);
                        break;
                    case 2://Jouer avec Glorp
                        Joueur Glorp = new Joueur("Glorp", 2, 30, 7);
                        Joueur = Glorp;
                        break;
                    case 3: //Règles du jeu
                        Console.Clear();
                        affichage.AfficherEnCouleur(TITRE, ConsoleColor.Magenta, true);
                        affichage.Titrer("RÈGLES", ConsoleColor.Yellow);
                        affichage.AfficherEnCouleur("Bienvenue au Galacticolisée !" +
                            "\nVous devez terrasser ", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("5 adversaires ", ConsoleColor.Cyan, false);
                        affichage.AfficherEnCouleur("avant d'être célébré.e champion.ne." +
                            "\nQuand c'est votre tour d'attaquer, choisissez les ", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("dés d'attaque ", ConsoleColor.Cyan, false);
                        affichage.AfficherEnCouleur("à lancer, au plus ils sont importants, au plus vous dépenserez d'", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("adrénaline", ConsoleColor.Cyan, false);
                        affichage.AfficherEnCouleur(".\nLe résultat des dés se cumule à l'", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("attaque de base ", ConsoleColor.Cyan, false);
                        affichage.AfficherEnCouleur("pour donner le nombre de points de dégats menaçant l'adversaire." +
                            "\nQuand vous êtes attaqué.e, choisissez une défense ;" +
                            "\n\"", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("encaisser", ConsoleColor.Cyan, false);
                        affichage.AfficherEnCouleur("\" réduit les dégats par deux," +
                            "\n\"", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("esquiver", ConsoleColor.Cyan, false);
                        affichage.AfficherEnCouleur("\" a 50% de chance d'épargner tout dégât," +
                            "\n\"", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("parer", ConsoleColor.Cyan, false);
                        affichage.AfficherEnCouleur("\" a 50% de chance de renvoyer les dégats à l'attaquant, mais autant de chance d'en subir 2x plus." +
                            "\nAu plus votre choix de défense est risqué, au plus vous gagnez de points d'", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("adrénaline", ConsoleColor.Cyan, false);
                        affichage.AfficherEnCouleur("." +
                            "\nChaque tour, un combattant frappe en premier, au plus sa statistique d'", ConsoleColor.DarkMagenta, false);
                        affichage.AfficherEnCouleur("ininitiative ", ConsoleColor.Cyan, false);
                        affichage.AfficherEnCouleur("est élevé, au plus il a de chance de porter le premier coup." +
                            "\nBon courage !\n", ConsoleColor.DarkMagenta, true);
                        break;
                    case 0://quitter
                        Environment.Exit(0);
                        break;
                    case -25091965: //<--Easter Egg
                        Joueur AnneR = new Joueur("Anne Roumanoff", 5, 900, 100);
                        Joueur = AnneR;
                        Joueur.Adrenaline = 99999;
                        break;
                };
            } while (choix == 3);//<-- tant que choix == 3, car c'est le seul choix qui doit rammener ensuite au menu principal.

            //COMBAT
            //Initialisation des variables:
            Ennemi Ennemi = new Ennemi();
            int numeroDuTour = 0;
            int numeroDeLEnnemi = 0;

            do
            {
                numeroDuTour = 0;
                Ennemi = ennemis[numeroDeLEnnemi];
                numeroDeLEnnemi++;//<--On attribue le prochain ennemi au prochain combat
                //Début du combat:
                do
                {
                    numeroDuTour++;
                    affichage.Titrer($"TOUR N°{numeroDuTour}:", ConsoleColor.Blue);
                    Console.WriteLine("");//<--Passage de ligne

                    affichage.InfosCombattants(Joueur, Ennemi);
                    if (JoueurCommence(Ennemi))//JoueurCommence == true.
                    {
                        affichage.AfficherEnCouleur(Joueur.Nom, ConsoleColor.DarkGreen, false);
                        affichage.AfficherEnCouleur(" porte le premier coup !", ConsoleColor.DarkMagenta, true);
                        Ennemi.Defendre(Joueur, Ennemi, Joueur.Attaquer(Joueur, Joueur.ChoisirAttaque()), Ennemi.ChoisirDefense());
                        if (Joueur.Sante > 0 && Ennemi.Sante > 0)
                        {
                            affichage.InfosCombattants(Joueur, Ennemi);
                            affichage.AfficherEnCouleur("À ", ConsoleColor.DarkMagenta, false);
                            affichage.AfficherEnCouleur(Ennemi.Nom, ConsoleColor.DarkRed, false);
                            affichage.AfficherEnCouleur(" de cogner !", ConsoleColor.DarkMagenta, true);
                            Joueur.Defendre(Ennemi, Joueur, Ennemi.Attaquer(Ennemi, Ennemi.ChoisirAttaque()), Joueur.ChoisirDefense());
                        };
                    }
                    else //JoueurCommence == false.
                    {
                        affichage.AfficherEnCouleur(Ennemi.Nom, ConsoleColor.DarkRed, false);
                        affichage.AfficherEnCouleur(" porte le premier coup !", ConsoleColor.DarkMagenta, true);
                        Joueur.Defendre(Ennemi, Joueur, Ennemi.Attaquer(Ennemi, Ennemi.ChoisirAttaque()), Joueur.ChoisirDefense());
                        if (Joueur.Sante > 0 && Ennemi.Sante > 0)
                        {
                            affichage.InfosCombattants(Joueur, Ennemi);
                            affichage.AfficherEnCouleur("À ", ConsoleColor.DarkMagenta, false);
                            affichage.AfficherEnCouleur(Joueur.Nom, ConsoleColor.DarkGreen, false);
                            affichage.AfficherEnCouleur(" de cogner !", ConsoleColor.DarkMagenta, true);
                            Ennemi.Defendre(Joueur, Ennemi, Joueur.Attaquer(Joueur, Joueur.ChoisirAttaque()), Ennemi.ChoisirDefense());
                        };
                    };

                } while (Joueur.Sante > 0 && Ennemi.Sante > 0);
                affichage.AfficherEnCouleur("---Fin du combat---", ConsoleColor.Yellow, true);
                if (Joueur.Sante > 0)
                {
                    affichage.AfficherEnCouleur(Joueur.Nom, ConsoleColor.DarkGreen, false);
                    affichage.AfficherEnCouleur(" a vaincu ", ConsoleColor.DarkMagenta, false);
                    affichage.AfficherEnCouleur(Ennemi.Nom, ConsoleColor.DarkRed, false);
                    affichage.AfficherEnCouleur(" !", ConsoleColor.DarkMagenta, true);
                    Joueur.Sante = Joueur.SanteMax;
                }
                else
                {
                    affichage.AfficherEnCouleur(Joueur.Nom, ConsoleColor.DarkGreen, false);
                    affichage.AfficherEnCouleur(" a été vaincu.e...", ConsoleColor.Red, true);
                    Environment.Exit(0);
                };

                if (Galax.Sante <= 0)
                {
                    affichage.Titrer($"{Joueur.Nom} est le.a grand.e champion.ne du Galacticolisée !!!", ConsoleColor.Yellow);
                    Environment.Exit(0);
                };

                creationDePersonnage.AmeliorerPersonnage(numeroDeLEnnemi, Joueur);

            } while (true);


            //fonction JoueurCommence, pour déterminer qui attaque le premier.
            ////Au plus l'initiative est élevé par rapport à celle de l'adversaire au plus le combattant à de chance de commencer.
            bool JoueurCommence(Combattant Ennemi)
            {
                int nombreAleatoire = aleatoire.Next(1, Ennemi.Initiative + Joueur.Initiative + 1);
                if (nombreAleatoire <= Joueur.Initiative)
                {
                    return true;
                }
                else
                {
                    return false;
                };
            }


        }
    }
}