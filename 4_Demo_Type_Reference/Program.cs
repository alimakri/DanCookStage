
// int est un type Valeur
using Type_Valeur_Reference;

int i = 7;
int j = 0;
j = i;
i = 9;
Console.WriteLine("Type de valeurs:");
Console.WriteLine("i: " + i);
Console.WriteLine("j: " + j);
Console.WriteLine("j ne change pas même si i a changé");
Console.WriteLine();

// enum est un type Valeur
Couleur c1 = Couleur.Rouge;
Couleur c2 = Couleur.Vert;
c2 = c1;
c1 = Couleur.Bleu;
Console.WriteLine("Type de valeurs:");
Console.WriteLine("c1: " + c1);
Console.WriteLine("c2: " + c2);
Console.WriteLine("c2 ne change pas même si c1 a changé");
Console.WriteLine();

// VoitureValeur (struct) est un type Valeur
VoitureValeur maVoitureA;
maVoitureA.Marque = "Toyota";
maVoitureA.Modele = "Corolla";
VoitureValeur maVoitureB;
maVoitureB = maVoitureA;
maVoitureA.Marque = "Renault";
maVoitureA.Modele = "Clio 3";
maVoitureA.AfficherDetails("maVoitureA");
maVoitureB.AfficherDetails("maVoitureB");
Console.WriteLine("maVoitureB ne change pas quand  maVoitureA a changé");
Console.WriteLine();

// VoitureReference (class) est un type Référence
VoitureReference ma_VoitureA = new VoitureReference();
ma_VoitureA.Marque = "Toyota";
ma_VoitureA.Modele = "Corolla";
VoitureReference ma_VoitureB;
ma_VoitureB = ma_VoitureA;
ma_VoitureA.Marque = "Renault";
ma_VoitureA.Modele = "Clio 3";
ma_VoitureA.AfficherDetails("ma_VoitureA");
ma_VoitureB.AfficherDetails("ma_VoitureB");
Console.WriteLine("maVoitureB change  quand  maVoitureA a changé");


Console.ReadLine();