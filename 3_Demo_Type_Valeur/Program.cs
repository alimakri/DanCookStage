using _3_Demo_Type_Valeur;

Voiture maVoitureA = new Voiture("Toyota", "Corolla");

maVoitureA.AfficherDetails();

// Modification des propriétés de la voiture
maVoitureA.Marque = "Peugeot";
maVoitureA.Modele = "207";

Voiture maVoitureB;

maVoitureB = maVoitureA;
maVoitureA.Marque = "Renault";
maVoitureA.Modele = "Clio 3";

maVoitureA.AfficherDetails();


