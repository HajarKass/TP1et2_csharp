using System;
using System.Collections.Generic;

namespace GestionArticles
{
    // Classe abstraite Publication
    public abstract class Publication
    {
        protected string designation;
        protected double prix;

        public Publication(string designation, double prix)
        {
            this.designation = designation;
            this.prix = prix;
        }

        // Méthode abstraite pour afficher les détails de la publication
        public abstract void PublishDetails();
    }

    // Interface IRentable pour les articles rentables
    public interface IRentable
    {
        double CalculateRent(); // Méthode pour calculer le coût de location
    }

    // Classe Livre implémentant Publication et IRentable
    public class Livre : Publication, IRentable
    {
        protected string isbn;
        protected int nbPages;

        public Livre(string designation, double prix, string isbn, int nbPages)
            : base(designation, prix)
        {
            this.isbn = isbn;
            this.nbPages = nbPages;
        }

        // Implémentation de la méthode abstraite PublishDetails
        public override void PublishDetails()
        {
            Console.WriteLine($"Livre: {designation}, ISBN: {isbn}, Pages: {nbPages}, Prix: {prix} €");
        }

        // Implémentation de la méthode CalculateRent de l'interface IRentable
        public double CalculateRent()
        {
            return (prix * 0.1) + (nbPages * 0.05);
        }
    }

    // Classe Disque implémentant Publication et IRentable
    public class Disque : Publication, IRentable
    {
        protected string label;

        public Disque(string designation, double prix, string label)
            : base(designation, prix)
        {
            this.label = label;
        }

        // Implémentation de la méthode abstraite PublishDetails
        public override void PublishDetails()
        {
            Console.WriteLine($"Disque: {designation}, Label: {label}, Prix: {prix} €");
        }

        // Implémentation de la méthode CalculateRent de l'interface IRentable
        public double CalculateRent()
        {
            return prix * 0.15;
        }
    }

    // Classe Vidéo implémentant Publication et IRentable
    public class Video : Publication, IRentable
    {
        protected double duree; // Durée en heures

        public Video(string designation, double prix, double duree)
            : base(designation, prix)
        {
            this.duree = duree;
        }

        // Implémentation de la méthode abstraite PublishDetails
        public override void PublishDetails()
        {
            Console.WriteLine($"Vidéo: {designation}, Durée: {duree} heures, Prix: {prix} €");
        }

        // Implémentation de la méthode CalculateRent de l'interface IRentable
        public double CalculateRent()
        {
            return (prix * 0.05) + (duree * 1);
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

            // Création d'une liste de publications (articles)
            List<Publication> publications = new List<Publication>
            {
                livre,
                disque,
                video
            };

            // Parcours de la liste et appel de la méthode PublishDetails() pour chaque article
            foreach (var publication in publications)
            {
                publication.PublishDetails();  // Appel de la méthode spécifique à chaque type d'article
                if (publication is IRentable rentableArticle)
                {
                    Console.WriteLine($"Coût de location : {rentableArticle.CalculateRent():F2} €");
                }
                Console.WriteLine();
            }
        }
    }
}