using System;
using System.Collections.Generic;
using System.Linq;
using LesBases; // Réutilisation du namespace contenant Article

namespace InitObjComp
{
    // Classe pour définir les méthodes d'extension
    public static class ArticleExtensions
    {
        // 1. Méthode d'extension AfficherTous()
        public static void AfficherTous(this List<Article> articles)
        {
            Console.WriteLine("Liste complète des articles :");
            foreach (var article in articles)
            {
                Console.WriteLine($"Nom: {article.Nom}, Prix: {article.Prix} €, Quantité: {article.Quantite}, Type: {article.Type}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Initialisation de la liste d'articles
            List<Article> articles = new List<Article>
            {
                new Article("Pomme", 2.5, 50, Article.TypeArticle.Alimentaire),
                new Article("Savon", 3.2, 30, Article.TypeArticle.Droguerie),
                new Article("T-shirt", 15.0, 20, Article.TypeArticle.Habillement),
                new Article("Ordinateur", 800.0, 5, Article.TypeArticle.Electronique),
                new Article("Ballon", 10.0, 15, Article.TypeArticle.Loisir)
            };

            // 1. Test de la méthode d'extension AfficherTous()
            articles.AfficherTous();

            // 2. Calcul de la valeur totale du stock avec une expression lambda
            double valeurTotaleStock = articles.Sum(a => a.Prix * a.Quantite);
            Console.WriteLine($"\nValeur totale du stock de tous les articles : {valeurTotaleStock:F2} €");
        }
    }
}