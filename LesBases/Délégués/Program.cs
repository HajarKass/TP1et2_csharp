using System;

namespace GestionArticles
{
    // Définition du délégué DiscountStrategy
    public delegate double DiscountStrategy(Article article);

    // Classe de base Article
    public class Article
    {
        public string Designation { get; set; }
        public double Prix { get; set; }

        public Article(string designation, double prix)
        {
            Designation = designation;
            Prix = prix;
        }
    }

    // Stratégie de remise fixe en pourcentage
    public class DiscountStrategies
    {
        // Remise fixe en pourcentage
        public static double PercentageDiscount(Article article)
        {
            return article.Prix * 0.10;  // 10% de remise
        }

        // Remise en fonction du type d'article (par exemple, pour un livre, on applique 20% de remise)
        public static double ItemTypeDiscount(Article article)
        {
            if (article is Livre)
                return article.Prix * 0.20; // 20% de remise sur les livres
            else if (article is Disque)
                return article.Prix * 0.15; // 15% de remise sur les disques
            else
                return 0; // Pas de remise pour d'autres types d'articles
        }
    }

    // Classe Livre héritée de Article
    public class Livre : Article
    {
        public Livre(string designation, double prix)
            : base(designation, prix)
        { }
    }

    // Classe Disque héritée de Article
    public class Disque : Article
    {
        public Disque(string designation, double prix)
            : base(designation, prix)
        { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Création d'instances d'articles
            Article livre = new Livre("C# Programming", 50.0);
            Article disque = new Disque("Greatest Hits", 20.0);

            // Création des délégués pour différentes stratégies de remise
            DiscountStrategy percentageDiscount = new DiscountStrategy(DiscountStrategies.PercentageDiscount);
            DiscountStrategy itemTypeDiscount = new DiscountStrategy(DiscountStrategies.ItemTypeDiscount);

            // Application de la remise avec la stratégie de pourcentage
            double livreDiscount = percentageDiscount(livre);
            double disqueDiscount = percentageDiscount(disque);

            // Application de la remise en fonction du type d'article
            double livreTypeDiscount = itemTypeDiscount(livre);
            double disqueTypeDiscount = itemTypeDiscount(disque);

            // Affichage des résultats
            Console.WriteLine($"Prix du livre avant remise : {livre.Prix} €");
            Console.WriteLine($"Remise sur le livre (10%) : {livreDiscount} €");
            Console.WriteLine($"Prix final du livre après remise : {livre.Prix - livreDiscount} €");
            Console.WriteLine();

            Console.WriteLine($"Prix du disque avant remise : {disque.Prix} €");
            Console.WriteLine($"Remise sur le disque (10%) : {disqueDiscount} €");
            Console.WriteLine($"Prix final du disque après remise : {disque.Prix - disqueDiscount} €");
            Console.WriteLine();

            Console.WriteLine($"Prix du livre avant remise (type) : {livre.Prix} €");
            Console.WriteLine($"Remise sur le livre (20% - type) : {livreTypeDiscount} €");
            Console.WriteLine($"Prix final du livre après remise (type) : {livre.Prix - livreTypeDiscount} €");
            Console.WriteLine();

            Console.WriteLine($"Prix du disque avant remise (type) : {disque.Prix} €");
            Console.WriteLine($"Remise sur le disque (15% - type) : {disqueTypeDiscount} €");
            Console.WriteLine($"Prix final du disque après remise (type) : {disque.Prix - disqueTypeDiscount} €");
        }
    }
}