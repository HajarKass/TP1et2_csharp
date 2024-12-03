namespace GestionArticles
{
    // Classe de base
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

    // Classe Livre dérivée d'Article
    public class Livre : Article
    {
        protected string isbn;
        protected int nbPages;

        public Livre(string designation, double prix, string isbn, int nbPages)
            : base(designation, prix)
        {
            this.isbn = isbn;
            this.nbPages = nbPages;
        }
        /* public override string ToString()
            {
                return $"Livre: {designation}, Prix: {prix}, ISBN: {isbn}, Pages: {nbPages}";
            }
        */
    }

    // Classe Poche dérivée de Livre
    public class Poche : Livre
    {
        public string categorie;

        public Poche(string designation, double prix, string isbn, int nbPages, string categorie)
            : base(designation, prix, isbn, nbPages)
        {
            this.categorie = categorie;
        }
    }

    // Classe Broche dérivée de Livre
    public class Broche : Livre
    {
        public Broche(string designation, double prix, string isbn, int nbPages)
            : base(designation, prix, isbn, nbPages)
        {
        }
    }

    // Classe Disque dérivée d'Article
    public class Disque : Article
    {
        protected string label;

        public Disque(string designation, double prix, string label)
            : base(designation, prix)
        {
            this.label = label;
        }

        public void Ecouter()
        {
            Console.WriteLine($"Écoute du disque {designation} avec le label {label}.");
        }
    }

    // Classe Video dérivée d'Article
    public class Video : Article
    {
        protected double duree;

        public Video(string designation, double prix, double duree)
            : base(designation, prix)
        {
            this.duree = duree;
        }

        public void Afficher()
        {
            Console.WriteLine($"La vidéo {designation} de durée {duree} heures est affichée.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Exemple d'utilisation des classes
        GestionArticles.Article article = new GestionArticles.Article("Article acheté", 19.99);
        article.Acheter();
        //GestionArticles.Livre livre = new GestionArticles.Livre("Article acheté", 19.99, "97818410", 350);
        //Console.WriteLine(livre);
    }
}