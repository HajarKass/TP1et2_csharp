using System;
using System.Collections.Generic;
using System.Linq;
using LesBases; // Namespace contenant ArticleTypé

namespace InitObjComp
{
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

            Console.WriteLine("=== Requêtes LINQ de base ===");

            // 1. Lister tous les articles appartenant à un type spécifique
            var alimentaires = articles.Where(a => a.Type == Article.TypeArticle.Alimentaire);
            Console.WriteLine("Articles de type Alimentaire :");
            foreach (var article in alimentaires)
            {
                Console.WriteLine($"Nom: {article.Nom}, Prix: {article.Prix}, Quantité: {article.Quantite}");
            }

            // 2. Trier les articles par prix décroissant
            var triParPrixDesc = articles.OrderByDescending(a => a.Prix);
            Console.WriteLine("\nArticles triés par prix décroissant :");
            foreach (var article in triParPrixDesc)
            {
                Console.WriteLine($"Nom: {article.Nom}, Prix: {article.Prix}");
            }

            // 3. Calculer le stock total pour tous les articles
            var stockTotal = articles.Sum(a => a.Quantite);
            Console.WriteLine($"\nStock total de tous les articles : {stockTotal}");

            Console.WriteLine("\n=== Filtrage avancé avec OfType ===");

            // Création d'une liste mixte
            var objetsMixtes = new List<object>
            {
                new Article("Chaussures", 50.0, 10, Article.TypeArticle.Habillement),
                "Ceci est un texte",
                123,
                new Article("Téléphone", 500.0, 8, Article.TypeArticle.Electronique)
            };

            // Utilisation de OfType pour filtrer les articles typés
            var articlesFiltrés = objetsMixtes.OfType<Article>();
            Console.WriteLine("Articles extraits de la liste mixte :");
            foreach (var article in articlesFiltrés)
            {
                Console.WriteLine($"Nom: {article.Nom}, Prix: {article.Prix}, Type: {article.Type}");
            }

            Console.WriteLine("\n=== Projection avec des types anonymes ===");

            // Projection en types anonymes
            var projectionAnonyme = articles.Select(a => new { a.Nom, a.Prix });
            Console.WriteLine("Vue simplifiée des articles (Nom et Prix) :");
            foreach (var article in projectionAnonyme)
            {
                Console.WriteLine($"Nom: {article.Nom}, Prix: {article.Prix}");
            }
        }
    }
}