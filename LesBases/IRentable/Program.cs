using System;
using System.Collections.Generic; // Nécessaire pour List<T>

namespace GestionArticles
{
    // Définition de l'interface IRentable
    public interface IRentable
    {
        double CalculateRent(); // Méthode pour calculer le coût de location
    }

    // Classe de base Article
    public class Article
    {
        protected string designation;
        protected double prix;

        public Article(string designation, double prix)
        {
            this.designation = designation;
            this.prix = prix;
        }

        public void Acheter()
        {
            Console.WriteLine($"L'article {designation} a été acheté pour {prix} euros.");
        }
    }

    // Classe Livre implémentant IRentable
    public class Livre : Article, IRentable
    {
        protected string isbn;
        protected int nbPages;

        public Livre(string designation, double prix, string isbn, int nbPages)
            : base(designation, prix)
        {
            this.isbn = isbn;
            this.nbPages = nbPages;
        }

        public double CalculateRent()
        {
            // Exemple : coût de location = 10% du prix + 0,05 € par page
            return (prix * 0.1) + (nbPages * 0.05);
        }
    }

    // Classe Disque implémentant IRentable
    public class Disque : Article, IRentable
    {
        protected string label;

        public Disque(string designation, double prix, string label)
            : base(designation, prix)
        {
            this.label = label;
        }

        public double CalculateRent()
        {
            // Exemple : coût de location = 15% du prix
            return prix * 0.15;
        }

        public void Ecouter()
        {
            Console.WriteLine($"Écoute du disque {designation} avec le label {label}.");
        }
    }

    // Classe Vidéo implémentant IRentable
    public class Video : Article, IRentable
    {
        protected double duree; // Durée en heures

        public Video(string designation, double prix, double duree)
            : base(designation, prix)
        {
            this.duree = duree;
        }

        public double CalculateRent()
        {
            // Exemple : coût de location = 5% du prix + 1 € par heure de durée
            return (prix * 0.05) + (duree * 1);
        }

        public void Afficher()
        {
            Console.WriteLine($"La vidéo {designation} de durée {duree} heures est affichée.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Création d'instances des classes
            Livre livre = new Livre("C# Programming", 30.0, "978-1234567890", 500);
            Disque disque = new Disque("Greatest Hits", 15.0, "Universal Music");
            Video video = new Video("Video Clip", 1000000000, 3.12);

            // Création de la liste d'articles
            List<Article> articles = new List<Article>
            {
                livre,
                disque,
                video
            };

            // Parcours de la liste et affichage du coût de location pour chaque article
            foreach (var article in articles)
            {
                if (article is IRentable rentableArticle) // Vérification si l'article est IRentable
                {
                    Console.WriteLine($"Coût de location de l'article {article.GetType().Name}: {rentableArticle.CalculateRent():F2} €");
                }
            }
        }
    }
}